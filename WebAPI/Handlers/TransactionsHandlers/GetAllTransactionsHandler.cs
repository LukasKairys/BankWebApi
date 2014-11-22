using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Dto;
using WebAPI.Messages.TransactionMessages;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Handlers.TransactionsHandlers
{
    public class GetAllTransactionsHandler : BaseHandler<GetAllTransactionsRequest, GetAllTransactionsResponse>
    {
        private readonly ITransactionsRepository _repository;

        public GetAllTransactionsHandler(ITransactionsRepository TransactionsRepository = null)
        {
            _repository = TransactionsRepository ?? new TransactionsRepository();
        }

        public override GetAllTransactionsResponse HandleCore(GetAllTransactionsRequest request)
        {
            List<Transaction> transactions = _repository.GetAll();

            return new GetAllTransactionsResponse { Transactions = transactions };
        }

        public override bool Validate(GetAllTransactionsRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetAllTransactionsResponse { Errors = errors };

            return true;
        }

    }
}