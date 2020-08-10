using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models.Enums
{
    public enum OrderStatus
    {
        @new,
        payment,
        delivery,
        cancelled,
        completed
    }
}
