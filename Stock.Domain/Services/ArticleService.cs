using Stocking.Domain.AggregatesModel;
using Stocking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> AddAsync(Article article)
        {
            return await _articleRepository.AddAsync(article); 
        }

        public async Task DeleteAsync(Article article)
        {
            await _articleRepository.DeleteAsync(article);
        }

        public async Task DeleteByReferenceAsync(string reference)
        {
            await _articleRepository.DeleteByReferenceAsync(reference);
        }

        public async Task<bool> ExistReferenceAsync(string reference)
        {
            return await _articleRepository.ExistReferenceAsync(reference);
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _articleRepository.GetAll();
        }

        public Task<Article> GetById(string reference)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetByReference(string reference)
        {
            return await _articleRepository.GetByReference(reference);
        }

        public void Update(Article article)
        {
            _articleRepository.Update(article);
        }
    }
}
