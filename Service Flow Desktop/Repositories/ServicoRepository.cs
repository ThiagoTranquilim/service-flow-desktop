using Service_Flow_Desktop.Repositories.Interfaces;
using Service_Flow_Desktop.Data;
using Service_Flow_Desktop.Models;
using Microsoft.EntityFrameworkCore;

namespace Service_Flow_Desktop.Repositories;

public class ServicoRepository: IServicoRepository
{
    private readonly ServiceFlowDbContext _dbContext;

    public ServicoRepository(ServiceFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(Servico servico)
    {
        _dbContext.Servicos.Add(servico);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Servico>> ListagemDeServicosAsync()
    {
        return await _dbContext.Servicos.ToListAsync();
    }

    public async Task AtualizarAsync(Servico servico)
    {
        _dbContext.Servicos.Update(servico);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverAsync(Servico servico)
    {
        _dbContext.Servicos.Remove(servico);
        await _dbContext.SaveChangesAsync();
    }
}
