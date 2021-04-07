using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCartsController : ControllerBase
    {
        private ICreditCartService _creditCartService;

        public CreditCartsController(ICreditCartService creditCartService)
        {
            _creditCartService = creditCartService;
        }

        [HttpPost("payment")]
        public IActionResult Payment(CreditCart creditCart)
        {
            var result = _creditCartService.MakePayment(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
