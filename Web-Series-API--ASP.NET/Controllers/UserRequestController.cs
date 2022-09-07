using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class UserRequestController : ApiController
    {
        [Route("api/user-requests")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserRequestService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no requests found.", e);
            }
        }
        [Route("api/user-requests/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserRequestService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error! Request not found.", e);
            }
        }
        [Route("api/user-request/create")]
        [HttpPost]
        public HttpResponseMessage Post(UserRequestModel r)
        {
            try
            {
                UserRequestService.Create(r);
                return Request.CreateResponse(HttpStatusCode.Created, "User request added successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user-request.", e);
            }
        }
        [Route("api/user-request/edit")]
        [HttpPut]
        public HttpResponseMessage Put(UserRequestModel ur)
        {
            try
            {
                UserRequestService.Update(ur);
                return Request.CreateResponse(HttpStatusCode.OK, "User request updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating request.", e);
            }
        }
        [Route("api/user-request/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                UserRequestService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "User request removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error action while removing.", e);
            }
        }
    }
}
