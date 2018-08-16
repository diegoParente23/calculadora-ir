using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Infra.Repositories;
using CalculadoraIR.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculadoraIR.Test
{
    [TestClass]
    public class ContribuinteRepositoryTeste
    {
        private readonly Contribuinte _contribuinte;

        public ContribuinteRepositoryTeste()
        {
            Cpf cpf = Cpf.Create("09854146006");
            _contribuinte = Contribuinte.Novo("Diego Parente", cpf, 1500M, 2);
        }

        [TestMethod]
        [TestCategory("Entidades - ContribuinteRepository")]
        public void CadastrarContribuinteComSucesso()
        {
            CalculadoraIRContext.Factory.StartNew().Contribuinte.Criar(_contribuinte);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Entidades - ContribuinteRepository")]
        public void RecuperarContribuintesComSucesso()
        {
            var contribuintes = CalculadoraIRContext.Factory.StartNew().Contribuinte.ObterTodos();

            Assert.IsTrue(contribuintes != null);
        }
    }
}
