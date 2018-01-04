using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.DAL.Interfaces;
using KOExamApp.DAL.Models;
using KOExamApp.DAL.Repositories;

namespace KOExamApp.BLL.Services
{
    public class QuestionManager
    {
        private QuestionRepository _repository;

        public QuestionManager()
        {
            _repository = new QuestionRepository();
        }
        public QuestionDto Get(int id)
        {
            var questionInDb = _repository.Get(id);
            return Mapper.Map<Question, QuestionDto>(questionInDb);
        }

        public IEnumerable<QuestionDto> GetAll()
        {
            var questionInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(questionInDb);
        }

        public IEnumerable<QuestionDto> Find(Expression<Func<QuestionDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<QuestionDto, bool>>, Expression<Func<Question, bool>>>(predicate);
            var questionInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(questionInDb);
        }

        public bool Add(QuestionDto entity)
        {
            var mappedDto = Mapper.Map<QuestionDto, Question>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<QuestionDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<QuestionDto>, IEnumerable<Question>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, QuestionDto entity)
        {
            var mappedDto = Mapper.Map<QuestionDto, Question>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<QuestionDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<QuestionDto>, IEnumerable<Question>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
