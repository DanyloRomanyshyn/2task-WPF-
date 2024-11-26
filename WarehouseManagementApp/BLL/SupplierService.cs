using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;
using System.Collections.Generic;

namespace WarehouseManagementApp.BLL
{
    public class SupplierService : ISupplierService
    {
        private readonly SuppliersRepository _repository;

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _repository.GetAll();
        }


        public SupplierService(SuppliersRepository repository)
        {
            _repository = repository;
        }

        public void AddSupplier(string name, string contactInfo)
        {
            _repository.Add(name, contactInfo);
        }

        public void UpdateSupplier(int supplierId, string name, string contactInfo)
        {
            _repository.Update(supplierId, name, contactInfo);
        }

        public void DeleteSupplier(int supplierId)
        {
            _repository.Delete(supplierId);
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return _repository.GetById(supplierId);
        }
    }


}
