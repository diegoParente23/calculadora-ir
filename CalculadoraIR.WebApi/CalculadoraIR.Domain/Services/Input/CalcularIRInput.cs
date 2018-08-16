using CalculadoraIR.Shared.Command;

namespace CalculadoraIR.Domain.Services.Input
{
    public class CalcularIRInput : ICommandInput
    {
        public decimal SalarioMinimo { get; set; }
    }
}
