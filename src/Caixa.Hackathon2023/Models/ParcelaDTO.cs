namespace Caixa.Hackathon2023.Models;

public class ParcelaDTO
{
    public int Numero { get; }
    public double ValorAmortizacao { get; }
    public double ValorJuros { get; }
    public double ValorPrestacao { get; }

    public ParcelaDTO(int numero, double valorAmortizacao, double valorJuros, double valorPrestacao)
    {
        Numero = numero;
        ValorAmortizacao = Math.Round(valorAmortizacao, 2);
        ValorJuros = Math.Round(valorJuros, 2);
        ValorPrestacao = Math.Round(valorPrestacao, 2);
    }
}
