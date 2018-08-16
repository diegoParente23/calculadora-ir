using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculadoraIR.Test
{
    [TestClass]
    public class ImpostoDeRendaTest
    {
        private readonly decimal _salarioMinimo = 985M;

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaIsentoValido()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 1500M, 2);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, 985m);

            Assert.IsTrue(impostaDeRenda.IsValid());
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaSeteEMeioPorcentoValido()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 3940M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.IsTrue(impostaDeRenda.IsValid());
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaQuinzePorcentoValido()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 4925M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.IsTrue(impostaDeRenda.IsValid());
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaVinteEDoisEMeioPorcentoValido()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 6895M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.IsTrue(impostaDeRenda.IsValid());
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaVinteESeteEMeioPorcentoValido()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 10000M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.IsTrue(impostaDeRenda.IsValid());
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaIsentoComSucesso()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 1500M, 2);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, 985m);

            Assert.AreEqual(impostaDeRenda.Aliquota.Percentual, 0M);
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaSeteEMeioPorcentoComSucesso()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 3940M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.AreEqual(impostaDeRenda.Aliquota.Percentual, 0.075M);
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaQuinzePorcentoComSucesso()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 4925M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.AreEqual(impostaDeRenda.Aliquota.Percentual, 0.15M);
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaVinteEDoisEMeioPorcentoComSucesso()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 6895M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.AreEqual(impostaDeRenda.Aliquota.Percentual, 0.225M);
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaVinteESeteEMeioPorcentoComSucesso()
        {
            Cpf cpf = Cpf.Create("09854146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 10000M, 1);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, _salarioMinimo);

            Assert.AreEqual(impostaDeRenda.Aliquota.Percentual, 0.275M);
        }

        [TestMethod]
        [TestCategory("Agregados - ImpostoDeRenda")]
        public void CalcularImpostoDeRendaComContribuinteInvalidoErro()
        {
            Cpf cpf = Cpf.Create("09857146006");
            Contribuinte contribuinte = Contribuinte.Novo("Diego Parente", cpf, 0M, 2);
            ImpostaDeRenda impostaDeRenda = ImpostaDeRenda.Novo(contribuinte, 985m);

            Assert.IsFalse(impostaDeRenda.IsValid());
        }
    }
}
