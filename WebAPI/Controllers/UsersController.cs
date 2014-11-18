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
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class UsersControllers : ApiController
    {

        private static BanksRepository _banksRepository;

        public UsersControllers()
        {
            _banksRepository = new BanksRepository();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var bankList = _banksRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, bankList);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var bank = _banksRepository.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, bank);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Bank bank)
        {
            _banksRepository.Insert(bank);

            return Request.CreateResponse(HttpStatusCode.OK, "succes");
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Bank bank)
        {
            _banksRepository.Update(bank);

            return Request.CreateResponse(HttpStatusCode.OK, "succes");
        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _banksRepository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, "succes");
        }
    }
}
