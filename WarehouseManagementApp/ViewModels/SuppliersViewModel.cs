using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManagementApp.BLL;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.ViewModels
{
    public class SuppliersViewModel : BaseViewModel
    {
        private readonly ISupplierService _supplierService;

        public ObservableCollection<Supplier> Suppliers { get; set; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged();
            }
        }

        public SuppliersViewModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            Suppliers = new ObservableCollection<Supplier>(_supplierService.GetAllSuppliers());

            AddCommand = new RelayCommand(AddSupplier, CanExecute);
            UpdateCommand = new RelayCommand(UpdateSupplier, CanExecute);
            DeleteCommand = new RelayCommand(DeleteSupplier, CanExecute);
        }

        private void AddSupplier()
        {
            _supplierService.AddSupplier("New Supplier", "Contact Info");
            RefreshSuppliers();
        }

        private void UpdateSupplier()
        {
            if (SelectedSupplier != null)
            {
                _supplierService.UpdateSupplier(SelectedSupplier.SupplierId, SelectedSupplier.Name, SelectedSupplier.ContactInfo);
                RefreshSuppliers();
            }
        }

        private void DeleteSupplier()
        {
            if (SelectedSupplier != null)
            {
                _supplierService.DeleteSupplier(SelectedSupplier.SupplierId);
                RefreshSuppliers();
            }
        }

        private void RefreshSuppliers()
        {
            Suppliers.Clear();
            foreach (var supplier in _supplierService.GetAllSuppliers())
            {
                Suppliers.Add(supplier);
            }
        }

        private bool CanExecute()
        {
            return SelectedSupplier != null;
        }
    }
}
