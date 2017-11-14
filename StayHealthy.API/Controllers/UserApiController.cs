using StayHealthy.Entities.Model;
using StayHealthy.Entities.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StayHealthy.API.Controllers
{
    public class UserApiController : ApiController
    {
        UnitOfWork uow = new UnitOfWork();

        public HttpResponseMessage GetUserList()
        {
            var userList = uow.Repository<UserModel>().SQLQuery("EXEC GetUserList").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, userList);
        }
    }
}
