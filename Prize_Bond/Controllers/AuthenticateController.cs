using BLL.Services;
using Prize_Bond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Prize_Bond.Controllers
{
    public class AuthenticateController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                //string userAgent = Request.Headers.GetValues("User-Agent").FirstOrDefault();
                var token = AuthServices.Login(login.Username, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                //string userAgent = Request.Headers.GetValues("User-Agent").FirstOrDefault();
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                if (userId > 0)
                {
                    var userSession = AuthServices.GetUserActiveSession(userId);
                    if (userSession != null)
                    {
                        userSession.LogoutTime = DateTime.Now;
                        userSession.IsActive = false;

                        bool chk = AuthServices.ChangeSession(userSession);

                        // AND with new changeToken.
                        chk &= AuthServices.ChangeToken(userId, token);

                        if (chk)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Logged-Out" });
                        }
                        else
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not able to change the user session or token");
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not getting the user session.");
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not getting the user.");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }       

    }
    
}
