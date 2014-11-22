using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetAll();
        List<Transaction> Get(int id);
        void Insert(Transaction transaction);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        private string _connectionString;

        public TransactionsRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString;
        }

        public List<Transaction> GetAll()
        {
            List<Transaction> transactions = new List<Transaction>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(
                            "SELECT [TransactionId], [SenderId], [ReceiverId], [AmountOfMoney], [Date]," +
                            "[SenderBankId], [ReceiverBankId] FROM [Transactions]", conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int transactionId = Convert.ToInt32(row[0]);
                        int senderId = Convert.ToInt32(row[1]);
                        int receiverId = Convert.ToInt32(row[2]);
                        long amountOfMoney = Convert.ToInt64(row[3]);
                        DateTime date = Convert.ToDateTime(row[4]);
                        int senderBankId = Convert.ToInt32(row[5]);
                        int receiverBankId = Convert.ToInt32(row[6]);

                        transactions.Add( new Transaction
                        {
                            TransactionId = transactionId,
                            AmountOfMoney = amountOfMoney,
                            Date = date,
                            ReceiverBankId = receiverBankId,
                            SenderBankId = senderBankId,
                            SenderId = senderId,
                            ReceiverId = receiverId
                        });
                           
                    }

                }
            }

            return transactions;
        }

        public List<Transaction> Get(int id)
        {
            List<Transaction> transactions = new List<Transaction>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(
                            "SELECT [TransactionId], [SenderId], [ReceiverId], [AmountOfMoney], [Date]," +
                            "[SenderBankId], [ReceiverBankId] FROM [Transactions] WHERE [SenderBankId] = " + id, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int transactionId = Convert.ToInt32(row[0]);
                        int senderId = Convert.ToInt32(row[1]);
                        int receiverId = Convert.ToInt32(row[2]);
                        long amountOfMoney = Convert.ToInt64(row[3]);
                        DateTime date = Convert.ToDateTime(row[4]);
                        int senderBankId = Convert.ToInt32(row[5]);
                        int receiverBankId = Convert.ToInt32(row[6]);

                        transactions.Add(new Transaction
                        {
                            TransactionId = transactionId,
                            AmountOfMoney = amountOfMoney,
                            Date = date,
                            ReceiverBankId = receiverBankId,
                            SenderBankId = senderBankId,
                            SenderId = senderId,
                            ReceiverId = receiverId
                        });

                    }

                }
            }

            return transactions;
        }

        public void Insert(Transaction transaction)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO [Transactions]([SenderId], [ReceiverId], [AmountOfMoney], [Date]," +
                "[SenderBankId], [ReceiverBankId]) VALUES (@SenderId, @ReceiverId, " +
                "@AmountOfMoney, @Date, @SenderBankId, @ReceiverBankId)", conn);

                insertCommand.Parameters.AddWithValue("@SenderId", transaction.SenderId);
                insertCommand.Parameters.AddWithValue("@ReceiverId", transaction.ReceiverId);
                insertCommand.Parameters.AddWithValue("@AmountOfMoney", transaction.AmountOfMoney);
                insertCommand.Parameters.AddWithValue("@Date", transaction.Date);
                insertCommand.Parameters.AddWithValue("@SenderBankId", transaction.SenderBankId);
                insertCommand.Parameters.AddWithValue("@ReceiverBankId", transaction.ReceiverBankId);

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.InsertCommand = insertCommand;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}