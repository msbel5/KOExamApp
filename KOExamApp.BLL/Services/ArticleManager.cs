using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.DAL.Models;
using KOExamApp.DAL.Repositories;

namespace KOExamApp.BLL.Services
{
    public class ArticleManager
    {
        private ArticleRepository _repository;

        public ArticleManager()
        {
            _repository = new ArticleRepository();
        }
        public ArticleDto Get(int id)
        {
            var articleInDb = _repository.Get(id);
            return Mapper.Map<Article, ArticleDto>(articleInDb);
        }

        public ArticleDto Get(string guid)
        {
            var articleInDb = _repository.Get(guid);
            return Mapper.Map<Article, ArticleDto>(articleInDb);
        }

        public IEnumerable<ArticleDto> GetAll()
        {
            var articleInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articleInDb);
        }

        public IEnumerable<ArticleDto> Find(Expression<Func<ArticleDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ArticleDto, bool>>, Expression<Func<Article, bool>>>(predicate);
            var articleInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articleInDb);
        }

        public bool Add(ArticleDto entity)
        {
            var mappedDto = Mapper.Map<ArticleDto, Article>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<ArticleDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, ArticleDto entity)
        {
            var mappedDto = Mapper.Map<ArticleDto, Article>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<ArticleDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
