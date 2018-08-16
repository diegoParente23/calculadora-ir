using CalculadoraIR.Shared.Exceptions;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculadoraIR.Shared.ValueObjects
{
    public abstract class Document : ValueObject<Document>
    {
        public string Number { get; private set; }

        public const string CPF = @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        public const string CPFUnformatted = @"(\d{3})(\d{3})(\d{3})(\d{2})";
        public const string CPFDigitsOnly = @"^\d{11}$";

        public const string CNPJ = @"(\d{2})[.](\d{3})[.](\d{3})\/(\d{4})-(\d{2})";
        public const string CNPJUnformatted = @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";
        public const string CNPJDigitsOnly = @"^\d{14}$";

        public const string TituloEleitoral = @"(\d{10})/(\d{2})";
        public const string TituloEleitoralUnformatted = @"(\d{10})(\d{2})";
        public const string TituloEleitoralDigitsOnly = @"^\d{12}$";

        public const string CEP = @"(\d{5})-(\d{3})";
        public const string CEPUnformatted = @"(\d{5})(\d{3})";
        public const string CEPDigitsOnly = @"^\d{8}$";

        public abstract string RegexFormatted { get; }
        public abstract string RegexUnformatted { get; }
        protected abstract int DocumentLength { get; }
        protected abstract int GetDigitoVerificador(string documentSubstring);
        protected readonly bool isFormatted;

        protected Document(string document)
            : base()
        {
            // Atribui o valor do documento
            Number = document;

            // Retira a formatação do documento.
            var unformattedDocument = UnformatDocument(document);

            // Valida se o valor fornecido é um long
            if (!long.TryParse(unformattedDocument, out long resultado))
                base.AddNotification("Inválido", "Document inválido");

            // Valida o documento.
            Validate();
        }

        protected override bool EqualsCore(Document other)
        {
            if (other is null)
                return false;

            return Number == other.Number;
        }

        protected override int GetHashCodeCore()
        {
            return Number.GetHashCode();
        }

        protected virtual bool CheckCountryState(string document)
        {
            return true;
        }

        protected int GetComplementoDoModuloDe11(int soma)
        {
            return 11 - (soma % 11);
        }

        protected int GetSomaDosProdutos(string documentSubstring, int[] digitos, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < documentSubstring.Count(); i++)
                soma += digitos[i] * multiplicadores[i];
            return soma;
        }

        protected abstract int[] GetMultiplicadores(int[] digitos);

        protected static int[] GetDigitos(string documentSubstring)
        {
            return documentSubstring
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToArray();
        }

        private void GetInvalidValues()
        {
            if (!string.IsNullOrEmpty(Number))
            {
                string unformattedDocument = Number.ToString();
                if (isFormatted)
                {
                    if (!CheckFormattedDocument(Number.ToString()))
                        base.AddNotification("Documento", "Formato inválido");
                }
                unformattedDocument = UnformatDocument(Number.ToString());

                if (!CheckUnformattedDocument(unformattedDocument))
                    base.AddNotification("Documento", "Dígito inválido");
                else if (!CheckMoreThan1DistinctDigit(unformattedDocument))
                    base.AddNotification("Documento", "Dígito repetido");
                else
                {
                    if (!CheckDocumentLength(unformattedDocument))
                        base.AddNotification("Documento", "Dígito inválido");

                    string documentSubstring = unformattedDocument.Substring(0, DocumentLength - 2);

                    int digito1 = GetDigitoVerificador(documentSubstring);
                    int digito2 = GetDigitoVerificador(documentSubstring + digito1.ToString());

                    if (unformattedDocument != documentSubstring + digito1.ToString() + digito2.ToString())
                        base.AddNotification("Documento", "Dígito de verificação inválido");
                }

                if (!CheckCountryState(unformattedDocument))
                    base.AddNotification("Documento", "UF inválida!");
            }
        }

        private bool Validate()
        {
            try
            {
                GetInvalidValues();

                if (base.IsValid())
                    throw new InvalidStateException(base.Notifications.ToList());

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckMoreThan1DistinctDigit(string unformattedDocument)
        {
            return unformattedDocument.ToCharArray().Distinct().Count() > 1;
        }

        private bool CheckDocumentLength(string document)
        {
            return document.Length == DocumentLength;
        }

        private bool CheckFormattedDocument(string formattedDocument)
        {
            Regex regex = new Regex(RegexFormatted);
            return regex.IsMatch(formattedDocument);
        }

        private bool CheckUnformattedDocument(string unformattedDocument)
        {
            Regex regex = new Regex(RegexUnformatted);
            return regex.IsMatch(unformattedDocument);
        }

        private string UnformatDocument(string document)
        {
            return document.Replace(".", "").Replace("-", "").Replace("/", ""); ;
        }
    }
}
