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
    public class GetBankHandler : BaseHandler<GetBankRequest, GetBankResponse>
    {
        private readonly IBanksRepository _repository;

        public GetBankHandler(IBanksRepository banksRepository = null)
        {
            _repository = banksRepository ?? new BanksRepository();
        }

        public override GetBankResponse HandleCore(GetBankRequest request)
        {
            Bank bank = _repository.Get(request.BankId);

            return new GetBankResponse {BankFound = bank };
        }

        public override bool Validate(GetBankRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetBankResponse { Errors = errors };

            return true;
        }

    }
}