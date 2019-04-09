using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace property_api.V1.Data.Entities
{
    [Table("property")]
    public class UhPropertyEntity
    {
        [Key]
        [MaxLength(12)]
        [Column("prop_ref")]
        public string PropRef { get; set; }
        [Column("level_code")]
        public string LevelCode { get; set; }
        [Column("major_ref")]
        public string MajorRef { get; set; }
        [Column("man_scheme")]
        public string ManScheme { get; set; }
        [Column("post_code")]
        public string PostCode { get; set; }
        [Column("post_desig")]
        public string PostDesig { get; set; }
        [Column("short_address")]
        public string ShortAddress { get; set; }
        [MaxLength(21)]
        [Column("telephone")]
        public string Telephone { get; set; }
        [Column("managed_property")]
        public bool ManagedProperty { get; set; }

        [Required,  MaxLength(10), Column("ownership")]
        public string Ownership { get; set; }

        [Column("agent")]
        public string Agent { get; set; }
        [Column("comments")]
        public string Comments { get; set; }
        [Column("housing_officer")]
        public string HousingOfficer { get; set; }
        [Column("area_office")]
        public string AreaOffice { get; set; }
        [Column("subtyp_code")]
        public string SubtypCode { get; set; }
        [Column("condition_code")]
        public string ConditionCode { get; set; }
        [Column("warden_ref")]
        public string WardenRef { get; set; }
        [Column("la_ref")]
        public string LaRef { get; set; }
        [Column("water_ref")]
        public string WaterRef { get; set; }
        [Column("scheme_ref")]
        public string SchemeRef { get; set; }
        [Column("insur_policy")]
        public string InsurPolicy { get; set; }
        [Column("letable")]
        public bool Letable { get; set; }
        [Column("practical_completion")]
        public DateTime? PracticalCompletion { get; set; }
        [Column("handover")]
        public DateTime? Handover { get; set; }
        [Column("cat_type")]
        public string CatType { get; set; }
        [Column("lounge")]
        public bool Lounge { get; set; }
        [Column("laundry")]
        public bool Laundry { get; set; }
        [Column("visitor_bed")]
        public bool VisitorBed { get; set; }
        [Column("store")]
        public bool Store { get; set; }
        [Column("warden_flat")]
        public bool WardenFlat { get; set; }
        [Column("sheltered")]
        public bool Sheltered { get; set; }
        [Column("house_ref")]
        public string HouseRef { get; set; }
        [Column("occ_stat")]
        public string OccStat { get; set; }
        [Column("cyclical_due")]
        public int? CyclicalDue { get; set; }
        [Column("shower")]
        public bool Shower { get; set; }
        [Column("heating")]
        public string Heating { get; set; }
        [Column("rep_area")]
        public string RepArea { get; set; }
        [Column("ac_meth")]
        public string AcMeth { get; set; }
        [Column("propsize")]
        public string Propsize { get; set; }
        [Column("rtb")]
        public bool Rtb { get; set; }
        [Column("ratevalue")]
        public int? Ratevalue { get; set; }
        [Column("post_preamble")]
        public string PostPreamble { get; set; }
        [Column("core_shared")]
        public bool CoreShared { get; set; }
        [Column("rep_officer")]
        public string RepOfficer { get; set; }
        [Column("ins_value")]
        public int? InsValue { get; set; }
        [Column("u_nom2")]
        public string UNom2 { get; set; }
        [Column("region")]
        public string Region { get; set; }
        [Column("asbestos")]
        public bool Asbestos { get; set; }
        [Column("accomfund")]
        public decimal? Accomfund { get; set; }
        [Column("candsfund")]
        public decimal? Candsfund { get; set; }
        [Column("property_sid")]
        public int? PropertySid { get; set; }
        [Column("keys")]
        public int? Keys { get; set; }
        [Column("company")]
        public string Company { get; set; }
        [Column("lett_area")]
        public string LettArea { get; set; }
        [Column("rtb_application")]
        public bool? RtbApplication { get; set; }
        [Column("no_maint")]
        public bool? NoMaint { get; set; }
        [Column("maintresp")]
        public string Maintresp { get; set; }
        [Column("leasehold")]
        public bool? Leasehold { get; set; }
        [Column("s125")]
        public bool? S125 { get; set; }
        [Column("planned_repair_area")]
        public string PlannedRepairArea { get; set; }
        [Column("lra_ref")]
        public string LraRef { get; set; }
        [Column("co_code")]
        public string CoCode { get; set; }
        [Column("rep_subarea")]
        public string RepSubarea { get; set; }
        [Column("con_key")]
        public int? ConKey { get; set; }
        [Column("walk_no")]
        public int? WalkNo { get; set; }
        [Column("walk_sequence")]
        public int? WalkSequence { get; set; }

        [Column("tstamp")]
        public byte[] Tstamp { get; set; }

        [Column("alinefull")]
        public string Alinefull { get; set; }
        [Column("arr_patch")]
        public string ArrPatch { get; set; }
        [Column("arr_officer")]
        public string ArrOfficer { get; set; }
        [Column("dh_status")]
        public string DhStatus { get; set; }
        [Column("dh_assdate")]
        public DateTime? DhAssdate { get; set; }
        [Column("dh_yearfail")]
        public int? DhYearfail { get; set; }
        [Column("dh_costnow")]
        public int? DhCostnow { get; set; }
        [Column("dh_costatfail")]
        public int? DhCostatfail { get; set; }
        [Column("sap_rating")]
        public int? SapRating { get; set; }
        [Column("nher_rating")]
        public decimal? NherRating { get; set; }
        [Column("num_bedrooms")]
        public int? NumBedrooms { get; set; }
        [Column("comm_lifts")]
        public bool? CommLifts { get; set; }
        [Column("ent_level")]
        public string EntLevel { get; set; }
        [Column("int_floors")]
        public int? IntFloors { get; set; }
        [Column("garden_type")]
        public string GardenType { get; set; }
        [Column("pets_allowed")]
        public bool? PetsAllowed { get; set; }
        [Column("parking")]
        public string Parking { get; set; }
        [Column("minage_restric")]
        public int? MinageRestric { get; set; }
        [Column("family_size")]
        public int? FamilySize { get; set; }
        [Column("child_allowed")]
        public bool? ChildAllowed { get; set; }
        [Column("local_conn")]
        public bool? LocalConn { get; set; }
        [Column("alloc_panel")]
        public bool? AllocPanel { get; set; }
        [Column("num_steps")]
        public int? NumSteps { get; set; }
        [Column("garage")]
        public bool? Garage { get; set; }
        [Column("maxage_restric")]
        public int? MaxageRestric { get; set; }
        [Column("stair_lift")]
        public bool? StairLift { get; set; }
        [Column("through_lift")]
        public bool? ThroughLift { get; set; }
        [Column("acc_shower")]
        public bool? AccShower { get; set; }
        [Column("ramp")]
        public bool? Ramp { get; set; }
        [Column("hand_rails")]
        public bool? HandRails { get; set; }
        [Column("dining_room")]
        public bool? DiningRoom { get; set; }
        [Column("kitchen_dining")]
        public bool? KitchenDining { get; set; }
        [Column("sec_toileta")]
        public bool? SecToileta { get; set; }
        [Column("sec_toiletb")]
        public string SecToiletb { get; set; }
        [Column("cooking_fuel")]
        public string CookingFuel { get; set; }
        [Column("comp_avail")]
        public string CompAvail { get; set; }
        [Column("comp_display")]
        public string CompDisplay { get; set; }
        [Column("no_single_beds")]
        public short NoSingleBeds { get; set; }
        [Column("no_double_beds")]
        public short NoDoubleBeds { get; set; }
        [Required]
        [Column("online_repairs")]
        public bool? OnlineRepairs { get; set; }
        [Column("vm_propref")]
        public string VmPropref { get; set; }
        [Column("voidman_live")]
        public bool? VoidmanLive { get; set; }
        [Required]
        [Column("repairable")]
        public bool Repairable { get; set; }
        [Column("address1")]
        public string Address1 { get; set; }
        [Column("u_prop_zone")]
        public string UPropZone { get; set; }
        [Column("u_surveyor_patch")]
        public string USurveyorPatch { get; set; }
        [Column("u_estate")]
        public string UEstate { get; set; }
        [Column("u_block")]
        public string UBlock { get; set; }
        [Column("u_location")]
        public string ULocation { get; set; }
        [Column("u_rent_account")]
        public string URentAccount { get; set; }
        [Column("u_floors")]
        public int? UFloors { get; set; }
        [Column("u_living_rooms")]
        public string ULivingRooms { get; set; }
        [Column("u_access")]
        public string UAccess { get; set; }
        [Column("u_amarchetype")]
        public string UAmarchetype { get; set; }
        [Column("u_priority_estate")]
        public bool? UPriorityEstate { get; set; }
        [Column("u_comm_entry")]
        public string UCommEntry { get; set; }
        [Column("u_consult_stat")]
        public string UConsultStat { get; set; }
        [Column("u_corr_width")]
        public string UCorrWidth { get; set; }
        [Column("u_dpa_service")]
        public string UDpaService { get; set; }
        [Column("u_est_quality")]
        public string UEstQuality { get; set; }
        [Column("u_est_security")]
        public string UEstSecurity { get; set; }
        [Column("u_ext_decent")]
        public string UExtDecent { get; set; }
        [Column("u_gas_comments")]
        public string UGasComments { get; set; }
        [Column("u_gas_service_req")]
        public bool? UGasServiceReq { get; set; }
        [Column("u_int_decent")]
        public string UIntDecent { get; set; }
        [Column("u_lever_taps")]
        public string ULeverTaps { get; set; }
        [Column("u_lift_manufact")]
        public string ULiftManufact { get; set; }
        [Column("u_rtb_start")]
        public DateTime? URtbStart { get; set; }
        [Column("u_sold_leased")]
        public string USoldLeased { get; set; }
        [Column("u_sold_leased_date")]
        public DateTime? USoldLeasedDate { get; set; }
        [Column("u_disabled_only")]
        public bool? UDisabledOnly { get; set; }
        [Column("u_date_disposed_due")]
        public DateTime? UDateDisposedDue { get; set; }
        [Column("u_leased_from")]
        public string ULeasedFrom { get; set; }
        [Column("u_lease_end_date")]
        public DateTime? ULeaseEndDate { get; set; }
        [Column("u_estate_management")]
        public string UEstateManagement { get; set; }
        [Column("u_access_floor")]
        public string UAccessFloor { get; set; }
        [Column("u_lift_available")]
        public bool? ULiftAvailable { get; set; }
        [Column("u_block_floors")]
        public string UBlockFloors { get; set; }
        [Column("u_balcony")]
        public bool? UBalcony { get; set; }
        [Column("u_door_entry")]
        public bool? UDoorEntry { get; set; }
        [Column("u_council_property")]
        public bool? UCouncilProperty { get; set; }
        [Column("u_oap_only")]
        public bool? UOapOnly { get; set; }
        [Column("u_disabled_occupier")]
        public bool? UDisabledOccupier { get; set; }
        [Column("u_estate_map_ref")]
        public string UEstateMapRef { get; set; }
        [Column("u_plan_type")]
        public string UPlanType { get; set; }
        [Column("u_year_constructed")]
        public int? UYearConstructed { get; set; }
        [Column("u_collection_round")]
        public string UCollectionRound { get; set; }
        [Column("u_temporary_accom")]
        public string UTemporaryAccom { get; set; }
        [Column("u_window_type")]
        public string UWindowType { get; set; }
        [Column("u_quality_index")]
        public string UQualityIndex { get; set; }
        [Column("u_asbestos_item")]
        public string UAsbestosItem { get; set; }
        [Column("u_disposed_type")]
        public string UDisposedType { get; set; }
        [Column("u_rent_subzone")]
        public string URentSubzone { get; set; }
        [Column("u_legal_cases")]
        public string ULegalCases { get; set; }
        [Column("u_asbestos_date")]
        public DateTime? UAsbestosDate { get; set; }
        [Column("u_llpg_ref")]
        public string ULlpgRef { get; set; }
        [Column("u_lift_type")]
        public string ULiftType { get; set; }
        [Column("u_ghost_block")]
        public bool? UGhostBlock { get; set; }
        [Column("u_ghost_address")]
        public string UGhostAddress { get; set; }
        [Column("u_prop_area_loc")]
        public string UPropAreaLoc { get; set; }
        [Column("u_old_finance_code")]
        public string UOldFinanceCode { get; set; }
        [Column("u_ha_property")]
        public bool? UHaProperty { get; set; }
        [Column("u_mobility_std")]
        public string UMobilityStd { get; set; }
        [Column("u_mobility_wchair")]
        public string UMobilityWchair { get; set; }
        [Column("u_no_lifts")]
        public string UNoLifts { get; set; }
        [Column("u_northing")]
        public string UNorthing { get; set; }
        [Column("u_overall_decent")]
        public string UOverallDecent { get; set; }
        [Column("u_prop_sort_key")]
        public string UPropSortKey { get; set; }
        [Column("u_raised_sockets")]
        public bool? URaisedSockets { get; set; }
        [Column("u_ramped_access")]
        public bool? URampedAccess { get; set; }
        [Column("u_stair_lift")]
        public bool? UStairLift { get; set; }
        [Column("u_wchair_std")]
        public string UWchairStd { get; set; }
        [Column("u_kitchenunit")]
        public bool? UKitchenunit { get; set; }
        [Column("u_reasondisposed")]
        public string UReasondisposed { get; set; }
        [Column("u_mraarchetype")]
        public string UMraarchetype { get; set; }
        [Column("u_assetarchetype")]
        public string UAssetarchetype { get; set; }
        [Column("u_hraarchetype")]
        public string UHraarchetype { get; set; }
        [Column("u_lsvtarchetype")]
        public string ULsvtarchetype { get; set; }
        [Column("u_beaconcodes")]
        public string UBeaconcodes { get; set; }
        [Column("u_llpgref")]
        public string ULlpgref1 { get; set; }
        [Column("u_alarm")]
        public bool? UAlarm { get; set; }
        [Column("u_cat_type")]
        public string UCatType { get; set; }
        [Column("u_ceiling_hoist")]
        public string UCeilingHoist { get; set; }
        [Column("u_disabled_extend")]
        public string UDisabledExtend { get; set; }
        [Column("u_dh_ext_prog")]
        public string UDhExtProg { get; set; }
        [Column("u_dh_int_prog")]
        public string UDhIntProg { get; set; }
        [Column("u_int_balcony")]
        public string UIntBalcony { get; set; }
        [Column("u_wchair_int_access")]
        public string UWchairIntAccess { get; set; }
        [Column("u_lowered_switches")]
        public string ULoweredSwitches { get; set; }
        [Column("u_raised_socket")]
        public string URaisedSocket { get; set; }
        [Column("u_front_ramp")]
        public string UFrontRamp { get; set; }
        [Column("u_rear_ramp")]
        public string URearRamp { get; set; }
        [Column("u_scooter_store")]
        public string UScooterStore { get; set; }
        [Column("u_stair_lift_type")]
        public string UStairLiftType { get; set; }
        [Column("u_hand_rail_type")]
        public string UHandRailType { get; set; }
        [Column("u_rear_ent_steps")]
        public int? URearEntSteps { get; set; }
        [Column("u_through_lift")]
        public string UThroughLift { get; set; }
        [Column("u_no_wcs")]
        public int? UNoWcs { get; set; }
        [Column("u_wc_closomat")]
        public string UWcClosomat { get; set; }
        [Column("u_widened_doors")]
        public string UWidenedDoors { get; set; }
        [Column("owner_conf")]
        public string OwnerConf { get; set; }
        [Column("epc_cert_no")]
        public string EpcCertNo { get; set; }
        [Column("epc_cert_date")]
        public DateTime? EpcCertDate { get; set; }
        [Column("epc_surv_date")]
        public DateTime? EpcSurvDate { get; set; }
        [Column("epc_rq_date")]
        public DateTime? EpcRqDate { get; set; }
        [Column("epc_rec_date")]
        public DateTime? EpcRecDate { get; set; }
        [Column("epc_energy")]
        public decimal? EpcEnergy { get; set; }
        [Column("epc_co2")]
        public decimal? EpcCo2 { get; set; }
        [Column("sc_sinkfund")]
        public decimal? ScSinkfund { get; set; }
        [Column("u_s20_factor")]
        public decimal? US20Factor { get; set; }
        [Column("u_buy_back_date")]
        public DateTime? UBuyBackDate { get; set; }
        [Column("u_shared_bathroom")]
        public bool? USharedBathroom { get; set; }
        [Column("u_shared_toilet")]
        public bool? USharedToilet { get; set; }
        [Column("u_temp_tenure")]
        public string UTempTenure { get; set; }
        [Column("u_disrepair")]
        public bool? UDisrepair { get; set; }
        [Column("u_lha_area")]
        public string ULhaArea { get; set; }
        [Column("u_est_man")]
        public string UEstMan { get; set; }
        [Column("u_cleaner")]
        public string UCleaner { get; set; }
        [Column("u_ahr_cat")]
        public string UAhrCat { get; set; }
        [Column("u_shared_kitchen")]
        public bool? USharedKitchen { get; set; }
        [Column("u_rsl_prop_ref")]
        public string URslPropRef { get; set; }
        [Column("u_uses_com_boiler")]
        public bool? UUsesComBoiler { get; set; }
        [Column("u_uses_door_ent")]
        public bool? UUsesDoorEnt { get; set; }
        [Column("u_uses_lift")]
        public bool? UUsesLift { get; set; }
        [Column("u_mw_patch")]
        public string UMwPatch { get; set; }
        [Column("u_year_built")]
        public string UYearBuilt { get; set; }
        [Column("u_hand_back_date")]
        public DateTime? UHandBackDate { get; set; }
        [Column("u_bedroom_bedsize")]
        public string UBedroomBedsize { get; set; }
        [Column("u_mkt_info_online")]
        public string UMktInfoOnline { get; set; }
        [Column("u_mkt_info_magazine")]
        public string UMktInfoMagazine { get; set; }

        [Column("dtstamp")]
        public DateTime Dtstamp { get; set; }

        [Column("u_hgas")]
        public int? UHgas { get; set; }
        [Column("u_access_type")]
        public string UAccessType { get; set; }
        [Column("u_storage_space")]
        public string UStorageSpace { get; set; }
        [Column("u_internal_steps")]
        public int? UInternalSteps { get; set; }
        [Column("u_external_steps")]
        public int? UExternalSteps { get; set; }
        [Column("u_adapted_kitchen")]
        public string UFulAdaptdKitchen { get; set; }
        [Column("u_hoists")]
        public bool? UHoists { get; set; }
        [Column("u_intercom")]
        public bool? UIntercom { get; set; }
    }
}
