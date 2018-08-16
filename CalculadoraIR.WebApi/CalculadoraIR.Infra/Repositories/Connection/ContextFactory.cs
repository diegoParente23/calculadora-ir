using CalculadoraIR.Infra.Repositories.Interfaces;
using System;

namespace CalculadoraIR.Infra.Repositories.Connection
{
    public class ContextFactory<T>
        where T : IContext
    {
        public T StartNew()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
