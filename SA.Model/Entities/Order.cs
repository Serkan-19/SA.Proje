using CommonTypesLayer.Model;

namespace SA.Model.Entities
{
    public class Order : IEntity
    {


        public int OrderID { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? ShipName { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }

    }
}
