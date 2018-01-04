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
    public class ExamsController : ApiController
    {
        private ExamManager _em;

        public ExamsController()
        {
            _em = new ExamManager();
        }
        // GET /api/Exams
        public IHttpActionResult GetExams()
        {
            var examDtos = _em.GetAll();

            return Ok(examDtos);
        }

        // GET /api/Exams/1

        public IHttpActionResult GetExam(int id)
        {
            var examDto = _em.Get(id);
            if (examDto == null)
                return NotFound();
            return Ok(examDto);
        }

        // POST /api/Exams
        [HttpPost]
        public IHttpActionResult CreateExam(ExamDto examDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_em.Add(examDto))
            {
                examDto.Id = examDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + examDto.Id), examDto);
            }
            return BadRequest();

        }


        // PUT /api/Exams/1
        [HttpPut]
        public IHttpActionResult UpdateExam(int id, ExamDto examDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var examInDb = _em.Get(id);

            if (examInDb == null)
                return NotFound();


            var updatedExamDto = Mapper.Map(examDto, examInDb);

            if (_em.Update(id, updatedExamDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Exams/1
        [HttpDelete]
        public IHttpActionResult DeleteExam(int id)
        {
            var examInDb = _em.Get(id);

            if (examInDb == null)
                return NotFound();

            if (_em.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
