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
    public class ExamManager
    {
        private ExamRepository _repository;

        public ExamManager()
        {
            _repository = new ExamRepository();
        }
        public ExamDto Get(int id)
        {
            var examInDb = _repository.Get(id);
            return Mapper.Map<Exam, ExamDto>(examInDb);
        }

        public IEnumerable<ExamDto> GetAll()
        {
            var examInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDto>>(examInDb);
        }

        public IEnumerable<ExamDto> Find(Expression<Func<ExamDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ExamDto, bool>>, Expression<Func<Exam, bool>>>(predicate);
            var examInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDto>>(examInDb);
        }

        public bool Add(ExamDto entity)
        {
            var mappedDto = Mapper.Map<ExamDto, Exam>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<ExamDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ExamDto>, IEnumerable<Exam>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, ExamDto entity)
        {
            var mappedDto = Mapper.Map<ExamDto, Exam>(entity);
            mappedDto.Id = entityId;
            mappedDto.ArticleId = entity.ArticleId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<ExamDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ExamDto>, IEnumerable<Exam>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
