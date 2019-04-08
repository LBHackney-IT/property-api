using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace property_api.V1.Domain
{
    public class Property
    {
        public string PropRef { get; set; }
        public string LevelCode { get; set; }
        public string MajorRef { get; set; }
        public string ManScheme { get; set; }
        public string PostCode { get; set; }
        public string PostDesig { get; set; }
        public string ShortAddress { get; set; }
        public string AreaOffice { get; set; }
        public string SubtypCode { get; set; }
        public bool Letable { get; set; }
        public string CatType { get; set; }
        public string OccStat { get; set; }
        public string Heating { get; set; }
        public string RepArea { get; set; }
        public string PostPreamble { get; set; }
        public string UNom2 { get; set; }
        public string ArrPatch { get; set; }
        public int? NumBedrooms { get; set; }
        public bool? CommLifts { get; set; }
        public string EntLevel { get; set; }
        public string CompAvail { get; set; }
        public short NoSingleBeds { get; set; }
        public short NoDoubleBeds { get; set; }
        public string Address1 { get; set; }
    }
}
