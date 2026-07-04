using Service_Flow_Desktop.Models;
using Service_Flow_Desktop.Repositories.Interfaces;

namespace Service_Flow_Desktop.Services;

public class ClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task CadastrarClienteAsync(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new ArgumentException("O nome e obrigatorio");
        }

        await _clienteRepository.AdicionarAsync(cliente);
    }

    public async Task<List<Cliente>> ListarClientesAsync()
    {
        return await _clienteRepository.ListagemDeClientesAsync();
    }

    public async Task AtualizarClienteAsync(Cliente cliente)
    {
        await _clienteRepository.AtualizarAsync(cliente);
    }

    public async Task RemoverClienteAsync(Cliente cliente)
    {
        await _clienteRepository.RemoverAsync(cliente);
    }
}