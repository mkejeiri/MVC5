using System.ComponentModel.DataAnnotations;

namespace AutomaticTellerMachine.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

         [Required]
        public int CheckingAccountId { get; set; }
        public virtual CheckingAccount checkingAccount { get; set; }
    }
}