using Service_Flow_Desktop.Models;

namespace Service_Flow_Desktop.Repositories.Interfaces;

public interface IServicoRepository
{
    Task AdicionarAsync(Servico servico);

    Task<List<Servico>> ListagemDeServicosAsync();
}
