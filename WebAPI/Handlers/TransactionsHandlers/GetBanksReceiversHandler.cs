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
    public class GetBanksReceiversHandler : BaseHandler<GetBanksReceiversRequest, GetBanksReceiversResponse>
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IBanksRepository _banksRepository;

        public GetBanksReceiversHandler(ITransactionsRepository transactionsRepository = null, IBanksRepository banksRepository = null)
        {
            _transactionsRepository = transactionsRepository ?? new TransactionsRepository();
            _banksRepository = banksRepository ?? new BanksRepository();
        }

        public override GetBanksReceiversResponse HandleCore(GetBanksReceiversRequest request)
        {
            List<Transaction> transactions = _transactionsRepository.GetAll();
            List<Bank> banks = _banksRepository.GetAll();

            var sendersReceiversList = transactions.GroupBy(t => t.SenderBankId, t => t.ReceiverBankId,
                (key, groupedItem) => new {SenderBankId = key, ReceiversBanksIds = groupedItem.ToList()});

            List<TransactionsBanksDto> transactionsBanks = sendersReceiversList
                .Join(banks, sR => sR.SenderBankId, bank => bank.BankId, (sR, bank) =>
                    new TransactionsBanksDto { BankId = bank.BankId, Name = bank.Name, ReceiversIds = sR.ReceiversBanksIds })
                    .Take(10).ToList();

            return new GetBanksReceiversResponse { BanksReceivers = transactionsBanks};
        }

        public override bool Validate(GetBanksReceiversRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetBanksReceiversResponse { Errors = errors };

            return true;
        }

    }
}