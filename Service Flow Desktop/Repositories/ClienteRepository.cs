using Service_Flow_Desktop.Repositories.Interfaces;
using Service_Flow_Desktop.Data;
using Service_Flow_Desktop.Models;

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
}
