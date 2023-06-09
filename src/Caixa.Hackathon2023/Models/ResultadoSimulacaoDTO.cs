namespace Caixa.Hackathon2023.Models;

public class ResultadoSimulacaoDTO
{
    public string? Tipo { get; }
    public List<ParcelaDTO> Parcelas { get; }

    public ResultadoSimulacaoDTO(string? tipo, List<ParcelaDTO> parcelas)
    {
        Tipo = tipo;
        Parcelas = parcelas;
    }
}
