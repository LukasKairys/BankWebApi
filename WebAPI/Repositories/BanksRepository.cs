using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IBanksRepository
    {
        List<Bank> GetAll();
        Bank Get(int id);
        void Delete(int id);
        void Update(Bank updatedBank);
        void Insert(Bank bank);
    }

    public class BanksRepository: IBanksRepository
    {

        public List<Bank> GetAll()
        {
            List<Bank> banks;
            using (BankContext db = new BankContext())
            {
                banks = db.Banks.ToList();
            }

            return banks;
        }

        public Bank Get(int id)
        {
            Bank bank;
            using (BankContext db = new BankContext())
            {
                bank = db.Banks.Find(id);
            }

            return bank;
        }

        public void Delete(int id)
        {
            using (BankContext db = new BankContext())
            {
                Bank bankToRemove = db.Banks.Find(id);

                if (bankToRemove != null)
                {
                    db.Banks.Remove(bankToRemove);
                    db.SaveChanges();
                }
            }
        }

        public void Insert(Bank bank)
        {
            using (BankContext db = new BankContext())
            {
                db.Banks.Add(bank);
                db.SaveChanges();
            }
        }

        public void Update(Bank updatedBank)
        {
            using (BankContext db = new BankContext())
            {
                db.Banks.Attach(updatedBank);

                db.Entry(updatedBank).State = EntityState.Modified;
                db.SaveChanges();
            }
        }       

    }
}