using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;
using KOExamApp.BLL.Dtos;


namespace KOExamApp.BLL.Services
{
    public class ExamService
    {
        private ArticleManager _am;
        private QuestionManager _qm;
        private ChoiceManager _cm;
        private ExamManager _em;

        public ExamService()
        {
            _am = new ArticleManager();
            _qm = new QuestionManager();
            _cm = new ChoiceManager();
            _em = new ExamManager();
            
        }

        public ExamDto CreateExam(int articleId)
        {

            ExamDto exam = new ExamDto()
            {
                ArticleId = articleId
            };
            for (int i = 0; i < 4; i++)
            {
                QuestionDto question = new QuestionDto();
                for (int j = 0; j < 4; j++)
                {
                    ChoiceDto choice = new ChoiceDto
                    {
                        OrderNum = j+1,
                        Guid = Guid.NewGuid().ToString()
                    };
                    question.AddChoice(choice);
                }
                exam.AddQuestion(question);
            }
            return exam;
        }

        public void AddExam(ExamDto exam)
        {
            _em.Add(exam);
        }

        public List<WiredArticleDto> RssReader()
        {
            {
                string rssUrl = "https://www.wired.com/feed/rss";
                WebClient wclient = new WebClient();
                string rssData = wclient.DownloadString(rssUrl);
                List<WiredArticleDto> listedRss = new List<WiredArticleDto>();
                XDocument xml = XDocument.Parse(rssData);
                for (int i = 0; i < 5; i++)
                {
                    listedRss.Add( new WiredArticleDto
                    {
                        Title = ((string)xml.Descendants("item").ToList()[i].Element("title")),
                        Link = ((string)xml.Descendants("item").ToList()[i].Element("link")),
                        Description = ((string)xml.Descendants("item").ToList()[i].Element("description")),
                        Guid = ((string)xml.Descendants("item").ToList()[i].Element("guid"))

                    });
                }
                return listedRss;
            }
        }

        public string ArticleCreater(string articleUrl)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(articleUrl);

            var articleDiv = doc.QuerySelector(".article-body-component>div").OuterHtml;
            var articleTitle = doc.QuerySelector("h1.title").OuterHtml;
            var articleAuthor = doc.QuerySelector("a.byline-component__link").InnerHtml;

            string rawHtml = "<div class = 'article'>" + articleTitle + articleDiv + articleAuthor + "</div>";

            return rawHtml;
        }

        public List<ArticleDto> CreateArticleListFromWired()
        {
            List<WiredArticleDto> rssList = RssReader();
            List<ArticleDto> articleList = new List<ArticleDto>();
            foreach (var wiredArtilce in rssList)
            {
                string body = ArticleCreater(wiredArtilce.Link);
                ArticleDto article = new ArticleDto
                {
                    Title = wiredArtilce.Title,
                    Text = body,
                    Guid = wiredArtilce.Guid
                };
                articleList.Add(article);
            }
            return articleList;
        }

        public void PopulateArticleTable()
        {
            List<ArticleDto> articleList = CreateArticleListFromWired();
            foreach (ArticleDto article in articleList)
            {
                if (_am.Get(article.Guid) == null)
                {
                    _am.Add(article);
                }
            }
        }
    }
}
