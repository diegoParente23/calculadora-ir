using CalculadoraIR.Shared.Command;

namespace CalculadoraIR.Domain.Services.Input
{
    public class CadastrarContribuinteInput : ICommandInput
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public ushort NumeroDeDependentes { get; set; }

        public decimal RendaBrutaMensal { get; set; }
    }
}
