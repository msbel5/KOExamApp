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
    public class ChoicesController : ApiController
    {
        private ChoiceManager _cm;

        public ChoicesController()
        {
            _cm = new ChoiceManager();
        }
        // GET /api/Choices
        public IHttpActionResult GetChoices()
        {
            var choiceDtos = _cm.GetAll();

            return Ok(choiceDtos);
        }

        // GET /api/Choices/1

        public IHttpActionResult GetChoice(int id)
        {
            var choiceDto = _cm.Get(id);
            if (choiceDto == null)
                return NotFound();
            return Ok(choiceDto);
        }

        // POST /api/Choices
        [HttpPost]
        public IHttpActionResult CreateChoice(ChoiceDto choiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_cm.Add(choiceDto))
            {
                choiceDto.Id = choiceDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + choiceDto.Id), choiceDto);
            }
            return BadRequest();

        }


        // PUT /api/Choices/1
        [HttpPut]
        public IHttpActionResult UpdateChoice(int id, ChoiceDto choiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var choiceInDb = _cm.Get(id);

            if (choiceInDb == null)
                return NotFound();


            var updatedChoiceDto = Mapper.Map(choiceDto, choiceInDb);

            if (_cm.Update(id, updatedChoiceDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Choices/1
        [HttpDelete]
        public IHttpActionResult DeleteChoice(int id)
        {
            var choiceInDb = _cm.Get(id);

            if (choiceInDb == null)
                return NotFound();

            if (_cm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
