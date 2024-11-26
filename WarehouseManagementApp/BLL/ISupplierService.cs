using System.Collections.Generic;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.BLL
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();

        void AddSupplier(string name, string contactInfo);
        void UpdateSupplier(int supplierId, string name, string contactInfo);
        void DeleteSupplier(int supplierId);
        Supplier GetSupplierById(int supplierId);
    }


}
