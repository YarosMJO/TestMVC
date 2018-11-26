using System.Collections.Generic;
using System.Linq;
using TestMVC.Models;

namespace TestMVC.Repositories
{
    public class UserRepository
    {
        private static List<User> users = new List<User>
           {
               new User()
               {
                   Id = 1,
                   UserName = "Robert",
                   Password = "password"
               },
                new User()
               {
                   Id = 2,
                   UserName = "John",
                   Password = "eubbdbabd"
               },
                 new User()
               {
                   Id = 3,
                   UserName = "Natali",
                   Password = "jdwwkwkdd"
               },
                  new User()
               {
                   Id = 4,
                   UserName = "Nicolas",
                   Password = "dwd5w4dw5"
               },
                new User()
               {
                   Id = 5,
                   UserName = "Maria",
                   Password = "password"
               },
                 new User()
               {
                   Id = 6,
                   UserName = "Pedro",
                   Password = "54546468ssds"
               },
                  new User()
               {
                   Id = 7,
                   UserName = "Oleh",
                   Password = "sdsd45ds5s"
               }
           };

        public List<User> GetAll()
        {
            return users;
        }
        public User GetById(int id)
        {
            return users.FirstOrDefault(c => c.Id == id);
        }
        public User Add(User item)
        {
            if (item != null)
            {
                users.Add(item);
                return item;
            }
            else
            {
                return null;
            }
        }

        public User Remove(int id)
        {
            var item = users.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                users.Remove(item);
                return item;
            }
            else
            {
                return null;
            }
        }

        public int GetMaxId()
        {
            return users.Count == 0 ? 0 : users.Max(x => x.Id);
        }
    }
}
