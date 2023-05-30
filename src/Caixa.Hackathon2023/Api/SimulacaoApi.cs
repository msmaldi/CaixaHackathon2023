using Caixa.Hackathon2023.Entities;
using Caixa.Hackathon2023.Models;

namespace Caixa.Hackathon2023.Api
{
    public class SimulacaoApi
    {
        public record EntradaSimulacaoDTO(double ValorDesejado, int Prazo);

        public static SimulacaoDTO ObterSimulacao(EntradaSimulacaoDTO input, HackDb db)
        {
            var produtos = db.ObterProdutoss();
            var p = produtos[0];
            // TODO: validar produto valido

            var simulacao = new SimulacaoDTO(p.Id, p.Nome, (double)p.TaxaJuros);
            simulacao.CalculaResultado(input.ValorDesejado, input.Prazo);

            return simulacao;
        }
    }
}