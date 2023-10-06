using BLL.Services;
using Prize_Bond.Models;
using Prize_Bond.AuthFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;

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

        [Logged]
        [HttpPost]
        [Route("api/home/createbond")]
        public HttpResponseMessage CreateBond(PrizeBondDTO prizeBond)
        {
            if(prizeBond == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Invalid Prize Bond Information" });
            }
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                prizeBond.CreateAt = DateTime.Now;
                prizeBond.UserId = userId;
                var msg= PrizeBondServices.CreateBond(prizeBond);
                if (msg)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "Bond Created" });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Something went wrong in Creation of Prize Bond " });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message.ToString());

            }
        }
    }
}
