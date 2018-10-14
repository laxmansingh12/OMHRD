using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public UserProfile_T Login(string username, string password)
        {
            using (var dbContext = new OMHRDModel())
            {
                return dbContext.UserProfile_T.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
            }
        }
        public int Register(UserProfile_T user)
        {
            using (var dbContext = new OMHRDModel())
            {
                dbContext.UserProfile_T.Add(user);
                return dbContext.SaveChanges();
            }
        }
    }
}
