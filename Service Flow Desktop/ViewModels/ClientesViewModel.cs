using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Service_Flow_Desktop.Commands;
using Service_Flow_Desktop.Models;
using Service_Flow_Desktop.Utilities;

namespace Service_Flow_Desktop.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        public ObservableCollection<Cliente> Itens { get; } = new();

        private Cliente? _itemsSelecionado;

        public bool IsAdicionarClienteAberto { get; set; }

        public string NovoClienteNome { get; set; } = string.Empty;
        public string NovoClienteTelefone { get; set; } = string.Empty;
        public string NovoClienteEmail { get; set; } = string.Empty;
        public string ClienteEdicaoNome {  get; set; } = string.Empty;
        public string ClienteEdicaoTelefone { get; set; } = string.Empty;
        public string ClienteEdicaoEmail { get; set; } = string.Empty;

        public ICommand NovoCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand ExcluirCommand { get; }

        // Create
        public bool IsCreateDialogOpen { get; set; }
        public ICommand AbrirCreateDialogCommand { get; }
        public ICommand SalvarNovoClienteCommand { get; }
        public ICommand CancelarNovoClienteCommand { get; }

        // Edit
        public bool IsEditDialogOpen { get; set; }
        public ICommand AbrirEditDialogCommand { get; }
        public ICommand SalvarEdicaoClienteCommand { get; }
        public ICommand CancelarEdicaoClienteCommand { get; }

        // Delete
        public bool IsDeleteDialogOpen { get; set; }
        public ICommand AbrirDeleteDialogCommand { get; }
        public ICommand ConfirmarExcluirClienteCommand { get; }
        public ICommand CancelarExcluirClienteCommand { get; }

        public Cliente? ItemSelecionado
        {
            get => _itemsSelecionado;
            set
            {
                _itemsSelecionado = value;
                OnPropertyChanged();
            }
        }

        public ClientesViewModel()
        {
            NovoCommand = new RelayCommand(_ => 
            {
                NovoClienteNome = string.Empty;
                NovoClienteTelefone = string.Empty;
                NovoClienteEmail = string.Empty;

                IsCreateDialogOpen = true;

                OnPropertyChanged(nameof(NovoClienteNome));
                OnPropertyChanged(nameof(NovoClienteTelefone));
                OnPropertyChanged(nameof(NovoClienteEmail));
                OnPropertyChanged(nameof(IsCreateDialogOpen));
            });

            EditarCommand = new RelayCommand(_ =>
            {
                if (ItemSelecionado is null)
                    return;

                ClienteEdicaoNome = ItemSelecionado.Nome;
                ClienteEdicaoTelefone = ItemSelecionado.Telefone;
                ClienteEdicaoEmail = ItemSelecionado.Email;

                IsEditDialogOpen = true;

                OnPropertyChanged(nameof(ClienteEdicaoNome));
                OnPropertyChanged(nameof(ClienteEdicaoTelefone));
                OnPropertyChanged(nameof(ClienteEdicaoEmail));
                OnPropertyChanged(nameof(IsEditDialogOpen));
            });

            ExcluirCommand = new RelayCommand(_ =>
            {
                if (ItemSelecionado is null)
                    return;

                IsDeleteDialogOpen = true;
                OnPropertyChanged(nameof(IsDeleteDialogOpen));
            });

            SalvarNovoClienteCommand = new RelayCommand(_ => { });

            CancelarNovoClienteCommand = new RelayCommand(_ =>
            {
                IsCreateDialogOpen = false;
                OnPropertyChanged(nameof(IsCreateDialogOpen));
            });

            CancelarEdicaoClienteCommand = new RelayCommand(_ =>
            {
                IsEditDialogOpen = false;
                OnPropertyChanged(nameof(IsEditDialogOpen));
            });

            CancelarExcluirClienteCommand = new RelayCommand(_ =>
            {
                IsDeleteDialogOpen = false;
                OnPropertyChanged(nameof(IsDeleteDialogOpen));
            });

            Itens.Add(new Cliente { Id = 1, Nome = "Thiago", Telefone = "(19)9999-9999", Email = "email@gmail.com"});
            Itens.Add(new Cliente { Id = 2, Nome = "Thiago 2", Telefone = "(19)1234-5678", Email = "email2@gmail.com"});
        }
    }
}
