namespace Service_Flow_Desktop.Models;

public class OrdemServicoItem
{
    public int Id { get; set; }

    public Servico Servico { get; set; } = new();

    public int Quantidade { get; set; }

    public decimal ValorServico { get; set; }

    public decimal Subtotal
    {
        get
        {
            return Quantidade * ValorServico;
        }
}
}