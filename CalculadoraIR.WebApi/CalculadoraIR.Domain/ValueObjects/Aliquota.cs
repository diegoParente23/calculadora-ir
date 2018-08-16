using FluentValidator;
using System;

namespace CalculadoraIR.Domain.ValueObjects
{
    public class Aliquota : Shared.ValueObject<Aliquota>
    {
        public decimal Percentual { get; private set; }

        public ushort QtdeDeSalarios { get; private set; }

        private Aliquota(decimal rendaLiquida, decimal salarioMinimo)
        {
            new ValidationContract<Aliquota>(this);

            if (base.IsValid())
            {
                QtdeDeSalarios = Convert.ToUInt16(rendaLiquida / salarioMinimo);

                if (QtdeDeSalarios > 2 && QtdeDeSalarios <= 4)
                    Percentual = 0.075m;
                else if (QtdeDeSalarios == 5)
                    Percentual = 0.15m;
                else if (QtdeDeSalarios > 5 && QtdeDeSalarios <= 7)
                    Percentual = 0.225m;
                else if (QtdeDeSalarios > 7)
                    Percentual = 0.275m;
                else
                    Percentual = 0m;
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
