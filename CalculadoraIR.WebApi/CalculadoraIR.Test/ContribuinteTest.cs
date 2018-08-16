using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculadoraIR.Test
{
    [TestClass]
    public class ContribuinteTest
    {
        private readonly string _cpfValido = "09854146006";

        [TestMethod]
        [TestCategory("Entidades - Contribuinte")]
        public void InstanciarContribuinteSucesso()
        {
            Cpf cpf = Cpf.Create(_cpfValido);
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 1500M, 2);

            Assert.IsTrue(contribuinte.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Contribuinte")]
        public void InstanciarContribuinteComCpfInvalidoErro()
        {
            Cpf cpf = Cpf.Create("09854146146");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 1500M, 2);

            Assert.IsFalse(contribuinte.IsValid());
        }

        [TestMethod]
        [TestCategory("Entidades - Contribuinte")]
        public void InstanciarContribuinteSemRendaBrutaMensalaErro()
        {
            Cpf cpf = Cpf.Create(_cpfValido);
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 0M, 2);

            Assert.IsFalse(contribuinte.IsValid());
        }
    }
}
