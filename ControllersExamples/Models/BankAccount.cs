using System.ComponentModel.DataAnnotations;

namespace ControllersExamples.Models
{
    public class BankAccount
    {
        public long AccountNumber { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        public decimal CurrentBalance { get; set; }

        public static List<BankAccount> GetDummyData()
        {
            return new List<BankAccount>
            {
                new BankAccount { AccountNumber = 1, AccountHolderName = "Client 1", CurrentBalance = 0 },
                new BankAccount { AccountNumber = 2, AccountHolderName = "Client 2", CurrentBalance = 0 },
                new BankAccount { AccountNumber = 3, AccountHolderName = "Client 3", CurrentBalance = 0 },
                new BankAccount { AccountNumber = 4, AccountHolderName = "Client 4", CurrentBalance = 0 },
                new BankAccount { AccountNumber = 1001, AccountHolderName = "Client 5", CurrentBalance = 5000 }
            };
        }
    }
}
