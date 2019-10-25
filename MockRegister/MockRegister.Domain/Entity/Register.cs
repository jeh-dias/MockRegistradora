using System;

namespace MockRegister.Domain.Entity
{
    /// <summary>
    /// Responsável por receber o tipo de pagamento e o valor
    /// </summary>
    public class Register
    {
        public string PaymentMethod { get; set; }
        public int Value { get; set; }
    }
}
