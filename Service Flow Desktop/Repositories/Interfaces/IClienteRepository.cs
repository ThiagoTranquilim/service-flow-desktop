using Service_Flow_Desktop.Models;

namespace Service_Flow_Desktop.Repositories.Interfaces;

public interface IClienteRepository
{
    Task AdicionarAsync(Cliente cliente);

    Task<List<Cliente>> ListagemDeClientesAsync();

    Task AtualizarAsync(Cliente cliente);
}
