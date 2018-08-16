namespace CalculadoraIR.Shared.ValueObjects
{
    public abstract class PersonDocument : Document
    {
        protected PersonDocument(string document)
            : base(document)
        {
        }

        protected override int GetDigitoVerificador(string documentSubstring)
        {
            int result = 0;
            int[] digitos = GetDigitos(documentSubstring);
            int subtracao =
                GetComplementoDoModuloDe11(
                    GetSomaDosProdutos(
                        documentSubstring
                        , digitos
                        , GetMultiplicadores(digitos)));

            if (subtracao > 9)
                result = 0;
            else
                result = subtracao;
            return result;
        }
    }
}
