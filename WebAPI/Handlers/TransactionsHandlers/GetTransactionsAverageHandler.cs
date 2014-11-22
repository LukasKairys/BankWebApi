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
    public class GetTransactionsAverageHandler : BaseHandler<GetTransactionsAverageRequest, GetTransactionsAverageResponse>
    {
        private readonly ITransactionsRepository _repository;

        public GetTransactionsAverageHandler(ITransactionsRepository transactionsRepository = null)
        {
            _repository = transactionsRepository ?? new TransactionsRepository();
        }

        public override GetTransactionsAverageResponse HandleCore(GetTransactionsAverageRequest request)
        {
            List<Transaction> transactions = _repository.GetAll();

            var transactionsAverage =
                transactions.Where(transaction => transaction.SenderBankId == request.BankId)
                            .Average(transaction => transaction.AmountOfMoney);
           
            return new GetTransactionsAverageResponse { TransactionsAverage = Convert.ToInt64(transactionsAverage) };
        }

        public override bool Validate(GetTransactionsAverageRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetTransactionsAverageResponse { Errors = errors };

            return true;
        }

    }
}