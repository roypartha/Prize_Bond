using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using Prize_Bond.AuthFilters;

namespace Prize_Bond.Controllers
{
    public class BondController : ApiController
    {
        [Logged]
        [HttpPost]
        [Route("api/bond/all")]

        public HttpResponseMessage GetAll()
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);
                if (userId > 0)
                {
                    var msg = PrizeBondServices.GetPrizeBondByUserId(userId);
                    if (msg != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, msg);
                    }

                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "No Bond found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }


        }

        [Logged]
        [HttpPost]
        [Route("api/bond/info")]

        public HttpResponseMessage GetUserById()
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId= AuthServices.GetUserID(token);

                if(userId > 0)
                {
                    var info = UserServices.GetUserById(userId);
                    if (info != null) {
                        return Request.CreateResponse(HttpStatusCode.OK, info);

                    }
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden,new {Msg = "Something Wrong...!!"});

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/bond/delete/{id}")]

        public HttpResponseMessage DeleteBond(int id)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                var userId = AuthServices.GetUserID(token);

                if (userId > 0)
                {
                    var msg = UserServices.DeteteBond(id);
                    if (msg)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new {msg ="Bond Deleted"});

                    }
 
                }
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { msg = "Something wrong to delete" });
            }
            catch(Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }

           
        }
    }
}
