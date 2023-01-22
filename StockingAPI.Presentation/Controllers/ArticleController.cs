using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stocking.Domain.AggregatesModel;
using Stocking.Domain.Interfaces;
using Stocking.Infrastruture.Repositories;
using StockingAPI.Presentation.Models;
using StockingAPI.Presentation.Models.Articles.Requests;
using StockingAPI.Presentation.Models.Articles.Responses;
using System.Net;

namespace StockingAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Articles.
        /// </summary>
        [HttpGet]
        [Route("allArticles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<IEnumerable<ArticleResponse>>>> GetAllArticles()
        {
            
            Response<IEnumerable<ArticleResponse>> response;
            var articles = await _articleService.GetAll();
            var articleMap = _mapper.Map<IEnumerable<ArticleResponse>>(articles);
            try
            {
                response = new Response<IEnumerable<ArticleResponse>>()
                {
                    Data = articleMap,
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }
        /// <summary>
        /// Add new article
        /// </summary>
        /// <param name="articleDto">article</param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ArticleResponse>> AddArticle([FromBody] CreateArticlesDTO articleDto)//[FromBody] 
        {
            
            var article = _mapper.Map<Article>(articleDto);
            // Vérifiez si le numéro de référence est unique
            var existRef = await _articleService.ExistReferenceAsync(article.Reference);
            if (!existRef)
            {
                var result = new ArticleResponse();
                result.Id = Guid.NewGuid();
                result.Reference = article.Reference;//
                result.Name = article.Name;
                result.Quantity = article.Quantity;
                result.HT = article.HT;
                result.IsTakeAway = (article.Type == Category.Alimentaire) ? article.IsTakeAway : false;
                var articleMap = _mapper.Map<Article>(result);

                await _articleService.AddAsync(articleMap);

                return Ok();
            }
            else
            {
                //throw new Exception("The reference of article already exist!");
                return NotFound(new { Message = $"The reference {article.Reference} of article already exist!" });
            }

        }
        /// <summary>
        /// Get specific article
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        [HttpGet("{reference}")]
        public async Task<ActionResult<ArticlesDTO>> GetArticle(string reference)
        {

            var article = await _articleService.GetByReference(reference);
            if (article == null)
                return NotFound();
            var articleDTO = _mapper.Map<ArticlesDTO>(article);
            
            return Ok(articleDTO);
        }
        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="id">Identifiant</param>
        /// <param name="articleDTO">Article</param>
        /// <returns></returns>
        [HttpPut("{reference}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult<Article> UpdateArticle(string reference, UpdateArticlesDTO articleDTO)
        {
            var article =   _articleService.GetByReference(reference);
            var id = article.Result.Id;
            var result = new ArticleResponse();
            if (article == null)
                return NotFound(new { Message = $"Item with reference {reference} not found." });// NotFound();
            else
            {
                result.Id = id;
                result.Reference = reference;
                result.Name = articleDTO.Name;
                result.Category = articleDTO.Type;
                result.Quantity = articleDTO.Quantity;
                result.HT = articleDTO.Price;
                result.TVA = articleDTO.TVA;
                var articleMap = _mapper.Map<Article>(result);
                _articleService.Update(articleMap);
                return Ok();
            }
            
        }
        /// <summary>
        /// Delete specific article
        /// </summary>
        /// <param name="reference">Identifiant</param>
        /// <returns></returns>
        [HttpDelete("{reference}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteArticle(string reference)
        {
            var article = await _articleService.GetByReference(reference);
            if (article == null)
                return NotFound();//BadRequest()
            await _articleService.DeleteAsync(article);

            return Ok();
        }
    }
}
