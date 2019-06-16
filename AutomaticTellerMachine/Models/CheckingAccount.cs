using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomaticTellerMachine.Models
{
    public class CheckingAccount
    {

        public int Id { get; set; }

        [Required()]
        //[StringLength(10, MinimumLength=6)]        
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Account #")]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Account # must be between 6 and 10 digits")]
        public string AccountNumber { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        //to be overriden by the framework with a mechanism that support a leazy loading of USER object.
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }  
    }
}



//Enable-Migrations -ContextType ApplicationDbContext
//Add-Migration AccountNumberChanges
//Update-Database -Script 
//Update-Database -Verbose
//EnableAutomaticMigrations
