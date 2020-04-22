using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.Common;
using AccountingNotebook.Contract.DTO;
using AccountingNotebook.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountingNotebook.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _accountService.GetAllTransactionsAsync();
            if (data != null && data.Any())
            {
                return Ok(data);
            }

            return Ok("No data exists");
        }

        // POST: api/Account
        [HttpPost("transaction/")]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            TransactionResult result;
            if (transaction.Operation < 0)
            {
                result = await _accountService.CreditAccountAsync(transaction);
            }
            else
            {
                result = await _accountService.DebitAccountAsync(transaction);
            }

            return Ok(result);
        }
    }
}
