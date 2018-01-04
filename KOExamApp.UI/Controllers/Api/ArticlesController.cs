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
    public class ArticlesController : ApiController
    {
        private ArticleManager _am;

        public ArticlesController()
        {
            _am = new ArticleManager();
        }
        // GET /api/Articles
        public IHttpActionResult GetArticles()
        {
            var articleDtos = _am.GetAll();

            return Ok(articleDtos);
        }

        // GET /api/Articles/1

        public IHttpActionResult GetArticle(int id)
        {
            var articleDto = _am.Get(id);
            if (articleDto == null)
                return NotFound();
            return Ok(articleDto);
        }

        // POST /api/Articles
        [HttpPost]
        public IHttpActionResult CreateArticle(ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_am.Add(articleDto))
            {
                articleDto.Id = articleDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + articleDto.Id), articleDto);
            }
            return BadRequest();

        }


        // PUT /api/Articles/1
        [HttpPut]
        public IHttpActionResult UpdateArticle(int id, ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var articleInDb = _am.Get(id);

            if (articleInDb == null)
                return NotFound();


            var updatedArticleDto = Mapper.Map(articleDto, articleInDb);

            if (_am.Update(id, updatedArticleDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Articles/1
        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id)
        {
            var articleInDb = _am.Get(id);

            if (articleInDb == null)
                return NotFound();

            if (_am.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
