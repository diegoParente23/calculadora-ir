using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Shared.Command;
using System.Collections.Generic;

namespace CalculadoraIR.Domain.Services.Result
{
    public class CalcularIRResult : ICommandResult
    {
        public List<ImpostaDeRenda> ContribuintesImpostoDeRenda { get; set; } = new List<ImpostaDeRenda>();
    }
}
