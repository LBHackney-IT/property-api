﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace property_api.V1.Domain
{
    public class Property
    {
        public int PropRef { get; set; }
        public string LevelCode { get; set; }
        public string MajorRef { get; set; }
        public string ManScheme { get; set; }
        public string PostCode { get; set; }
        public string PostDesig { get; set; }
        public string ShortAddress { get; set; }
        public string Telephone { get; set; }
        public bool ManagedProperty { get; set; }
        public string Ownership { get; set; }
        public string Agent { get; set; }
        public string Comments { get; set; }
        public string HousingOfficer { get; set; }
        public string AreaOffice { get; set; }
        public string SubtypCode { get; set; }
        public string ConditionCode { get; set; }
        public string WardenRef { get; set; }
        public string LaRef { get; set; }
        public string WaterRef { get; set; }
        public string SchemeRef { get; set; }
        public string InsurPolicy { get; set; }
        public bool Letable { get; set; }
        public DateTime? PracticalCompletion { get; set; }
        public DateTime? Handover { get; set; }
        public string CatType { get; set; }
        public bool Lounge { get; set; }
        public bool Laundry { get; set; }
        public bool VisitorBed { get; set; }
        public bool Store { get; set; }
        public bool WardenFlat { get; set; }
        public bool Sheltered { get; set; }
        public string HouseRef { get; set; }
        public string OccStat { get; set; }
        public int? CyclicalDue { get; set; }
        public bool Shower { get; set; }
        public string Heating { get; set; }
        public string RepArea { get; set; }
        public string AcMeth { get; set; }
        public string Propsize { get; set; }
        public bool Rtb { get; set; }
        public int? Ratevalue { get; set; }
        public string PostPreamble { get; set; }
        public bool CoreShared { get; set; }
        public string RepOfficer { get; set; }
        public int? InsValue { get; set; }
        public string UNom2 { get; set; }
        public string Region { get; set; }
        public bool Asbestos { get; set; }
        public decimal? Accomfund { get; set; }
        public decimal? Candsfund { get; set; }
        public int? PropertySid { get; set; }
        public int? Keys { get; set; }
        public string Company { get; set; }
        public string LettArea { get; set; }
        public bool? RtbApplication { get; set; }
        public bool? NoMaint { get; set; }
        public string Maintresp { get; set; }
        public bool? Leasehold { get; set; }
        public bool? S125 { get; set; }
        public string PlannedRepairArea { get; set; }
        public string LraRef { get; set; }
        public string CoCode { get; set; }
        public string RepSubarea { get; set; }
        public int? ConKey { get; set; }
        public int? WalkNo { get; set; }
        public int? WalkSequence { get; set; }
        public byte[] Tstamp { get; set; }
        public string Alinefull { get; set; }
        public string ArrPatch { get; set; }
        public string ArrOfficer { get; set; }
        public string DhStatus { get; set; }
        public DateTime? DhAssdate { get; set; }
        public int? DhYearfail { get; set; }
        public int? DhCostnow { get; set; }
        public int? DhCostatfail { get; set; }
        public int? SapRating { get; set; }
        public decimal? NherRating { get; set; }
        public int? NumBedrooms { get; set; }
        public bool? CommLifts { get; set; }
        public string EntLevel { get; set; }
        public int? IntFloors { get; set; }
        public string GardenType { get; set; }
        public bool? PetsAllowed { get; set; }
        public string Parking { get; set; }
        public int? MinageRestric { get; set; }
        public int? FamilySize { get; set; }
        public bool? ChildAllowed { get; set; }
        public bool? LocalConn { get; set; }
        public bool? AllocPanel { get; set; }
        public int? NumSteps { get; set; }
        public bool? Garage { get; set; }
        public int? MaxageRestric { get; set; }
        public bool? StairLift { get; set; }
        public bool? ThroughLift { get; set; }
        public bool? AccShower { get; set; }
        public bool? Ramp { get; set; }
        public bool? HandRails { get; set; }
        public bool? DiningRoom { get; set; }
        public bool? KitchenDining { get; set; }
        public bool? SecToileta { get; set; }
        public string SecToiletb { get; set; }
        public string CookingFuel { get; set; }
        public string CompAvail { get; set; }
        public string CompDisplay { get; set; }
        public short NoSingleBeds { get; set; }
        public short NoDoubleBeds { get; set; }
        public bool OnlineRepairs { get; set; }
        public string VmPropref { get; set; }
        public bool? VoidmanLive { get; set; }
        public bool? Repairable { get; set; }
        public string Address1 { get; set; }
        public string UPropZone { get; set; }
        public string USurveyorPatch { get; set; }
        public string UEstate { get; set; }
        public string UBlock { get; set; }
        public string ULocation { get; set; }
        public string URentAccount { get; set; }
        public int? UFloors { get; set; }
        public string ULivingRooms { get; set; }
        public string UAccess { get; set; }
        public string UAmarchetype { get; set; }
        public bool? UPriorityEstate { get; set; }
        public string UCommEntry { get; set; }
        public string UConsultStat { get; set; }
        public string UCorrWidth { get; set; }
        public string UDpaService { get; set; }
        public string UEstQuality { get; set; }
        public string UEstSecurity { get; set; }
        public string UExtDecent { get; set; }
        public string UGasComments { get; set; }
        public bool? UGasServiceReq { get; set; }
        public string UIntDecent { get; set; }
        public string ULeverTaps { get; set; }
        public string ULiftManufact { get; set; }
        public DateTime? URtbStart { get; set; }
        public string USoldLeased { get; set; }
        public DateTime? USoldLeasedDate { get; set; }
        public bool? UDisabledOnly { get; set; }
        public DateTime? UDateDisposedDue { get; set; }
        public string ULeasedFrom { get; set; }
        public DateTime? ULeaseEndDate { get; set; }
        public string UEstateManagement { get; set; }
        public string UAccessFloor { get; set; }
        public bool? ULiftAvailable { get; set; }
        public string UBlockFloors { get; set; }
        public bool? UBalcony { get; set; }
        public bool? UDoorEntry { get; set; }
        public bool? UCouncilProperty { get; set; }
        public bool? UOapOnly { get; set; }
        public bool? UDisabledOccupier { get; set; }
        public string UEstateMapRef { get; set; }
        public string UPlanType { get; set; }
        public int? UYearConstructed { get; set; }
        public string UCollectionRound { get; set; }
        public string UTemporaryAccom { get; set; }
        public string UWindowType { get; set; }
        public string UQualityIndex { get; set; }
        public string UAsbestosItem { get; set; }
        public string UDisposedType { get; set; }
        public string URentSubzone { get; set; }
        public string ULegalCases { get; set; }
        public DateTime? UAsbestosDate { get; set; }
        public string ULlpgRef { get; set; }
        public string ULiftType { get; set; }
        public bool? UGhostBlock { get; set; }
        public string UGhostAddress { get; set; }
        public string UPropAreaLoc { get; set; }
        public string UOldFinanceCode { get; set; }
        public bool? UHaProperty { get; set; }
        public string UMobilityStd { get; set; }
        public string UMobilityWchair { get; set; }
        public string UNoLifts { get; set; }
        public string UNorthing { get; set; }
        public string UOverallDecent { get; set; }
        public string UPropSortKey { get; set; }
        public bool? URaisedSockets { get; set; }
        public bool? URampedAccess { get; set; }
        public bool? UStairLift { get; set; }
        public string UWchairStd { get; set; }
        public bool? UKitchenunit { get; set; }
        public string UReasondisposed { get; set; }
        public string UMraarchetype { get; set; }
        public string UAssetarchetype { get; set; }
        public string UHraarchetype { get; set; }
        public string ULsvtarchetype { get; set; }
        public string UBeaconcodes { get; set; }
        public string ULlpgref1 { get; set; }
        public bool? UAlarm { get; set; }
        public string UCatType { get; set; }
        public string UCeilingHoist { get; set; }
        public string UDisabledExtend { get; set; }
        public string UDhExtProg { get; set; }
        public string UDhIntProg { get; set; }
        public string UIntBalcony { get; set; }
        public string UWchairIntAccess { get; set; }
        public string ULoweredSwitches { get; set; }
        public string URaisedSocket { get; set; }
        public string UFrontRamp { get; set; }
        public string URearRamp { get; set; }
        public string UScooterStore { get; set; }
        public string UStairLiftType { get; set; }
        public string UHandRailType { get; set; }
        public int? URearEntSteps { get; set; }
        public string UThroughLift { get; set; }
        public int? UNoWcs { get; set; }
        public string UWcClosomat { get; set; }
        public string UWidenedDoors { get; set; }
        public string OwnerConf { get; set; }
        public string EpcCertNo { get; set; }
        public DateTime? EpcCertDate { get; set; }
        public DateTime? EpcSurvDate { get; set; }
        public DateTime? EpcRqDate { get; set; }
        public DateTime? EpcRecDate { get; set; }
        public decimal? EpcEnergy { get; set; }
        public decimal? EpcCo2 { get; set; }
        public decimal? ScSinkfund { get; set; }
        public decimal? US20Factor { get; set; }
        public DateTime? UBuyBackDate { get; set; }
        public bool? USharedBathroom { get; set; }
        public bool? USharedToilet { get; set; }
        public string UTempTenure { get; set; }
        public bool? UDisrepair { get; set; }
        public string ULhaArea { get; set; }
        public string UEstMan { get; set; }
        public string UCleaner { get; set; }
        public string UAhrCat { get; set; }
        public bool? USharedKitchen { get; set; }
        public string URslPropRef { get; set; }
        public bool? UUsesComBoiler { get; set; }
        public bool? UUsesDoorEnt { get; set; }
        public bool? UUsesLift { get; set; }
        public string UMwPatch { get; set; }
        public string UYearBuilt { get; set; }
        public DateTime? UHandBackDate { get; set; }
        public string UBedroomBedsize { get; set; }
        public string UMktInfoOnline { get; set; }
        public string UMktInfoMagazine { get; set; }
        public DateTime Dtstamp { get; set; }
        public int? UHgas { get; set; }
        public string UAccessType { get; set; }
        public string UStorageSpace { get; set; }
        public int? UInternalSteps { get; set; }
        public int? UExternalSteps { get; set; }
        public string UFulAdaptdKitchen { get; set; }
        public bool? UHoists { get; set; }
        public bool? UIntercom { get; set; }
    }
}
