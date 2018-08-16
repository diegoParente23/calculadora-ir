using FluentValidator;
using System;
using System.Collections.Generic;

namespace CalculadoraIR.Shared.Exceptions
{
    public class InvalidStateException : Exception
    {
        private readonly List<Notification> _errors = new List<Notification>();

        public InvalidStateException(List<Notification> errors)
        {
            _errors = errors;
        }

        public List<Notification> GetErrors()
        {
            return _errors;
        }

        public override string Message => string.Join("\n -", _errors);
    }
}
