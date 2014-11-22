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
    public class GetAllBanksHandler : BaseHandler<GetAllBanksRequest, GetAllBanksResponse>
    {
        private readonly IBanksRepository _repository;

        public GetAllBanksHandler(IBanksRepository banksRepository = null)
        {
            _repository = banksRepository ?? new BanksRepository();
        }

        public override GetAllBanksResponse HandleCore(GetAllBanksRequest request)
        {
            List<Bank> banks = _repository.GetAll();

            return new GetAllBanksResponse { Banks = banks };
        }

        public override bool Validate(GetAllBanksRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetAllBanksResponse { Errors = errors };

            return true;
        }

    }
}