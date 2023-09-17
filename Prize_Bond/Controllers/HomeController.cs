using BLL.Services;
using Prize_Bond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prize_Bond.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(Register obj)
        {
            try
            {
                var res = UserServices.CreateUser(obj.Name, obj.UserName, obj.Email,obj.PhoneNumber, obj.Password);
                if (res == true)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "User account created. Back to login" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong!" });

        }
    }
}
