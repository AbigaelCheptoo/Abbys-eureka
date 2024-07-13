using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WbApi.Models;

namespace WbApi.Controllers
{
    [Route("api/BankAccount")]
    [ApiController] 
    public class BankAccountController : Controller
    {
        private readonly APIDBContext _context;

        public BankAccountController(APIDBContext context)
        {
            _context = context;
        }

        // GET: BankAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            var bankAccounts = await _context.BankAccounts.ToListAsync();
            return Ok(bankAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return Ok(bankAccount);
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> CreateBankAccount(BankAccount bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.BankAccountID }, bankAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(int id, BankAccount updatedBankAccount)
        {
            if (id != updatedBankAccount.BankAccountID)
            {
                return BadRequest();
            }

            _context.Entry(updatedBankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccounts.Any(e => e.BankAccountID == id);
        }
    }
}
