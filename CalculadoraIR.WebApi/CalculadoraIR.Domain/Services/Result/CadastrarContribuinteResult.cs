using CalculadoraIR.Shared.Command;
using System;

namespace CalculadoraIR.Domain.Services.Result
{
    public class CadastrarContribuinteResult : ICommandResult
    {
        public Guid Id { get; set; }
    }
}
