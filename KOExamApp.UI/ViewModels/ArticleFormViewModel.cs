using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOExamApp.BLL.Dtos;

namespace KOExamApp.UI.ViewModels
{
    public class ArticleFormViewModel
    {
        public ArticleDto Article { get; set; }

        public string Title
        {
            get
            {
                if (Article != null && Article.Id != 0)
                    return "Edit Article";

                return "New Article";

            }
        }
    }
}