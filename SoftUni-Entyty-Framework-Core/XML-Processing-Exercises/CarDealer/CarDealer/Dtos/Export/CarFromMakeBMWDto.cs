﻿
namespace CarDealer.Dtos.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarFromMakeBMWDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }
        
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
