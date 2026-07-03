using Microsoft.EntityFrameworkCore;
using Service_Flow_Desktop.Models;

namespace Service_Flow_Desktop.Data;

public class ServiceFlowDbContext: DbContext
{
    private const string ConnectionString = "Data Source=service-flow.db";

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Servico> Servicos => Set<Servico>();

    public DbSet<OrdemServico> OrdemServicos => Set<OrdemServico>();

    public DbSet<OrdemServicoItem> OrdemServicoItems => Set<OrdemServicoItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString);
    }
}