namespace CalculadoraIR.Shared.ValueObjects
{
    public class Cpf : PersonDocument
    {
        public override string RegexFormatted => CPF;

        public override string RegexUnformatted => CPFUnformatted;

        protected override int DocumentLength => 11;

        private Cpf(string document)
            : base(document)
        {
        }

        public static Cpf Create(string document) => new Cpf(document);

        protected override int[] GetMultiplicadores(int[] digitos)
        {
            if (digitos.Length == DocumentLength - 2)
                return new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        }

        public override string ToString()
        {
            var text = Number.ToString();

            if (!base.IsValid())
                text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, 3)}-{text.Substring(9)}";

            return text;
        }
    }
}
