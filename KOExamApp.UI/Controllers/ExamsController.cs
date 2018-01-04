using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Take(int id)
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
            
            var viewModel = new ExamFormViewModel
            {
                Exam = exam,
                Article = article
            };
            return View("ExamForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ExamDto exam,int id)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ExamFormViewModel()
                {
                    Exam =exam
                };
                return View("ExamForm", viewModel);
            }
            if (exam.Id == 0)
            {
                exam.ArticleId = id;
                _em.Add(exam);
            }
            else
            {
                int examId = Convert.ToInt32(exam.Id);
                var examInDb = _em.Get(examId);
                var articleInDb = _am.Get(id);
                var updateExamDto = Mapper.Map(exam, examInDb);
                updateExamDto.ArticleId = articleInDb.Id;
                _em.Update(examId, updateExamDto);
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

            var viewModel = new ExamFormViewModel()
            {
                Exam = exam,
                Article = article
            };
            return View("ExamForm", viewModel);
        }
    }
}