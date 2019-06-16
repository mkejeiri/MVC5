using AutomaticTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomaticTellerMachine.Services
{
    public class CheckingAccountService
    {
        private IApplicationDbContext db;
                
        public CheckingAccountService(IApplicationDbContext context)
        {
            db = context;
        }


        public CheckingAccountService( ApplicationDbContext dbContext) 
        {
            db = dbContext;        
        }

        public void CreateCheckingAccount(string firstName, string lastName, string userId, decimal initialBalance) 
        {
            //var db = new ApplicationDbContext();
            var accountNumber = (123456 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');
            var checkingAccount = new CheckingAccount { FirstName = firstName, LastName =lastName, AccountNumber = accountNumber, Balance = initialBalance, ApplicationUserId = userId };
            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();       
        
        }

        public void UpdateBalance(int checkingAccountId)
        {
            var checkingAccount = db.CheckingAccounts.Where(c => c.Id == checkingAccountId).FirstOrDefault();
            checkingAccount.Balance = db.Transactions.Where(x => x.CheckingAccountId == checkingAccountId).Sum(y=>y.Amount);
            db.SaveChanges();
        }
         
    }
}