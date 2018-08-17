using FluentValidator;
using System;

namespace CalculadoraIR.Domain.ValueObjects
{
    public class Aliquota : Shared.ValueObject<Aliquota>
    {
        public decimal Percentual { get; private set; }

        public decimal QtdeDeSalarios { get; private set; }

        private Aliquota(decimal rendaLiquida, decimal salarioMinimo)
        {
            new ValidationContract<Aliquota>(this);

            if (base.IsValid())
            {
                QtdeDeSalarios = rendaLiquida / salarioMinimo;

                if (QtdeDeSalarios < 3)
                    Percentual = 0m;
                else if (QtdeDeSalarios <= 4)
                    Percentual = 0.075m;
                else if (QtdeDeSalarios <= 5)
                    Percentual = 0.15m;
                else if (QtdeDeSalarios <= 7)
                    Percentual = 0.225m;
                else
                    Percentual = 0.275m;
            }
        }

        public static Aliquota Novo(decimal rendaLiquida, decimal salarioMinimo) => new Aliquota(rendaLiquida, salarioMinimo);

        public override string ToString()
        {
            return $"{(Percentual * 100)}%";
        }

        protected override bool EqualsCore(Aliquota other)
        {
            if (other is null)
                return false;

            return Percentual == other.Percentual &&
                QtdeDeSalarios == other.QtdeDeSalarios;
        }

        protected override int GetHashCodeCore()
        {
            return Percentual.GetHashCode();
        }
    }
}
