using CommonTypesLayer.Model;

namespace SA.Model.Entities
{
    public class Customer : IEntity
    {
        public string? CustomerID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }  
        public List<Order>? Orders { get; set; }
    }
}
