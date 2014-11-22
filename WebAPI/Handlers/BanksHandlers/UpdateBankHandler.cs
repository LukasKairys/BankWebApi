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
    public class UpdateBankHandler : BaseHandler<UpdateBankRequest, UpdateBankResponse>
    {
        private readonly IBanksRepository _repository;

        public UpdateBankHandler(IBanksRepository banksRepository = null)
        {
            _repository = banksRepository ?? new BanksRepository();
        }

        public override UpdateBankResponse HandleCore(UpdateBankRequest request)
        {
            _repository.Update(request.Bank);

            return new UpdateBankResponse();
        }

        public override bool Validate(UpdateBankRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new UpdateBankResponse { Errors = errors };

            return true;
        }

    }
}