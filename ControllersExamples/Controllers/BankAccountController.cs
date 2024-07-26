using ControllersExamples.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExamples.Controllers
{
    public class BankAccountController : Controller
    {
        
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }
        [Route("account-details")]
        [HttpGet]
        public JsonResult GetAccountDetails()
        {
            var bankAccounts = BankAccount.GetDummyData();
            var bankAccount = bankAccounts.FirstOrDefault(a => a.AccountNumber == 1001);
            return Json(bankAccount);
        }

        [Route("account-statement")]
        [HttpGet]
        public FileResult GetAccountStatment()
        {            
            return File("/Assem.pdf", "application/PDF");
        }

        [Route("get-current-balance")]
        [HttpGet]
        public IActionResult GetAccountBalacnce()
        {   
            if (!Request.Query.ContainsKey("accountNumber"))
            {                
                return BadRequest("Account Number is not supplied");
            }
            var id = Request.Query["accountNumber"];
            if (string.IsNullOrEmpty(id.ToString()))
            {               
                return BadRequest("Account Number cant be null or empty");
            }
            if (Convert.ToInt32(id) != 1001)
            {
                return NotFound("Account Number should be 1001");

            }
            var balance = BankAccount.GetDummyData().
                FirstOrDefault(a => a.AccountNumber == Convert.ToInt32(id))?.CurrentBalance;
            return Content(balance == null? "" : balance.ToString());
        }
    }
}
