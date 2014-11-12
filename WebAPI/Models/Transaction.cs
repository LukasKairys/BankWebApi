using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Transaction
    {
        private int transactionId;
        private int senderId;
        private int? receiverId;
        private long amountOfMoney;
        private DateTime date;
        private int senderBankId;
        private int receiverBankId;

        public int TransactionId { get; set; }
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public long AmountOfMoney { get; set; }
        public DateTime Date { get; set; }
        public int SenderBankId { get; set; }
        public int ReceiverBankId { get; set; }

    }
}