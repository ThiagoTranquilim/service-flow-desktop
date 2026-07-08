using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Service_Flow_Desktop.Commands;
using Service_Flow_Desktop.Data;
using Service_Flow_Desktop.Repositories;
using Service_Flow_Desktop.Services;
using Service_Flow_Desktop.Utilities;

namespace Service_Flow_Desktop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ClientesViewModel _clientesViewModel;
        private readonly ServicosViewModel _servicosViewModel;
        private readonly OrdensServicoViewModel _ordensServicoViewModel;
        private readonly OrdemServicoFormViewModel _ordemServicoFormViewModel;

        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowClientesCommand { get; }
        public ICommand ShowServicosCommand { get; }
        public ICommand ShowOrdensServicoCommand { get; }
        public ICommand ShowOrdemServicoFormCommand { get; }

        public MainViewModel()
        {
            var dbContext = new ServiceFlowDbContext();

            dbContext.Database.Migrate();

            var clienteRepository = new ClienteRepository(dbContext);
            var clienteService = new ClienteService(clienteRepository);

            var servicoRepository = new ServicoRepository(dbContext);
            var servicoService = new ServicoService(servicoRepository);

            _clientesViewModel = new ClientesViewModel(clienteService);
            _servicosViewModel = new ServicosViewModel(servicoService);
            _ordensServicoViewModel = new OrdensServicoViewModel();
            _ordemServicoFormViewModel = new OrdemServicoFormViewModel();

            _currentViewModel = _clientesViewModel;

            ShowClientesCommand = new RelayCommand(_ => CurrentViewModel = _clientesViewModel);
            ShowServicosCommand = new RelayCommand(_ => CurrentViewModel = _servicosViewModel);
            ShowOrdensServicoCommand = new RelayCommand(_ => CurrentViewModel = _ordensServicoViewModel);
            ShowOrdemServicoFormCommand = new RelayCommand(_ => CurrentViewModel = _ordemServicoFormViewModel);
        }
    }
}