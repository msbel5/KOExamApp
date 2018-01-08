using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.DAL.Repositories
{
    public class ArticleRepository:Repository<Article>
    {
        public Article Get(string guid)
        {
            return _context.Set<Article>().FirstOrDefault(a => a.Guid == guid);
        }
        
    }
}
