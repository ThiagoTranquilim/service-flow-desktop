using Service_Flow_Desktop.Commands;
using Service_Flow_Desktop.Models;
using Service_Flow_Desktop.Services;
using Service_Flow_Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Service_Flow_Desktop.ViewModels
{
    public class ServicosViewModel : BaseViewModel
    {

        private readonly ServicoService _servicoService;

        private Servico? _itemSelecionado;
        private bool _isCreateDialogOpen;
        private bool _isEditDialogOpen;
        private bool _isDeleteDialogOpen;

        public ObservableCollection<Servico> Itens { get; } = new();

        public string NovoServicoNome { get; set; } = string.Empty;
        public string NovoServicoDescricao { get; set; } = string.Empty;
        public decimal NovoServicoValorBase { get; set; }
        public bool NovoServicoAtivo { get; set; }

        public string ServicoEdicaoNome { get; set; } = string.Empty;
        public string ServicoEdicaoDescricao { get; set; } = string.Empty;
        public decimal ServicoEdicaoValorBase { get; set; }
        public bool ServicoEdicaoAtivo { get; set; }

        public Servico? ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                _itemSelecionado = value;
                OnPropertyChanged();
            }
        }

        public bool IsCreateDialogOpen
        {
            get => _isCreateDialogOpen;
            set
            {
                _isCreateDialogOpen = value;
                OnPropertyChanged();
            }
        }

        public bool IsEditDialogOpen
        {
            get => _isEditDialogOpen;
            set
            {
                _isEditDialogOpen = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeleteDialogOpen
        {
            get => _isDeleteDialogOpen;
            set
            {
                _isDeleteDialogOpen = value;
                OnPropertyChanged();
            }
        }

        public ICommand NovoCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public ICommand SalvarNovoServicoCommand { get; }
        public ICommand CancelarNovoServicoCommand { get; }

        public ICommand SalvarEdicaoServicoCommand { get; }
        public ICommand CancelarEdicaoServicoCommand { get; }

        public ICommand ConfirmarExcluirServicoCommand { get; }
        public ICommand CancelarExcluirServicoCommand { get; }

        public ServicosViewModel(ServicoService servicoService)
        {
            _servicoService = servicoService;

            NovoCommand = new RelayCommand(_ => AbrirCriacao());
            EditarCommand = new RelayCommand(_ => AbrirEdicao(), _ => ItemSelecionado is not null);
            ExcluirCommand = new RelayCommand(_ => AbrirExclusao(), _ => ItemSelecionado is not null);

            SalvarNovoServicoCommand = new RelayCommand(async _ => await SalvarNovoServicoAsync());
            CancelarNovoServicoCommand = new RelayCommand(_ => IsCreateDialogOpen = false);

            SalvarEdicaoServicoCommand = new RelayCommand(async _ => await SalvarEdicaoServicoAsync());
            CancelarEdicaoServicoCommand = new RelayCommand(_ => IsEditDialogOpen = false);

            ConfirmarExcluirServicoCommand = new RelayCommand(async _ => await ExcluirServicoAsync());
            CancelarExcluirServicoCommand = new RelayCommand(_ => IsDeleteDialogOpen = false);

            _ = CarregarServicosAsync();
        }

        private void AbrirCriacao()
        {
            NovoServicoNome = string.Empty;
            NovoServicoDescricao = string.Empty;

            OnPropertyChanged(nameof(NovoServicoNome));
            OnPropertyChanged(nameof(NovoServicoDescricao));
            OnPropertyChanged(nameof(NovoServicoValorBase));
            OnPropertyChanged(nameof(NovoServicoAtivo));

            IsCreateDialogOpen = true;
        }

        private void AbrirEdicao()
        {
            if (ItemSelecionado is null)
                return;

            ServicoEdicaoNome = ItemSelecionado.Nome;
            ServicoEdicaoDescricao = ItemSelecionado.Descricao;
            ServicoEdicaoValorBase = ItemSelecionado.ValorBase;
            ServicoEdicaoAtivo = ItemSelecionado.Ativo;

            OnPropertyChanged(nameof(NovoServicoNome));
            OnPropertyChanged(nameof(NovoServicoDescricao));
            OnPropertyChanged(nameof(NovoServicoValorBase));
            OnPropertyChanged(nameof(NovoServicoAtivo));

            IsEditDialogOpen = true;
        }

        private void AbrirExclusao()
        {
            if (ItemSelecionado is null)
                return;

            IsDeleteDialogOpen = true;
        }

        private async Task SalvarNovoServicoAsync()
        {
            var servico = new Servico
            {
                Nome = NovoServicoNome,
                Descricao = NovoServicoDescricao,
                ValorBase = NovoServicoValorBase,
                Ativo = NovoServicoAtivo
            };

            await _servicoService.CadastrarServicoAsync(servico);

            Itens.Add(servico);
            IsCreateDialogOpen = false;
        }

        private async Task SalvarEdicaoServicoAsync()
        {
            if (ItemSelecionado is null)
                return;

            ItemSelecionado.Nome = ServicoEdicaoNome;
            ItemSelecionado.Descricao = ServicoEdicaoDescricao;
            ItemSelecionado.ValorBase = ServicoEdicaoValorBase;
            ItemSelecionado.Ativo = ServicoEdicaoAtivo;

            await _servicoService.AtualizarServicoAsync(ItemSelecionado);

            OnPropertyChanged(nameof(ItemSelecionado));
            IsEditDialogOpen = false;
        }

        private async Task ExcluirServicoAsync()
        {
            if (ItemSelecionado is null)
                return;

            var servico = ItemSelecionado;

            await _servicoService.RemoverServicoAsync(servico);

            Itens.Remove(servico);
            ItemSelecionado = null;
            IsDeleteDialogOpen = false;
        }

        private async Task CarregarServicosAsync()
        {
            Itens.Clear();

            var servicos = await _servicoService.ListarServicosAsync();

            foreach (var servico in servicos)
                Itens.Add(servico);
        }

    }
}
