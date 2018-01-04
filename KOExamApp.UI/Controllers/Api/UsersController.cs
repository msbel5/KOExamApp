using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;

namespace KOExamApp.UI.Controllers.Api
{
    public class UsersController : ApiController
    {
        
        private UserManager _um;

        public UsersController()
        {
            _um = new UserManager();
        }
        // GET /api/users
        public IHttpActionResult GetUsers()
        {
            var userDtos = _um.GetAll();

            return Ok(userDtos);
        }

        // GET /api/users/1

        public IHttpActionResult GetUser(int id)
        {
            var userDto = _um.Get(id);
            if (userDto == null)
                return NotFound();
            return Ok(userDto);
        }

        // POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_um.Add(userDto))
            {
                userDto.Id = userDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + userDto.Id), userDto);
            }
            return BadRequest();

        }


        // PUT /api/users/1
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userInDb = _um.Get(id);

            if (userInDb == null)
                return NotFound();


            var updateduserDto = Mapper.Map(userDto, userInDb);

            if (_um.Update(id, updateduserDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/users/1
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userInDb = _um.Get(id);

            if (userInDb == null)
                return NotFound();

            if (_um.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
