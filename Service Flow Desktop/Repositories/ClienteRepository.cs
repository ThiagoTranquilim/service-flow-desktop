using Service_Flow_Desktop.Repositories.Interfaces;
using Service_Flow_Desktop.Data;
using Service_Flow_Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace Service_Flow_Desktop.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ServiceFlowDbContext _dbContext;

    public ClienteRepository(ServiceFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        _dbContext.Clientes.Add(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Cliente>> ListagemDeClientesAsync()
    {
        return await _dbContext.Clientes.ToListAsync();
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _dbContext.Clientes.Update(cliente);
        await _dbContext.SaveChangesAsync();
    }
}
