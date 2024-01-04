using System;
using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Shared.Client;
using Shared.Models.Sender;
using Shared.Repositories;
namespace ServiceBusIntegration
{
    public class ServicebusExample
    {
        private readonly ILogger<ServicebusExample> _logger;
        private readonly IEvaRepository _evaRepository;
        private readonly IReceiverClient receiverClient;
        public ServicebusExample(ILogger<ServicebusExample> logger, IEvaRepository evaRepository)
        {
            _logger = logger;
            _evaRepository = evaRepository;
        }

        [Function(nameof(ServicebusExample))]
        public async Task Run([ServiceBusTrigger("orders", Connection = "ServiceBusConnection")] ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
           // _logger.LogInformation("Message ID: {id}", message.MessageId);
            //_logger.LogInformation("Message Body: {body}", message.Body);
           // _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            var body = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine("body: "+body);
            List<Order> sbMessages = JsonSerializer.Deserialize <List<Order>>(body);


            if (sbMessages == null) {
                _logger.LogError("The event body is null or empty", body);
                throw new ServiceBusException($"The event body is null or empty {body}", ServiceBusFailureReason.MessageNotFound);
            }
            //sbMessages.ForEach(Console.WriteLine);
            await _evaRepository.UpdateOrderPrice(sbMessages);

        }
    }
}
