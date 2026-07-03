namespace Service_Flow_Desktop.Models;

public class Servico
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal ValorBase { get; set; }

    public bool Ativo {  get; set; } = true;
}