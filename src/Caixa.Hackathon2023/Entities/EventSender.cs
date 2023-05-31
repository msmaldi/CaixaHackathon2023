namespace Caixa.Hackathon2023.Entities;

using System.Text.Json;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Caixa.Hackathon2023.Models;

public class EventSender : IAsyncDisposable
{
    EventHubProducerClient client;

    public EventSender()
    {
        client = new EventHubProducerClient("Endpoint=sb://eventhack.servicebus.windows.net/;SharedAccessKeyName=hack;SharedAccessKey=HeHeVaVqyVkntO2FnjQcs2Ilh/4MUDo4y+AEhKp8z+g=;EntityPath=simulacoes");
    }

    public async Task GravarSimulacaoAsync(SimulacaoDTO simulacao)
    {
        using EventDataBatch eventBatch = await client.CreateBatchAsync();

        var simulacaoJson = JsonSerializer.Serialize(simulacao);

        eventBatch.TryAdd(new EventData(simulacaoJson));
        try
        {
            await client.SendAsync(eventBatch);
        }
        catch
        {
        }
    }

    public ValueTask DisposeAsync()
    {
        return client.DisposeAsync();
    }
}
