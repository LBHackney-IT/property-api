using property_api.V1.Factory;
using NUnit.Framework;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using AutoMapper;
using Castle.Core.Internal;
using UnitTests.V1.Helpers;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class PropertyFactoryTests
    {
        private PropertyFactory _classUnderTest;
        private readonly UhPropertyHelper _uhPropertyHelper = new UhPropertyHelper();

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<UhPropertyEntity, Property>());
            var mapper = mapperConfig.CreateMapper();
            _classUnderTest = new PropertyFactory(mapper);
        }

        [Test]
        public void ReturnsEmptyPropertyWhereThereIsNoMatch()
        {
            var expectedResponse = new UhPropertyEntity();
            var result = _classUnderTest.FromUHProperty(expectedResponse);

            Assert.True(result is Property);
            Assert.IsNull(result.PropRef);
            Assert.IsNull(result.Telephone);
        }

        [Test]
        public void ReturnsPopulatedProperty()
        {
            var uhProperty = _uhPropertyHelper.GenerateUhProperty();

            var result = _classUnderTest.FromUHProperty(uhProperty);

            Assert.True(result is Property);

            Assert.AreEqual(uhProperty.Tstamp.IsNullOrEmpty(), result.Tstamp.IsNullOrEmpty());


            Assert.AreEqual(uhProperty.PropRef, result.PropRef);
            Assert.AreEqual(uhProperty.LevelCode, result.LevelCode);
            Assert.AreEqual(uhProperty.MajorRef, result.MajorRef);
            Assert.AreEqual(uhProperty.ManScheme, result.ManScheme);
            Assert.AreEqual(uhProperty.PostCode, result.PostCode);
            Assert.AreEqual(uhProperty.PostDesig, result.PostDesig);
            Assert.AreEqual(uhProperty.ShortAddress, result.ShortAddress);
            Assert.AreEqual(uhProperty.Telephone, result.Telephone);
            Assert.AreEqual(uhProperty.ManagedProperty, result.ManagedProperty);
            Assert.AreEqual(uhProperty.Ownership, result.Ownership);
            Assert.AreEqual(uhProperty.Agent, result.Agent);
            Assert.AreEqual(uhProperty.Comments, result.Comments);
            Assert.AreEqual(uhProperty.HousingOfficer, result.HousingOfficer);
            Assert.AreEqual(uhProperty.AreaOffice, result.AreaOffice);
            Assert.AreEqual(uhProperty.SubtypCode, result.SubtypCode);
            Assert.AreEqual(uhProperty.ConditionCode, result.ConditionCode);
            Assert.AreEqual(uhProperty.WardenRef, result.WardenRef);
            Assert.AreEqual(uhProperty.LaRef, result.LaRef);
            Assert.AreEqual(uhProperty.WaterRef, result.WaterRef);
            Assert.AreEqual(uhProperty.SchemeRef, result.SchemeRef);
            Assert.AreEqual(uhProperty.InsurPolicy, result.InsurPolicy);
            Assert.AreEqual(uhProperty.Letable, result.Letable);
            Assert.AreEqual(uhProperty.PracticalCompletion, result.PracticalCompletion);
            Assert.AreEqual(uhProperty.Handover, result.Handover);
            Assert.AreEqual(uhProperty.CatType, result.CatType);
            Assert.AreEqual(uhProperty.Lounge, result.Lounge);
            Assert.AreEqual(uhProperty.Laundry, result.Laundry);
            Assert.AreEqual(uhProperty.VisitorBed, result.VisitorBed);
            Assert.AreEqual(uhProperty.Store, result.Store);
            Assert.AreEqual(uhProperty.WardenFlat, result.WardenFlat);
            Assert.AreEqual(uhProperty.Sheltered, result.Sheltered);
            Assert.AreEqual(uhProperty.HouseRef, result.HouseRef);
            Assert.AreEqual(uhProperty.OccStat, result.OccStat);
            Assert.AreEqual(uhProperty.CyclicalDue, result.CyclicalDue);
            Assert.AreEqual(uhProperty.Shower, result.Shower);
            Assert.AreEqual(uhProperty.Heating, result.Heating);
            Assert.AreEqual(uhProperty.RepArea, result.RepArea);
            Assert.AreEqual(uhProperty.AcMeth, result.AcMeth);
            Assert.AreEqual(uhProperty.Propsize, result.Propsize);
            Assert.AreEqual(uhProperty.Rtb, result.Rtb);
            Assert.AreEqual(uhProperty.Ratevalue, result.Ratevalue);
            Assert.AreEqual(uhProperty.PostPreamble, result.PostPreamble);
            Assert.AreEqual(uhProperty.CoreShared, result.CoreShared);
            Assert.AreEqual(uhProperty.RepOfficer, result.RepOfficer);
            Assert.AreEqual(uhProperty.InsValue, result.InsValue);
            Assert.AreEqual(uhProperty.UNom2, result.UNom2);
            Assert.AreEqual(uhProperty.Region, result.Region);
            Assert.AreEqual(uhProperty.Asbestos, result.Asbestos);
            Assert.AreEqual(uhProperty.Accomfund, result.Accomfund);
            Assert.AreEqual(uhProperty.Candsfund, result.Candsfund);
            Assert.AreEqual(uhProperty.PropertySid, result.PropertySid);
            Assert.AreEqual(uhProperty.Keys, result.Keys);
            Assert.AreEqual(uhProperty.Company, result.Company);
            Assert.AreEqual(uhProperty.LettArea, result.LettArea);
            Assert.AreEqual(uhProperty.RtbApplication, result.RtbApplication);
            Assert.AreEqual(uhProperty.NoMaint, result.NoMaint);
            Assert.AreEqual(uhProperty.Maintresp, result.Maintresp);
            Assert.AreEqual(uhProperty.Leasehold, result.Leasehold);
            Assert.AreEqual(uhProperty.S125, result.S125);
            Assert.AreEqual(uhProperty.PlannedRepairArea, result.PlannedRepairArea);
            Assert.AreEqual(uhProperty.LraRef, result.LraRef);
            Assert.AreEqual(uhProperty.CoCode, result.CoCode);
            Assert.AreEqual(uhProperty.RepSubarea, result.RepSubarea);
            Assert.AreEqual(uhProperty.ConKey, result.ConKey);
            Assert.AreEqual(uhProperty.WalkNo, result.WalkNo);
            Assert.AreEqual(uhProperty.WalkSequence, result.WalkSequence);
            Assert.AreEqual(uhProperty.Alinefull, result.Alinefull);
            Assert.AreEqual(uhProperty.ArrPatch, result.ArrPatch);
            Assert.AreEqual(uhProperty.ArrOfficer, result.ArrOfficer);
            Assert.AreEqual(uhProperty.DhStatus, result.DhStatus);
            Assert.AreEqual(uhProperty.DhAssdate, result.DhAssdate);
            Assert.AreEqual(uhProperty.DhYearfail, result.DhYearfail);
            Assert.AreEqual(uhProperty.DhCostnow, result.DhCostnow);
            Assert.AreEqual(uhProperty.DhCostatfail, result.DhCostatfail);
            Assert.AreEqual(uhProperty.SapRating, result.SapRating);
            Assert.AreEqual(uhProperty.NherRating, result.NherRating);
            Assert.AreEqual(uhProperty.NumBedrooms, result.NumBedrooms);
            Assert.AreEqual(uhProperty.CommLifts, result.CommLifts);
            Assert.AreEqual(uhProperty.EntLevel, result.EntLevel);
            Assert.AreEqual(uhProperty.IntFloors, result.IntFloors);
            Assert.AreEqual(uhProperty.GardenType, result.GardenType);
            Assert.AreEqual(uhProperty.PetsAllowed, result.PetsAllowed);
            Assert.AreEqual(uhProperty.Parking, result.Parking);
            Assert.AreEqual(uhProperty.MinageRestric, result.MinageRestric);
            Assert.AreEqual(uhProperty.FamilySize, result.FamilySize);
            Assert.AreEqual(uhProperty.ChildAllowed, result.ChildAllowed);
            Assert.AreEqual(uhProperty.LocalConn, result.LocalConn);
            Assert.AreEqual(uhProperty.AllocPanel, result.AllocPanel);
            Assert.AreEqual(uhProperty.NumSteps, result.NumSteps);
            Assert.AreEqual(uhProperty.Garage, result.Garage);
            Assert.AreEqual(uhProperty.MaxageRestric, result.MaxageRestric);
            Assert.AreEqual(uhProperty.StairLift, result.StairLift);
            Assert.AreEqual(uhProperty.ThroughLift, result.ThroughLift);
            Assert.AreEqual(uhProperty.AccShower, result.AccShower);
            Assert.AreEqual(uhProperty.Ramp, result.Ramp);
            Assert.AreEqual(uhProperty.HandRails, result.HandRails);
            Assert.AreEqual(uhProperty.DiningRoom, result.DiningRoom);
            Assert.AreEqual(uhProperty.KitchenDining, result.KitchenDining);
            Assert.AreEqual(uhProperty.SecToileta, result.SecToileta);
            Assert.AreEqual(uhProperty.SecToiletb, result.SecToiletb);
            Assert.AreEqual(uhProperty.CookingFuel, result.CookingFuel);
            Assert.AreEqual(uhProperty.CompAvail, result.CompAvail);
            Assert.AreEqual(uhProperty.CompDisplay, result.CompDisplay);
            Assert.AreEqual(uhProperty.NoSingleBeds, result.NoSingleBeds);
            Assert.AreEqual(uhProperty.NoDoubleBeds, result.NoDoubleBeds);
            Assert.AreEqual(uhProperty.OnlineRepairs, result.OnlineRepairs);
            Assert.AreEqual(uhProperty.VmPropref, result.VmPropref);
            Assert.AreEqual(uhProperty.VoidmanLive, result.VoidmanLive);
            Assert.AreEqual(uhProperty.Repairable, result.Repairable);
            Assert.AreEqual(uhProperty.Address1, result.Address1);
            Assert.AreEqual(uhProperty.UPropZone, result.UPropZone);
            Assert.AreEqual(uhProperty.USurveyorPatch, result.USurveyorPatch);
            Assert.AreEqual(uhProperty.UEstate, result.UEstate);
            Assert.AreEqual(uhProperty.UBlock, result.UBlock);
            Assert.AreEqual(uhProperty.ULocation, result.ULocation);
            Assert.AreEqual(uhProperty.URentAccount, result.URentAccount);
            Assert.AreEqual(uhProperty.UFloors, result.UFloors);
            Assert.AreEqual(uhProperty.ULivingRooms, result.ULivingRooms);
            Assert.AreEqual(uhProperty.UAccess, result.UAccess);
            Assert.AreEqual(uhProperty.UAmarchetype, result.UAmarchetype);
            Assert.AreEqual(uhProperty.UPriorityEstate, result.UPriorityEstate);
            Assert.AreEqual(uhProperty.UCommEntry, result.UCommEntry);
            Assert.AreEqual(uhProperty.UConsultStat, result.UConsultStat);
            Assert.AreEqual(uhProperty.UCorrWidth, result.UCorrWidth);
            Assert.AreEqual(uhProperty.UDpaService, result.UDpaService);
            Assert.AreEqual(uhProperty.UEstQuality, result.UEstQuality);
            Assert.AreEqual(uhProperty.UEstSecurity, result.UEstSecurity);
            Assert.AreEqual(uhProperty.UExtDecent, result.UExtDecent);
            Assert.AreEqual(uhProperty.UGasComments, result.UGasComments);
            Assert.AreEqual(uhProperty.UGasServiceReq, result.UGasServiceReq);
            Assert.AreEqual(uhProperty.UIntDecent, result.UIntDecent);
            Assert.AreEqual(uhProperty.ULeverTaps, result.ULeverTaps);
            Assert.AreEqual(uhProperty.ULiftManufact, result.ULiftManufact);
            Assert.AreEqual(uhProperty.URtbStart, result.URtbStart);
            Assert.AreEqual(uhProperty.USoldLeased, result.USoldLeased);
            Assert.AreEqual(uhProperty.USoldLeasedDate, result.USoldLeasedDate);
            Assert.AreEqual(uhProperty.UDisabledOnly, result.UDisabledOnly);
            Assert.AreEqual(uhProperty.UDateDisposedDue, result.UDateDisposedDue);
            Assert.AreEqual(uhProperty.ULeasedFrom, result.ULeasedFrom);
            Assert.AreEqual(uhProperty.ULeaseEndDate, result.ULeaseEndDate);
            Assert.AreEqual(uhProperty.UEstateManagement, result.UEstateManagement);
            Assert.AreEqual(uhProperty.UAccessFloor, result.UAccessFloor);
            Assert.AreEqual(uhProperty.ULiftAvailable, result.ULiftAvailable);
            Assert.AreEqual(uhProperty.UBlockFloors, result.UBlockFloors);
            Assert.AreEqual(uhProperty.UBalcony, result.UBalcony);
            Assert.AreEqual(uhProperty.UDoorEntry, result.UDoorEntry);
            Assert.AreEqual(uhProperty.UCouncilProperty, result.UCouncilProperty);
            Assert.AreEqual(uhProperty.UOapOnly, result.UOapOnly);
            Assert.AreEqual(uhProperty.UDisabledOccupier, result.UDisabledOccupier);
            Assert.AreEqual(uhProperty.UEstateMapRef, result.UEstateMapRef);
            Assert.AreEqual(uhProperty.UPlanType, result.UPlanType);
            Assert.AreEqual(uhProperty.UYearConstructed, result.UYearConstructed);
            Assert.AreEqual(uhProperty.UCollectionRound, result.UCollectionRound);
            Assert.AreEqual(uhProperty.UTemporaryAccom, result.UTemporaryAccom);
            Assert.AreEqual(uhProperty.UWindowType, result.UWindowType);
            Assert.AreEqual(uhProperty.UQualityIndex, result.UQualityIndex);
            Assert.AreEqual(uhProperty.UAsbestosItem, result.UAsbestosItem);
            Assert.AreEqual(uhProperty.UDisposedType, result.UDisposedType);
            Assert.AreEqual(uhProperty.URentSubzone, result.URentSubzone);
            Assert.AreEqual(uhProperty.ULegalCases, result.ULegalCases);
            Assert.AreEqual(uhProperty.UAsbestosDate, result.UAsbestosDate);
            Assert.AreEqual(uhProperty.ULlpgRef, result.ULlpgRef);
            Assert.AreEqual(uhProperty.ULiftType, result.ULiftType);
            Assert.AreEqual(uhProperty.UGhostBlock, result.UGhostBlock);
            Assert.AreEqual(uhProperty.UGhostAddress, result.UGhostAddress);
            Assert.AreEqual(uhProperty.UPropAreaLoc, result.UPropAreaLoc);
            Assert.AreEqual(uhProperty.UOldFinanceCode, result.UOldFinanceCode);
            Assert.AreEqual(uhProperty.UHaProperty, result.UHaProperty);
            Assert.AreEqual(uhProperty.UMobilityStd, result.UMobilityStd);
            Assert.AreEqual(uhProperty.UMobilityWchair, result.UMobilityWchair);
            Assert.AreEqual(uhProperty.UNoLifts, result.UNoLifts);
            Assert.AreEqual(uhProperty.UNorthing, result.UNorthing);
            Assert.AreEqual(uhProperty.UOverallDecent, result.UOverallDecent);
            Assert.AreEqual(uhProperty.UPropSortKey, result.UPropSortKey);
            Assert.AreEqual(uhProperty.URaisedSockets, result.URaisedSockets);
            Assert.AreEqual(uhProperty.URampedAccess, result.URampedAccess);
            Assert.AreEqual(uhProperty.UStairLift, result.UStairLift);
            Assert.AreEqual(uhProperty.UWchairStd, result.UWchairStd);
            Assert.AreEqual(uhProperty.UKitchenunit, result.UKitchenunit);
            Assert.AreEqual(uhProperty.UReasondisposed, result.UReasondisposed);
            Assert.AreEqual(uhProperty.UMraarchetype, result.UMraarchetype);
            Assert.AreEqual(uhProperty.UAssetarchetype, result.UAssetarchetype);
            Assert.AreEqual(uhProperty.UHraarchetype, result.UHraarchetype);
            Assert.AreEqual(uhProperty.ULsvtarchetype, result.ULsvtarchetype);
            Assert.AreEqual(uhProperty.UBeaconcodes, result.UBeaconcodes);
            Assert.AreEqual(uhProperty.ULlpgref1, result.ULlpgref1);
            Assert.AreEqual(uhProperty.UAlarm, result.UAlarm);
            Assert.AreEqual(uhProperty.UCatType, result.UCatType);
            Assert.AreEqual(uhProperty.UCeilingHoist, result.UCeilingHoist);
            Assert.AreEqual(uhProperty.UDisabledExtend, result.UDisabledExtend);
            Assert.AreEqual(uhProperty.UDhExtProg, result.UDhExtProg);
            Assert.AreEqual(uhProperty.UDhIntProg, result.UDhIntProg);
            Assert.AreEqual(uhProperty.UIntBalcony, result.UIntBalcony);
            Assert.AreEqual(uhProperty.UWchairIntAccess, result.UWchairIntAccess);
            Assert.AreEqual(uhProperty.ULoweredSwitches, result.ULoweredSwitches);
            Assert.AreEqual(uhProperty.URaisedSocket, result.URaisedSocket);
            Assert.AreEqual(uhProperty.UFrontRamp, result.UFrontRamp);
            Assert.AreEqual(uhProperty.URearRamp, result.URearRamp);
            Assert.AreEqual(uhProperty.UScooterStore, result.UScooterStore);
            Assert.AreEqual(uhProperty.UStairLiftType, result.UStairLiftType);
            Assert.AreEqual(uhProperty.UHandRailType, result.UHandRailType);
            Assert.AreEqual(uhProperty.URearEntSteps, result.URearEntSteps);
            Assert.AreEqual(uhProperty.UThroughLift, result.UThroughLift);
            Assert.AreEqual(uhProperty.UNoWcs, result.UNoWcs);
            Assert.AreEqual(uhProperty.UWcClosomat, result.UWcClosomat);
            Assert.AreEqual(uhProperty.UWidenedDoors, result.UWidenedDoors);
            Assert.AreEqual(uhProperty.OwnerConf, result.OwnerConf);
            Assert.AreEqual(uhProperty.EpcCertNo, result.EpcCertNo);
            Assert.AreEqual(uhProperty.EpcCertDate, result.EpcCertDate);
            Assert.AreEqual(uhProperty.EpcSurvDate, result.EpcSurvDate);
            Assert.AreEqual(uhProperty.EpcRqDate, result.EpcRqDate);
            Assert.AreEqual(uhProperty.EpcRecDate, result.EpcRecDate);
            Assert.AreEqual(uhProperty.EpcEnergy, result.EpcEnergy);
            Assert.AreEqual(uhProperty.EpcCo2, result.EpcCo2);
            Assert.AreEqual(uhProperty.ScSinkfund, result.ScSinkfund);
            Assert.AreEqual(uhProperty.US20Factor, result.US20Factor);
            Assert.AreEqual(uhProperty.UBuyBackDate, result.UBuyBackDate);
            Assert.AreEqual(uhProperty.USharedBathroom, result.USharedBathroom);
            Assert.AreEqual(uhProperty.USharedToilet, result.USharedToilet);
            Assert.AreEqual(uhProperty.UTempTenure, result.UTempTenure);
            Assert.AreEqual(uhProperty.UDisrepair, result.UDisrepair);
            Assert.AreEqual(uhProperty.ULhaArea, result.ULhaArea);
            Assert.AreEqual(uhProperty.UEstMan, result.UEstMan);
            Assert.AreEqual(uhProperty.UCleaner, result.UCleaner);
            Assert.AreEqual(uhProperty.UAhrCat, result.UAhrCat);
            Assert.AreEqual(uhProperty.USharedKitchen, result.USharedKitchen);
            Assert.AreEqual(uhProperty.URslPropRef, result.URslPropRef);
            Assert.AreEqual(uhProperty.UUsesComBoiler, result.UUsesComBoiler);
            Assert.AreEqual(uhProperty.UUsesDoorEnt, result.UUsesDoorEnt);
            Assert.AreEqual(uhProperty.UUsesLift, result.UUsesLift);
            Assert.AreEqual(uhProperty.UMwPatch, result.UMwPatch);
            Assert.AreEqual(uhProperty.UYearBuilt, result.UYearBuilt);
            Assert.AreEqual(uhProperty.UHandBackDate, result.UHandBackDate);
            Assert.AreEqual(uhProperty.UBedroomBedsize, result.UBedroomBedsize);
            Assert.AreEqual(uhProperty.UMktInfoOnline, result.UMktInfoOnline);
            Assert.AreEqual(uhProperty.UMktInfoMagazine, result.UMktInfoMagazine);
            Assert.AreEqual(uhProperty.Dtstamp, result.Dtstamp);
            Assert.AreEqual(uhProperty.UHgas, result.UHgas);
            Assert.AreEqual(uhProperty.UAccessType, result.UAccessType);
            Assert.AreEqual(uhProperty.UStorageSpace, result.UStorageSpace);
            Assert.AreEqual(uhProperty.UInternalSteps, result.UInternalSteps);
            Assert.AreEqual(uhProperty.UExternalSteps, result.UExternalSteps);
            Assert.AreEqual(uhProperty.UFulAdaptdKitchen, result.UFulAdaptdKitchen);
            Assert.AreEqual(uhProperty.UHoists, result.UHoists);
            Assert.AreEqual(uhProperty.UIntercom, result.UIntercom);
        }
    }
}
