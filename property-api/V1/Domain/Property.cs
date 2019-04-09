using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace property_api.V1.Domain
{
    public class Property
    {
        public string PropertyRef { get; set; }
        public string HierarchyCode { get; set; }
        public string ParentRef { get; set; }
        public string RepairCostCode { get; set; }
        public string PostCode { get; set; }
        public string AreaOffice { get; set; }
        public string PropertyTypeCode { get; set; }
        public bool Letable { get; set; }
        public string PropertyCategoryType { get; set; }
        public string OccupationStatus { get; set; }
        public string HeatingType { get; set; }
        public string RepairArea { get; set; }
        public string RentCostCentre { get; set; }
        public string ArrearsPatchCode { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public bool? CommunalLifts { get; set; }
        public string EntranceLevel { get; set; }
        public short NumberOfSingleBedrooms { get; set; }
        public short NumberOfDoubleBedrooms { get; set; }
        public string Address { get; set; }
    }
}
