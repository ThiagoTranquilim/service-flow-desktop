using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Text;
using System.Windows.Input;
using Service_Flow_Desktop.Commands;
using Service_Flow_Desktop.Models;
using Service_Flow_Desktop.Utilities;
using Service_Flow_Desktop.Services;
using System.Data;
using Service_Flow_Desktop.Data;
using Service_Flow_Desktop.Repositories;

namespace Service_Flow_Desktop.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly ClienteService _clienteService;

        private Cliente? _itemSelecionado;
        private bool _isCreateDialogOpen;
        private bool _isEditDialogOpen;
        private bool _isDeleteDialogOpen;

        public ObservableCollection<Cliente> Itens { get; } = new();

        public string NovoClienteNome { get; set; } = string.Empty;
        public string NovoClienteTelefone { get; set; } = string.Empty;
        public string NovoClienteEmail { get; set; } = string.Empty;

        public string ClienteEdicaoNome { get; set; } = string.Empty;
        public string ClienteEdicaoTelefone { get; set; } = string.Empty;
        public string ClienteEdicaoEmail { get; set; } = string.Empty;

        public Cliente? ItemSelecionado
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

        public ICommand SalvarNovoClienteCommand { get; }
        public ICommand CancelarNovoClienteCommand { get; }

        public ICommand SalvarEdicaoClienteCommand { get; }
        public ICommand CancelarEdicaoClienteCommand { get; }

        public ICommand ConfirmarExcluirClienteCommand { get; }
        public ICommand CancelarExcluirClienteCommand { get; }

        public ClientesViewModel(ClienteService clienteService)
        {
            _clienteService = clienteService;

            NovoCommand = new RelayCommand(_ => AbrirCriacao());
            EditarCommand = new RelayCommand(_ => AbrirEdicao(), _ => ItemSelecionado is not null);
            ExcluirCommand = new RelayCommand(_ => AbrirExclusao(), _ => ItemSelecionado is not null);

            SalvarNovoClienteCommand = new RelayCommand(async _ => await SalvarNovoClienteAsync());
            CancelarNovoClienteCommand = new RelayCommand(_ => IsCreateDialogOpen = false);

            SalvarEdicaoClienteCommand = new RelayCommand(async _ => await SalvarEdicaoClienteAsync());
            CancelarEdicaoClienteCommand = new RelayCommand(_ => IsEditDialogOpen = false);

            ConfirmarExcluirClienteCommand = new RelayCommand(async _ => await ExcluirClienteAsync());
            CancelarExcluirClienteCommand = new RelayCommand(_ => IsDeleteDialogOpen = false);

            _ = CarregarClientesAsync();
        }

        private void AbrirCriacao()
        {
            NovoClienteNome = string.Empty;
            NovoClienteTelefone = string.Empty;
            NovoClienteEmail = string.Empty;

            OnPropertyChanged(nameof(NovoClienteNome));
            OnPropertyChanged(nameof(NovoClienteTelefone));
            OnPropertyChanged(nameof(NovoClienteEmail));

            IsCreateDialogOpen = true;
        }

        private void AbrirEdicao()
        {
            if (ItemSelecionado is null)
                return;

            ClienteEdicaoNome = ItemSelecionado.Nome;
            ClienteEdicaoTelefone = ItemSelecionado.Telefone;
            ClienteEdicaoEmail = ItemSelecionado.Email;

            OnPropertyChanged(nameof(ClienteEdicaoNome));
            OnPropertyChanged(nameof(ClienteEdicaoTelefone));
            OnPropertyChanged(nameof(ClienteEdicaoEmail));

            IsEditDialogOpen = true;
        }

        private void AbrirExclusao()
        {
            if (ItemSelecionado is null)
                return;

            IsDeleteDialogOpen = true;
        }

        private async Task SalvarNovoClienteAsync()
        {
            var cliente = new Cliente
            {
                Nome = NovoClienteNome,
                Telefone = NovoClienteTelefone,
                Email = NovoClienteEmail
            };

            await _clienteService.CadastrarClienteAsync(cliente);

            Itens.Add(cliente);
            IsCreateDialogOpen = false;
        }

        private async Task SalvarEdicaoClienteAsync()
        {
            if (ItemSelecionado is null)
                return;

            ItemSelecionado.Nome = ClienteEdicaoNome;
            ItemSelecionado.Telefone = ClienteEdicaoTelefone;
            ItemSelecionado.Email = ClienteEdicaoEmail;

            await _clienteService.AtualizarClienteAsync(ItemSelecionado);

            OnPropertyChanged(nameof(ItemSelecionado));
            IsEditDialogOpen = false;
        }

        private async Task ExcluirClienteAsync()
        {
            if (ItemSelecionado is null)
                return;

            var cliente = ItemSelecionado;

            await _clienteService.RemoverClienteAsync(cliente);

            Itens.Remove(cliente);
            ItemSelecionado = null;
            IsDeleteDialogOpen = false;
        }

        private async Task CarregarClientesAsync()
        {
            Itens.Clear();

            var clientes = await _clienteService.ListarClientesAsync();

            foreach (var cliente in clientes)
                Itens.Add(cliente);
        }
    }
}
