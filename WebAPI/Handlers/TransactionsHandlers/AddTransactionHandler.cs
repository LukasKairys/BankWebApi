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
    public class AddTransactionHandler : BaseHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly ITransactionsRepository _repository;

        public AddTransactionHandler(ITransactionsRepository transactionsRepository = null)
        {
            _repository = transactionsRepository ?? new TransactionsRepository();
        }

        public override AddTransactionResponse HandleCore(AddTransactionRequest request)
        {
            _repository.Insert(request.Transaction);

            return new AddTransactionResponse();
        }

        public override bool Validate(AddTransactionRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new AddTransactionResponse { Errors = errors };

            return true;
        }

    }
}