using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;
using KOExamApp.UI.ViewModels;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace KOExamApp.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        private ArticleManager _am;

        private QuestionManager _qm;
        private ChoiceManager _cm;
        private ExamManager _em;
        private ExamService _es;

        public HomeController()
        {
            _am = new ArticleManager();
            _es = new ExamService();
            _em= new ExamManager();
            _cm = new ChoiceManager();
            _qm = new QuestionManager();
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
            string guid = Guid.NewGuid().ToString();
            var viewModel = new ArticleFormViewModel
            {
                Article = new ArticleDto { Guid = guid}
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

        public ActionResult PopulateArticleTable()
        {
            _es.PopulateArticleTable();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NewExam()
        {
            _es.PopulateArticleTable();
            int articleId = _am.GetAll().First().Id;
            return RedirectToAction("New", "Exams", new { id = articleId });
        }


    }
}