using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.BL
{
    public interface IUserBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserProfileDTO Login(string username, string password);

        int Register(UserProfileDTO userDto);
    }
}
