
using Service_Flow_Desktop.Models;
using Service_Flow_Desktop.Repositories;
using Service_Flow_Desktop.Repositories.Interfaces;

namespace Service_Flow_Desktop.Services;

public class ServicoService
{
    private readonly IServicoRepository _servicoRepository;

    public ServicoService(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task CadastrarServicoAsync(Servico servico)
    {
        if (string.IsNullOrWhiteSpace(servico.Nome))
        {
            throw new ArgumentException("O nome e obrigatorio");
        }

        if (string.IsNullOrWhiteSpace(servico.Descricao))
        {
            throw new ArgumentException("A descricao e obrigatoria");
        }

        if (servico.ValorBase <= 0)
        {
            throw new ArgumentException("O valor deve ser maior que 0");
        }
        
        await _servicoRepository.AdicionarAsync(servico);
    }

    public async Task<List<Servico>> ListarServicosAsync()
    {
        return await _servicoRepository.ListagemDeServicosAsync();
    }

    public async Task AtualizarServicoAsync(Servico servico)
    {
        await _servicoRepository.AtualizarAsync(servico);
    }
}
