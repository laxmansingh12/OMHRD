using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public interface IUserRepository
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="username"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        UserProfile_T Login(string username, string password);

        int Register(UserProfile_T user);
    }
}
