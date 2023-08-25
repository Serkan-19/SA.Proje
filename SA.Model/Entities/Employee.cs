using CommonTypesLayer.Model;

namespace SA.Model.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? City { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
