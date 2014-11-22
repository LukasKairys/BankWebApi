using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public long AmountOfMoney { get; set; }
        public DateTime Date { get; set; }
        public int SenderBankId { get; set; }
        public int ReceiverBankId { get; set; }

        [ForeignKey("SenderBankId")]
        public virtual Bank SenderBank { get; set; }

        [ForeignKey("ReceiverBankId")]
        public virtual Bank ReceiverBank { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }
    }
}