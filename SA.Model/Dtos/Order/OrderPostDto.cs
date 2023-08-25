using CommonTypesLayer.Model;

namespace SA.Model.Dtos.Order
{
    public class OrderPostDto : IDto
    {
        public int EmirNo { get; set; }
        public string? GemiAdi { get; set; }
        public DateTime? GemiCikisTarihi { get; set; }
        public string? SirketAdi { get; set; }
        public string? IscininAdi { get; set; }
        public string? IscininSoyadi { get; set; }
    }
}