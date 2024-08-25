using ExamBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamBank.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ExamBankContext _examBank;

        public UserController(ExamBankContext examBank) 
        {

            _examBank = examBank;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
           var user= await _examBank.Users.ToListAsync();
            return Ok(user);
        }
    }
}
