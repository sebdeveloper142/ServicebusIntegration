using Shared.Models.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public interface IEvaRepository
    {
        public Task UpdateOrderPrice(List<Order> orderList);
    }
}
