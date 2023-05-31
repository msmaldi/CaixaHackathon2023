namespace Caixa.Hackathon2023.Api;

using Caixa.Hackathon2023.Entities;
using Caixa.Hackathon2023.Models;

public class SimulacaoApi
{
    public record EntradaSimulacaoDTO(double ValorDesejado, int Prazo);

    public static async Task<IResult> ObterSimulacao(EntradaSimulacaoDTO input, HackDb db, EventSender eventSender)
    {
        var produtos = db.ObterProdutoss();

        var produto = ObterProduto(produtos, input);
        if (produto == null)
        {
            var notFound = new
            {
                Codigo = 400,
                Mensagem = "Não há produtos disponiveis para os parâmetros informados"
            };
            return Results.BadRequest(notFound);
        }

        var simulacao = new SimulacaoDTO(produto.Id, produto.Nome, (double)produto.TaxaJuros);
        simulacao.CalculaResultado(input.ValorDesejado, input.Prazo);

        await eventSender.GravarSimulacaoAsync(simulacao);

        return Results.Ok(simulacao);
    }

    private static Produto? ObterProduto(List<Produto> produtos, EntradaSimulacaoDTO input)
    {
        return produtos
            .Where(p => p.MinimoMeses <= input.Prazo)
            .Where(p => !p.MaximoMeses.HasValue || input.Prazo <= p.MaximoMeses)
            .Where(p => (double)p.Minimo <= input.ValorDesejado)
            .Where(p => !p.Maximo.HasValue || input.ValorDesejado <= (double)(p.Maximo))
            .FirstOrDefault();
    }
}
