using Caixa.Hackathon2023.Models;

namespace Caixa.Hackathon2023
{
    public class Calculadora
    {
        public double ValorPresente { get; private set; }
        public double TaxaJuros { get; private set; }
        public double Meses { get; private set; }
        public Calculadora(double valorPresente, double taxaJuros, int meses)
        {
            ValorPresente = valorPresente;
            TaxaJuros = taxaJuros;
            Meses = meses;
        }

        public List<ParcelaDTO> GerarSac()
        {
            int numero = 1;
            double valorAmortizacao = ValorPresente / Meses;
            double saldoDevedor = ValorPresente;

            var parcelas = new List<ParcelaDTO>();

            for (int i = 0; i < Meses; i++, numero++)
            {
                double valorJuros = saldoDevedor * TaxaJuros;
                double valorPrestacao = valorJuros + valorAmortizacao;
                saldoDevedor -= valorAmortizacao;

                var parcela = new ParcelaDTO(numero, valorAmortizacao, valorJuros, valorPrestacao);
                parcelas.Add(parcela);
            }

            return parcelas;
        }

        public List<ParcelaDTO> GerarPrice()
        {
            var parcelas = new List<ParcelaDTO>();

            int numero = 1;
            double valorPrestacao = (ValorPresente * TaxaJuros) / (1 - (1 / Math.Pow(1 + TaxaJuros, Meses)));
            double saldoDevedor = ValorPresente;

            for (int i = 0; i < Meses; i++, numero++)
            {
                double valorJuros = saldoDevedor * TaxaJuros;
                double valorAmortizacao = valorPrestacao - valorJuros;
                saldoDevedor -= valorAmortizacao;

                var parcela = new ParcelaDTO(numero, valorAmortizacao, valorJuros, valorPrestacao);
                parcelas.Add(parcela);
            }

            return parcelas;
        }
    }
}