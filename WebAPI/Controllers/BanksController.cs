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
using WebAPI.Handlers.BanksHandlers;
using WebAPI.Messages.BankMessages;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class BanksController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            GetBankRequest getBankRequest = new GetBankRequest { BankId = id };

            var handler = new GetBankHandler();

            var response = handler.Handle(getBankRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            GetAllBanksRequest getAllBanksRequest = new GetAllBanksRequest();

            var handler = new GetAllBanksHandler();

            var response = handler.Handle(getAllBanksRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]AddBankRequest addBankRequest)
        {
            var handler = new AddBankHandler();

            var response = handler.Handle(addBankRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]UpdateBankRequest updateBankRequest)
        {
            var handler = new UpdateBankHandler();

            var response = handler.Handle(updateBankRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        [HttpDelete]
        public HttpResponseMessage Delete(DeleteBankRequest deleteBankRequest)
        {
            var handler = new DeleteBankHandler();

            var response = handler.Handle(deleteBankRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
