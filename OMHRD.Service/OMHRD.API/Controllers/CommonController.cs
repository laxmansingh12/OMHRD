using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SBMS.Models;
using SBMS.BAL;
using System.Collections.Generic;
using System;
using System.Net.Http.Headers;
using OMHRD.API;

namespace SBMSservices.Controllers
{
   [OMHRD.API.OMHRDAuthorize]
   [RoutePrefix("common")]
    public class CommonController : ApiController
    {
        AdminBL _AdminBL;
        public CommonController() {
            _AdminBL = new AdminBL();
        }

                // GET api/<controller>
        [Route("GetAllStates")]
        [HttpGet]
        public async Task<ServiceResponse<StateModel>> GetAllStates() {
            var objSR = new ServiceResponse<StateModel>();
            List<StateModel> objList = new List<StateModel>();
            try
            {
                var stateList = _AdminBL.GetAllStates();
                if (stateList.Count > 0)
                {
                    objSR.List = stateList;
                    objSR.StatusCode = 1;
                }
                else
                {
                    objSR.StatusCode = 2;
                    objSR.Messages.Add("State list is not able to load.");
                }
            }
            catch (Exception ex) {
                objSR.StatusCode = 2;
                objSR.Messages.Add("Error occurred while login, " + ex.Message);
            }
            return await Task.Run(() => objSR);
        }
    }
}