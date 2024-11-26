﻿namespace WarehouseManagementApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
