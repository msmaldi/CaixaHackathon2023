using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caixa.Hackathon2023.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal TaxaJuros { get; private set; }
        public short MinimoMeses { get; private set; }
        public short? MaximoMeses { get; private set; }
        public decimal Minimo { get; private set; }
        public decimal? Maximo { get; private set; }

        public Produto(int id, string nome, decimal taxaJuros, short minimoMeses, short? maximoMeses, decimal minimo, decimal? maximo)
        {
            Id = id;
            Nome = nome;
            TaxaJuros = taxaJuros;
            MinimoMeses = minimoMeses;
            MaximoMeses = maximoMeses;
            Minimo = minimo;
            Maximo = maximo;
        }
    }
}