using CommonTypesLayer.Model;

namespace SA.Model.Dtos.Employee
{
    public class EmployeePutDto : IDto
    {
        public int IsciNo { get; set; }
        public string IscininAdi { get; set; }
        public string IscininSoyadi { get; set; }
        public string? IscininSehiri { get; set; }
        public DateTime? IscininDogumTarihi { get; set; }
        public string? GemiAdi { get; set; }
        public DateTime? GemiCikisTarihi { get; set; }
    }
}
