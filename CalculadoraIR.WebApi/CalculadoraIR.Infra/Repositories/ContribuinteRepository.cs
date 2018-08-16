using System.Collections.Generic;
using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Domain.Repositories;
using CalculadoraIR.Shared.ValueObjects;
using System.Linq;

namespace CalculadoraIR.Infra.Repositories
{
    public sealed class ContribuinteRepository : Repository<Contribuinte>, IContribuinteRepository
    {
        public ContribuinteRepository()
        {
        }

        public void Criar(Contribuinte contribuinte)
        {
            base.Add(contribuinte);
        }

        public Contribuinte ObterPorCpf(Cpf cpf)
        {
            return base.Filter(x => x.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public IEnumerable<Contribuinte> ObterTodos()
        {
            return base.GetAll();
        }
    }
}
