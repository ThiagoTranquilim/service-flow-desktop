using System.Windows.Input;
using Service_Flow_Desktop.Commands;
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
            _clientesViewModel = new ClientesViewModel();
            _servicosViewModel = new ServicosViewModel();
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