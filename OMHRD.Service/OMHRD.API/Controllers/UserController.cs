using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMHRD.Model;
using OMHRD.BL;

namespace OMHRD.API.Controllers
{
    //[OMHRDAuthorize]
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private UserBL _userBL;
        public UserController()
        {
            _userBL = new UserBL();
        }

        [HttpGet]
        [Route("login/username/{username}/password/{password}")]        
        public HttpResponseMessage Login(string username, string password)
        {
            var user = _userBL.Login(username, password);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserProfileDTO user)
        {
            var userId = _userBL.Register(user);
            return Request.CreateResponse(HttpStatusCode.OK, userId);
        }
        
    }
}
