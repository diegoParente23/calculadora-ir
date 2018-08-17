using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Shared.Command;
using System.Collections.Generic;

namespace CalculadoraIR.Domain.Services.Result
{
    public class CalcularIRResult : ICommandResult
    {
        public List<ImpostoDeRenda> ContribuintesImpostoDeRenda { get; set; } = new List<ImpostoDeRenda>();
    }
}
