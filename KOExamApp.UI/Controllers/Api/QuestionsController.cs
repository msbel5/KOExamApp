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
    public class QuestionsController : ApiController
    {
        private QuestionManager _qm;

        public QuestionsController()
        {
            _qm = new QuestionManager();
        }
        // GET /api/Questions
        public IHttpActionResult GetQuestions()
        {
            var questionDtos = _qm.GetAll();

            return Ok(questionDtos);
        }

        // GET /api/Questions/1

        public IHttpActionResult GetQuestion(int id)
        {
            var questionDto = _qm.Get(id);
            if (questionDto == null)
                return NotFound();
            return Ok(questionDto);
        }

        // POST /api/Questions
        [HttpPost]
        public IHttpActionResult CreateQuestion(QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_qm.Add(questionDto))
            {
                questionDto.Id = questionDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + questionDto.Id), questionDto);
            }
            return BadRequest();

        }


        // PUT /api/Questions/1
        [HttpPut]
        public IHttpActionResult UpdateQuestion(int id, QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var questionInDb = _qm.Get(id);

            if (questionInDb == null)
                return NotFound();


            var updatedQuestionDto = Mapper.Map(questionDto, questionInDb);

            if (_qm.Update(id, updatedQuestionDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Questions/1
        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            var questionInDb = _qm.Get(id);

            if (questionInDb == null)
                return NotFound();

            if (_qm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
