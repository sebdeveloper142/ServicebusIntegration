using Shared.Client;
using Shared.Models.Receiver;
using Shared.Models.Sender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class EvaRepository(IReceiverClient receiverClient) : IEvaRepository
    {
        private readonly IReceiverClient _receiverClient = receiverClient;
        public async Task UpdateOrderPrice(List<Order> orderList)
        {

            Parallel.ForEach(orderList, order => {
                var evaOrderLineComponents = new List<PurchaseOrderLine>();


                Parallel.ForEach(order.OrderLines, orderLine => {

                    evaOrderLineComponents.Add(new PurchaseOrderLine()
                    {
                        LinePrice = orderLine.ItemPrice,
                        LineReference = orderLine.Reference,
                        TaxReturnApprived = orderLine.TaxReturn
                        

                    }

                        ); ;
                });
                var requestBody = new PurchaseOrder()
                {
                    Identification = order.Id,
                    AffiliateName = "Receiving org",
                    TotalPrice = order.Price,
                    Prices = evaOrderLineComponents

                };

                Console.WriteLine(JsonSerializer.Serialize(requestBody));
                
                var response = _receiverClient.PostAsync<String, PurchaseOrder>("Post",requestBody);

            });


            //Console.WriteLine(evaOrderLineComponents);


            //evaOrderLineComponents.ForEach(Console.WriteLine);

        }
    }

}
