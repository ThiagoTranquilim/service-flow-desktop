namespace Service_Flow_Desktop.Models;

public class OrdemServico
{
    public int Id { get; set; }

    public Cliente Cliente { get; set; } = new();

    public DateTime DataAbertura { get; set; } = DateTime.Now;

    public DateTime? DataConclusao { get; set; }

    public StatusOrdemServico Status { get; set; } = StatusOrdemServico.Aberta;
    
    public List<OrdemServicoItem> Itens { get; set; } = new();

    public decimal Total
    {
        get
        {
            return Itens.Sum(item => item.Subtotal);
        }
    }
}