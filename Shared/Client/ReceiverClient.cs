using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Security.Cryptography;
using System.Threading;
using System.Data;

namespace Shared.Client
{
    public class ReceiverClient(ILogger<ReceiverClient> logger, HttpClient httpClient) : IReceiverClient
    {


        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<ReceiverClient> _logger = logger;



        public async Task<TResponse> PostAsync<TResponse, TRequest>(string operation, dynamic body)
        {
            _httpClient.DefaultRequestHeaders.Add("EVA-User-Agent", "");
            HttpRequestMessage requestBody = new HttpRequestMessage(new HttpMethod("Post"), "https://07de31db-7997-4b7b-b03c-15b26e59b119.mock.pstmn.io/success");


            if (body != null)
            {
                requestBody.Content = new StringContent(JsonSerializer.Serialize(body));
            }
            var response = await _httpClient.SendAsync(requestBody);


            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"response body{responseBody}");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Response from Eva: {}", responseBody);
                return JsonSerializer.Deserialize<TResponse>(responseBody); ;

            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Not found");
            }
            else
                throw new Exception("Not found");
        }

    }
}
