using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Entities
{
    class Subscription
    {
        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public bool Active { get; set; }
    }
}
