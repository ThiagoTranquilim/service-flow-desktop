using Service_Flow_Desktop.Models;

namespace Service_Flow_Desktop.Repositories.Interfaces;

public interface IClienteRepository
{
    Task AdicionarAsync(Cliente cliente);

    Task<List<Cliente>> ListagemDeClientesAsync();

    Task<Cliente?> ObterClientePorIdAsync(int id);

    Task AtualizarAsync(Cliente cliente);

    Task RemoverAsync(Cliente cliente);
}
