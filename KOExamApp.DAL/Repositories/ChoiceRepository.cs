using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.DAL.Repositories
{
    public class ChoiceRepository:Repository<Choice>
    {
        public Choice Get(string guid)
        {
            return _context.Set<Choice>().FirstOrDefault(a => a.Guid == guid);
        }
    }
}
