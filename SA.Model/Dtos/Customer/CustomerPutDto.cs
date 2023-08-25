﻿using CommonTypesLayer.Model;

namespace SA.Model.Dtos.Customer
{
    public class CustomerPutDto:IDto
    {
        public string? MusteriNo { get; set; }
        public string? SirketAdi { get; set; }
        public string? SirketYetkilisi { get; set; }
        public DateTime? EmirZamani { get; set; }
    }
}
