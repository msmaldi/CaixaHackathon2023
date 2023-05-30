using Caixa.Hackathon2023;

namespace Caixa.Hackathon2023.Models
{
    public class SimulacaoDTO
    {
        public int CodigoProduto { get; private set; }
        public string? DescricaoProduto { get; private set; }
        public double TaxaJuros { get; private set; }

        public List<ResultadoSimulacaoDTO> ResultadoSimulacao { get; private set; }

        public SimulacaoDTO(int codigoProduto, string? descricaoProduto, double taxaJuros)
        {
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            TaxaJuros = taxaJuros;
            ResultadoSimulacao = new List<ResultadoSimulacaoDTO>();
        }

        public void CalculaResultado(double valorPresente, int meses)
        {
            var calc = new Calculadora(valorPresente, TaxaJuros, meses);

            var price = new ResultadoSimulacaoDTO("Price", calc.GerarPrice());
            ResultadoSimulacao.Add(price);

            var sac = new ResultadoSimulacaoDTO("SAC", calc.GerarSac());
            ResultadoSimulacao.Add(sac);
        }
    }
}