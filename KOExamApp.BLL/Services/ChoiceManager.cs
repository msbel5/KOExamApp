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
    public class ChoiceManager
    {
        private ChoiceRepository _repository;

        public ChoiceManager()
        {
            _repository = new ChoiceRepository();
        }
        public ChoiceDto Get(int id)
        {
            var choiceInDb = _repository.Get(id);
            return Mapper.Map<Choice, ChoiceDto>(choiceInDb);
        }

        public IEnumerable<ChoiceDto> GetAll()
        {
            var choiceInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Choice>, IEnumerable<ChoiceDto>>(choiceInDb);
        }

        public IEnumerable<ChoiceDto> Find(Expression<Func<ChoiceDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<ChoiceDto, bool>>, Expression<Func<Choice, bool>>>(predicate);
            var choiceInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Choice>, IEnumerable<ChoiceDto>>(choiceInDb);
        }

        public bool Add(ChoiceDto entity)
        {
            var mappedDto = Mapper.Map<ChoiceDto, Choice>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<ChoiceDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ChoiceDto>, IEnumerable<Choice>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, ChoiceDto entity)
        {
            var mappedDto = Mapper.Map<ChoiceDto, Choice>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<ChoiceDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<ChoiceDto>, IEnumerable<Choice>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
