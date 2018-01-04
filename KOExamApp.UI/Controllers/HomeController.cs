using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;
using KOExamApp.UI.ViewModels;

namespace KOExamApp.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        ArticleManager  _am;

        public HomeController()
        {
            _am= new ArticleManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var article = _am.Get(id);
            if (article == null)
                return HttpNotFound();
            return View(article);
        }

        public ActionResult New()
        {
            var viewModel = new ArticleFormViewModel
            {
                Article = new ArticleDto()
            };
            return View("ArticleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArticleDto article)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ArticleFormViewModel()
                {
                    Article = article
                };
                return View("ArticleForm", viewModel);
            }
            if (article.Id == 0)
            {
                _am.Add(article);
            }
            else
            {
                int articleId = Convert.ToInt32(article.Id);
                var articleInDb = _am.Get(articleId);
                var updateArticleDto = Mapper.Map(article, articleInDb);
                _am.Update(articleId, updateArticleDto);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var article = _am.Get(id);
            if (article == null)
                return HttpNotFound();

            var viewModel = new ArticleFormViewModel()
            {
                Article = article
            };
            return View("ArticleForm", viewModel);
        }
    }
}