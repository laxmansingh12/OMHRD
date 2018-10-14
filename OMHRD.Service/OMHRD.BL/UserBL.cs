using OMHRD.DAL;
using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.BL
{
    public class UserBL : IUserBL
    {
        private IUserRepository _userRep;
        public UserBL()
        {
            _userRep = new UserRepository();
        }

        public UserProfileDTO Login(string username, string password)
        {
            var user = _userRep.Login(username, password);
            if (user != null)
            {
                return new UserProfileDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName
                };
            }
            return null;
        }

        public int Register(UserProfileDTO userDto)
        {
            var user = new UserProfile_T()
            {
                ContactNo = userDto.ContactNo,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                ReferenceBy = userDto.ReferenceBy,
                Username = userDto.Username,
                RegistrationDate = DateTime.Now
            };

            return _userRep.Register(user);
        }
    }
}
