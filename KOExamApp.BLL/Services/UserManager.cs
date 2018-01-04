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
    public class UserManager
    {
        private UserRepository _repository;

        public UserManager()
        {
            _repository = new UserRepository();
        }
        public UserDto Get(int id)
        {
            var userInDb = _repository.Get(id);
            return Mapper.Map<User, UserDto>(userInDb);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var userInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userInDb);
        }

        public IEnumerable<UserDto> Find(Expression<Func<UserDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<UserDto, bool>>, Expression<Func<User, bool>>>(predicate);
            var userInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userInDb);
        }

        public bool Add(UserDto entity)
        {
            var mappedDto = Mapper.Map<UserDto, User>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<UserDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, UserDto entity)
        {
            var mappedDto = Mapper.Map<UserDto, User>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<UserDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
