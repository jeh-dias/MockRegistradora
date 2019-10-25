using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MockRegister.Domain.Entity;

namespace MockRegister.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class MockRegisterController : ControllerBase
    {

        private readonly ILogger<MockRegisterController> _logger;

        public MockRegisterController(ILogger<MockRegisterController> logger)
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
                    return NotFound("Requested object is null");

                if (!ModelState.IsValid)
                    return NotFound(ModelState);

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
