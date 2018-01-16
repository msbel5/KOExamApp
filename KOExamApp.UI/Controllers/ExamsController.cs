using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;
using KOExamApp.UI.Controllers.Api;
using KOExamApp.UI.ViewModels;

namespace KOExamApp.UI.Controllers
{
    [Authorize]
    [HandleError(ExceptionType = typeof(DbUpdateException), View = "Error")]
    public class ExamsController : Controller
    {
        private ExamManager _em;
        private ExamService _es;
        private ArticleManager _am;
        private QuestionManager _qm;
        private ChoiceManager _cm;

        public ExamsController()
        {
            _em = new ExamManager();
            _es = new ExamService();
            _am = new ArticleManager();
            _qm = new QuestionManager();
            _cm = new ChoiceManager();
        }
        // GET: Exams
        [AllowAnonymous]//for publishing
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]//for publishing
        public ActionResult Take(int id)
        {
            var exam = _em.Get(id);
            var questions = _qm.Find(m => m.ExamId == id);
            var questionList = questions as IList<QuestionDto> ?? questions.ToList();
            foreach (var question in questionList)
            {
                var choices = _cm.Find(m => m.QuestionId == question.Id);
                var choicesList = choices as IList<ChoiceDto> ?? choices.ToList();
                foreach (var choice in choices)
                {
                    choice.IsAnswer = false;
                }
                question.Choices = choicesList;
            }
            exam.Questions = questionList;
            var article = _am.Get(exam.ArticleId);

            if (exam == null)
                return HttpNotFound();

            var viewModel = new ExamFormViewModel()
            {
                Exam = exam,
                Article = article
            };
            return View(viewModel);
        }

        public ActionResult New(int id)
        {
            ExamDto exam = _es.CreateExam(id);
            ArticleDto article = _am.Get(id);
            IEnumerable<ArticleDto> ddList = _am.GetAll();
            var articleDtos = ddList as ArticleDto[] ?? ddList.ToArray();
            SelectList slist = new SelectList(articleDtos,"Id","Title");
            
            var viewModel = new ExamFormViewModel
            {
                Exam = exam,
                Article = article,
                ArticleList = slist
            };
            return View("ExamForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ExamDto exam, int id)
        {
            if (!ModelState.IsValid)
            {
                ExamDto newExam = _es.CreateExam(id);
                ArticleDto article = _am.Get(id);
                IEnumerable<ArticleDto> ddList = _am.GetAll();
                var articleDtos = ddList as ArticleDto[] ?? ddList.ToArray();
                SelectList slist = new SelectList(articleDtos, "Id", "Title");

                var viewModel = new ExamFormViewModel
                {
                    Exam = newExam,
                    Article = article,
                    ArticleList = slist
                };
                return View("ExamForm", viewModel);
            }
            if (exam.Id == 0)
            {
                exam.ArticleId = id;
                _em.Add(exam);
                foreach (var choice in exam.CorrectChoicesGuid)
                {
                    var choiceInDb = _cm.Get(choice);
                    choiceInDb.IsAnswer = true;
                    _cm.Update(choiceInDb.Id, choiceInDb);
                }
            }
            else
            {
                int examId = Convert.ToInt32(exam.Id);
                var examInDb = _em.Get(examId);
                var articleInDb = _am.Get(id);
                var updateExamDto = Mapper.Map(exam, examInDb);
                updateExamDto.ArticleId = articleInDb.Id;
                _em.Update(examId, updateExamDto);
                foreach (var choice in exam.CorrectChoicesGuid)
                {
                    var choiceInDb = _cm.Get(choice);
                    choiceInDb.IsAnswer = true;
                    _cm.Update(choiceInDb.Id, choiceInDb);
                }
            }
            return RedirectToAction("Index", "Exams");
        }

        public ActionResult Edit(int id)
        {
            var exam = _em.Get(id);
            var questions = _qm.Find(m => m.ExamId == id);
            var questionList = questions as IList<QuestionDto> ?? questions.ToList();
            foreach (var question in questionList)
            {
                var choices = _cm.Find(m => m.QuestionId == question.Id);
                var choicesList = choices as IList<ChoiceDto> ?? choices.ToList(); 
                question.Choices = choicesList;
            }
            exam.Questions = questionList;
            var article = _am.Get(exam.ArticleId);

            if (exam == null)
                return HttpNotFound();

            IEnumerable<ArticleDto> ddList = _am.GetAll();
            var articleDtos = ddList as ArticleDto[] ?? ddList.ToArray();
            SelectList slist = new SelectList(articleDtos, "Id", "Title");

            var viewModel = new ExamFormViewModel
            {
                Exam = exam,
                Article = article,
                ArticleList = slist
            };
            return View("ExamForm", viewModel);
        }
    }
}