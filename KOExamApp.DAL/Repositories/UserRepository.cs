using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.DAL.Repositories
{
    public class UserRepository:Repository<User>
    {
        public User Get(string userName,string password)
        {
            return _context.Set<User>().FirstOrDefault(a => a.UserName == userName && a.Password==password);
        }
    }
}
