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
    public class DeleteBankHandler : BaseHandler<DeleteBankRequest, DeleteBankResponse>
    {
        private readonly IBanksRepository _repository;

        public DeleteBankHandler(IBanksRepository banksRepository = null)
        {
            _repository = banksRepository ?? new BanksRepository();
        }

        public override DeleteBankResponse HandleCore(DeleteBankRequest request)
        {
            _repository.Delete(request.BankId);

            return new DeleteBankResponse();
        }

        public override bool Validate(DeleteBankRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new DeleteBankResponse { Errors = errors };

            return true;
        }

    }
}