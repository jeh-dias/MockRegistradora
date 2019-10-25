using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockRegister.Domain.Entity;

namespace MockRegisterPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockRegisterPaymentController : ControllerBase
    {
        private readonly ILogger<MockRegisterPaymentController> _logger;

        public MockRegisterPaymentController(ILogger<MockRegisterPaymentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método responsável por receber e validar o tipo de pagamento 
        /// e o valor
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetPaymentMethodValid([FromBody] Register register)
        {
            try
            {
                if (register == null)
                    return BadRequest("Requested object is null");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}