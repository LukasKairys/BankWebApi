using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using WebAPI.Handlers.TransactionsHandlers;
using WebAPI.Handlers.UsersHandlers;
using WebAPI.Messages.TransactionMessages;
using WebAPI.Messages.UserMessages;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            TransactionsRepository transactionsRepository = new TransactionsRepository();
            transactionsRepository.GetAll();

            GetUserRequest getUserRequest = new GetUserRequest { UserId = id };

            var handler = new GetUserHandler();

            var response = handler.Handle(getUserRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            GetTransactionsAverageHandler testhandler = new GetTransactionsAverageHandler();
            var a = testhandler.HandleCore(new GetTransactionsAverageRequest { BankId = 3});


            GetAllUsersRequest getAllUsersRequest = new GetAllUsersRequest();

            var handler = new GetAllUsersHandler();

            var response = handler.Handle(getAllUsersRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]AddUserRequest addUserRequest)
        {
            var handler = new AddUserHandler();

            var response = handler.Handle(addUserRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]UpdateUserRequest updateUserRequest)
        {
            var handler = new UpdateUserHandler();

            var response = handler.Handle(updateUserRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        [HttpDelete]
        public HttpResponseMessage Delete(DeleteUserRequest deleteUserRequest)
        {
            var handler = new DeleteUserHandler();

            var response = handler.Handle(deleteUserRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
