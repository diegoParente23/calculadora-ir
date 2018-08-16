using FluentValidator;
using System;

namespace CalculadoraIR.Shared
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object Entity)
        {
            var EntityComparacao = Entity as Entity;

            if (ReferenceEquals(EntityComparacao, null))
                return false;

            if (ReferenceEquals(this, EntityComparacao))
                return true;

            if (GetType() != EntityComparacao.GetType())
                return false;

            return Id == EntityComparacao.Id;
        }

        public static bool operator ==(Entity entityA, Entity entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity entityA, Entity entityB)
        {
            return !(entityA == entityB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id.ToString()).GetHashCode();
        }
    }
}
