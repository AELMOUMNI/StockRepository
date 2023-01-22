
using Microsoft.EntityFrameworkCore;
using Stocking.Domain.AggregatesModel;
using Stocking.Domain.Interfaces;
using Stocking.Domain.SeedWork;
using Stocking.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Infrastruture.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly StockContext _context;
        //private List<Article> _books;
        protected readonly DbSet<Article> DbSet;
        
        public ArticleRepository(StockContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //DbSet = context.Set<Article>();
        }
        public async Task<Article> AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return article;
        }
        public void Update(Article article)
        {
            //_context.Entry(article).State = EntityState.Modified;
            var _art = _context.Articles.Where(x=>x.Reference == article.Reference).FirstOrDefault();
            var existingArticle = _context.Articles.Find(_art.Id);
            if (existingArticle != null)
            {
                _context.Entry(existingArticle).CurrentValues.SetValues(article);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Article not found");
            }
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Articles.ToListAsync(); //DbSet.ToListAsync();
        }

        public async Task<bool> ExistReferenceAsync(string reference)
        {
            var article = await _context.Articles.Where(x=> x.Reference == reference).SingleOrDefaultAsync();
            return await _context.Set<Article>().FindAsync(article?.Id) != null;//return await _db.Set<T>().FindAsync(id) != null;

        }

        public async Task<Article> GetByReference(string reference)
        {
            var article = _context.Articles.Where(x => x.Reference == reference).SingleOrDefault();
            //var article = _context.Articles.FirstOrDefault(x => x.Reference == reference);
            if (article == null)
            {
                throw new Exception("Article not found");
            }
            return article;
        }

        public async Task DeleteAsync(Article article)
        {
            _context.Set<Article>().Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByReferenceAsync(string reference)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Reference == reference);
            await DeleteAsync(article);
        }

        public Task<Article> GetById(string reference)
        {
            throw new NotImplementedException();
        }
    }
}
