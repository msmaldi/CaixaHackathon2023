namespace Caixa.Hackathon2023.Entities;

using Microsoft.Data.SqlClient;

public class HackDb : IDisposable
{
    SqlConnection connection;
    public HackDb(string connectionString)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public void Dispose()
    {
        connection.Close();
    }

    public List<Produto> ObterProdutoss()
    {
        var produtos = new List<Produto>();
        try
        {
            var sql = "SELECT [CO_PRODUTO],[NO_PRODUTO],[PC_TAXA_JUROS],[NU_MINIMO_MESES],[NU_MAXIMO_MESES],[VR_MINIMO],[VR_MAXIMO] FROM [dbo].[PRODUTO]";
            using (var command = new SqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        decimal taxaJuros = reader.GetDecimal(2);
                        short minimoMeses = reader.GetInt16(3);
                        short? maximoMeses = reader.IsDBNull(4) ? null : reader.GetInt16(4);
                        decimal minimo = reader.GetDecimal(5);
                        decimal? maximo = reader.IsDBNull(6) ? null : reader.GetDecimal(6);
                        var produto = new Produto(id, nome, taxaJuros, minimoMeses, maximoMeses, minimo, maximo);
                        produtos.Add(produto);
                    }
                }
            }
            return produtos;
        }
        catch
        {
            return produtos;
        }
    }
}