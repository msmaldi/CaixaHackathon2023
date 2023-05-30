using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caixa.Hackathon2023.Models
{
    public class ParcelaDTO
    {
        public int Numero { get; }
        public double ValorAmortizacao { get; }
        public double ValorJuros { get; }
        public double ValorPrestacao { get; }

        public ParcelaDTO(int numero, double valorAmortizacao, double valorJuros, double valorPrestacao)
        {
            Numero = numero;
            ValorAmortizacao = valorAmortizacao;
            ValorJuros = valorJuros;
            ValorPrestacao = valorPrestacao;
        }
    }
}