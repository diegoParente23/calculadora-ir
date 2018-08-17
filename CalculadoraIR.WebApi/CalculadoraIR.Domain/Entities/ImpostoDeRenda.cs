using CalculadoraIR.Domain.ValueObjects;
using CalculadoraIR.Shared;
using FluentValidator;

namespace CalculadoraIR.Domain.Entities
{
    public sealed class ImpostoDeRenda : Aggregated
    {
        public Contribuinte Contribuinte { get; private set; }

        public Aliquota Aliquota { get; private set; }

        public decimal SalarioMinimo { get; private set; }

        public decimal Imposto => Calcular();

        private ImpostoDeRenda(Contribuinte contribuinte, decimal salarioMinimo)
        {
            // Armazena os valores
            Contribuinte = contribuinte;
            SalarioMinimo = salarioMinimo;

            // Instancia a validação
            new ValidationContract<ImpostoDeRenda>(this)
                .IsGreaterThan(x => x.SalarioMinimo, 1)
                .IsNotNull(Contribuinte, "O contribuinte não pode ser vazio");

            // Verifica se o contribuinte não está vazio
            if (base.IsValid())
            {
                // Cria a aliquota para o contribuinte
                Aliquota = Aliquota.Novo(CalcularRendaLiquida(), SalarioMinimo);

                // Adiciona as notificações da aliquota e do contribuinte.
                base.AddNotifications(Contribuinte.Notifications);
                base.AddNotifications(Aliquota.Notifications);
            }
        }

        public static ImpostoDeRenda Novo(Contribuinte contribuinte, decimal salarioMinimo)
            => new ImpostoDeRenda(contribuinte, salarioMinimo);

        private decimal Calcular()
        {
            return CalcularRendaLiquida() * Aliquota.Percentual;
        }

        private decimal CalcularRendaLiquida()
        {
            return Contribuinte.RendaBrutaMensal - ((SalarioMinimo * 0.05m) * Contribuinte.NumeroDeDependentes);
        }
    }
}
