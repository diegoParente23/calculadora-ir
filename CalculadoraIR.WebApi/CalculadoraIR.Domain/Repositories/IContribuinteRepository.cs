using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Shared.ValueObjects;
using System.Collections.Generic;

namespace CalculadoraIR.Domain.Repositories
{
    public interface IContribuinteRepository
    {
        void Criar(Contribuinte contribuinte);

        IEnumerable<Contribuinte> ObterTodos();

        Contribuinte ObterPorCpf(Cpf cpf);
    }
}
