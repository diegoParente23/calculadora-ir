using FluentValidator;

namespace CalculadoraIR.Shared
{
    public abstract class ValueObject<T>
        : Notifiable where T : ValueObject<T>
    {
        public ValueObject()
            : base()
        {
        }

        public override bool Equals(object objetoDeValor)
        {
            var objDeValor = objetoDeValor as T;

            if (ReferenceEquals(objDeValor, null))
                return false;

            return EqualsCore(objDeValor);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public static bool operator ==(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            if (ReferenceEquals(objetoA, null) && ReferenceEquals(objetoB, null))
                return true;

            if (ReferenceEquals(objetoA, null) || ReferenceEquals(objetoB, null))
                return false;

            return objetoA.Equals(objetoB);
        }

        public static bool operator !=(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            return !(objetoA == objetoB);
        }

        protected abstract int GetHashCodeCore();

        protected abstract bool EqualsCore(T other);
    }
}
