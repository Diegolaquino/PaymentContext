using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Shared
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
