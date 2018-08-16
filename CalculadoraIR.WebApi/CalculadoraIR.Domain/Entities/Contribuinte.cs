using System;
using CalculadoraIR.Shared;
using CalculadoraIR.Shared.ValueObjects;
using FluentValidator;

namespace CalculadoraIR.Domain.Entities
{
    public sealed class Contribuinte : Entity
    {
        public string Nome { get; private set; }

        public Cpf Cpf { get; private set; }

        public ushort NumeroDeDependentes { get; private set; }

        public decimal RendaBrutaMensal { get; private set; }

        private Contribuinte(string nome, Cpf cpf, decimal rendaBrutaMensal)
            : this(nome, cpf, rendaBrutaMensal, 0)
        {
        }

        private Contribuinte(string nome, Cpf cpf, decimal rendaBrutaMensal, ushort numeroDeDependentes)
            : base()
        {
            Nome = nome;
            Cpf = cpf;
            NumeroDeDependentes = numeroDeDependentes;
            RendaBrutaMensal = rendaBrutaMensal;

            new ValidationContract<Contribuinte>(this)
                .IsRequired(x => x.Nome)
                .IsGreaterThan(x => x.RendaBrutaMensal, 1)
                .IsNotNull(Cpf, "O cpf não pode ser vazio");

            // Adiciona as notificações do cpf ao objeto contribuinte.
            if(Cpf != null)
                base.AddNotifications(Cpf.Notifications);
        }

        public static Contribuinte Novo(string nome, Cpf cpf, decimal rendaBrutaMensal, ushort numeroDeDependentes)
            => new Contribuinte(nome, cpf, rendaBrutaMensal, numeroDeDependentes);
    }
}
