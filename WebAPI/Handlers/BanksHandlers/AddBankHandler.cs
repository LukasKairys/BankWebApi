using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Dto;
using WebAPI.Messages.BankMessages;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Handlers.BanksHandlers
{
    public class AddBankHandler : BaseHandler<AddBankRequest, AddBankResponse>
    {
        private readonly IBanksRepository _repository;

        public AddBankHandler(IBanksRepository banksRepository = null)
        {
            _repository = banksRepository ?? new BanksRepository();
        }

        public override AddBankResponse HandleCore(AddBankRequest request)
        {
            _repository.Insert(request.Bank);

            return new AddBankResponse();
        }

        public override bool Validate(AddBankRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new AddBankResponse { Errors = errors };

            return true;
        }

    }
}