using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using property_api.V1.Domain;
using Moq;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using Newtonsoft.Json;
using property_api.V1.UseCase.GetMultipleProperties;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class PropertyControllerGetMultiplePropertiesTests
    {
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyUseCase> _mockGetPropertyUseCase;
        private Mock<IGetMultiplePropertiesUseCase> _mockGetMultiplePropertiesUseCase;
        private Mock<ILogger<PropertyController>> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockGetPropertyUseCase = new Mock<IGetPropertyUseCase>();
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _mockGetMultiplePropertiesUseCase = new Mock<IGetMultiplePropertiesUseCase>();
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object, _mockLogger.Object, _mockGetMultiplePropertiesUseCase.Object);
        }

        [TestCase("1", "2")]
        [TestCase("3", "4")]
        public void GivenAListOfMultipleProperties_WhenIExecute_ThenParametersArePassedIntoTheUseCase(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertyReferences = new GetMultiplePropertiesUseCaseRequest(new List<string> {propertyReference, propertyReference2});
            //act
            _classUnderTest.GetMultipleByReference(propertyReferences);
            //assert
            _mockGetMultiplePropertiesUseCase.Verify(v=> v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i=> i.PropertyReferences[0] == propertyReference && i.PropertyReferences[1] == propertyReference2)), Times.Once);
        }

        [TestCase("65", "57")]
        [TestCase("8", "9")]
        public void GivenAValidListOfMultipleProperyRefs_WhenIExecute_ThenTheUseCaseReturnsGetMultiplePropertiesUseCaseResponse(string propertyReference, string propertyReference2)
        {
            //arrange
            IList<Property> properties = new List<Property>
                    {
                        new Property
                        {
                            PropRef = propertyReference
                        },
                        new Property
                        {
                            PropRef = propertyReference2
                        }
                    };

            _mockGetMultiplePropertiesUseCase
                .Setup(v => v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i =>
                    i.PropertyReferences[0] == propertyReference && i.PropertyReferences[1] == propertyReference2)))
                .Returns(new GetMultiplePropertiesUseCaseResponse(properties));

            var propertyReferencesRequest = new GetMultiplePropertiesUseCaseRequest(new List<string> { propertyReference, propertyReference2 });
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(propertyReferencesRequest);
            //assert
            actionResult.Should().NotBeNull();
            var okObjectResult = (OkObjectResult)actionResult;
            var response = (GetMultiplePropertiesUseCaseResponse)okObjectResult.Value;
            response.Should().NotBeNull();
            response.Properties.Should().NotBeNullOrEmpty();

            response.Properties.Should().BeOfType<List<Property>>();
            Assert.AreSame(propertyReference, response.Properties[0].PropRef);
            Assert.AreSame(propertyReference2, response.Properties[1].PropRef);
        }

        [TestCase(" ", "10", "'Property References' must not contain null or empty values such as whitespace (' ') given")]
        [TestCase("", "7", "'Property References' must not contain null or empty values such as whitespace ('') given")]
        [TestCase("3", null, "'Property References' must not be empty.")]
        public void GivenAnInvalidListOfMultiplePropertyRefs_ItShouldReturnBadInput(string propertyReference, string propertyReference2, string errorMessage)
        {
            //arrange
            var propertyReferencesRequest = new GetMultiplePropertiesUseCaseRequest(new List<string> { propertyReference, propertyReference2 });
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(propertyReferencesRequest);
            //assert
            var json = JsonConvert.SerializeObject(((BadRequestObjectResult) actionResult).Value);
            Assert.AreEqual(JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "validRequest", false },
                { "errors", new [] {
                    errorMessage
                }},
                { "properties", new List<string>() }
            }), json);
        }

        [Test]
        public void GivenNull_ItShouldReturnBadInput()
        {
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(new GetMultiplePropertiesUseCaseRequest(null));
            //assert
            actionResult.Should().BeOfType<BadRequestObjectResult>();

            var json = JsonConvert.SerializeObject(((BadRequestObjectResult) actionResult).Value);
            Assert.AreEqual(JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "validRequest", false },
                { "errors", new [] {
                    "'Property References' must not be empty."
                }},
                { "properties", new List<string>() }
            }), json);
        }

        [Test]
        public void GivenNoPropRefs_ItShouldReturnBadInput()
        {
            //arrange
            var propertyReferences = new GetMultiplePropertiesUseCaseRequest(new List<string>());
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(propertyReferences);
            //assert
            actionResult.Should().BeOfType<BadRequestObjectResult>();
            var json = JsonConvert.SerializeObject(((BadRequestObjectResult) actionResult).Value);
            Assert.AreEqual(JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "validRequest", false },
                { "errors", new [] {
                    "'Property References' must not contain null or empty values such as whitespace"
                }},
                { "properties", new List<string>() }
            }), json);
        }

        [Test]
        public void GivenTooMannyPropRefs_ItShouldReturnBadInput()
        {
            //arrange
            List<string> propertyReferences = new List<string>();
            foreach (var i in Enumerable.Range(0, 201))
            {
                propertyReferences.Add(i.ToString());
            }

            var getMultiplePropertiesUseCaseRequest = new GetMultiplePropertiesUseCaseRequest(propertyReferences);
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(getMultiplePropertiesUseCaseRequest);
            //assert
            actionResult.Should().BeOfType<BadRequestObjectResult>();

            Assert.AreEqual(400, ((BadRequestObjectResult) actionResult).StatusCode);

            var json = JsonConvert.SerializeObject(((BadRequestObjectResult) actionResult).Value);
            Assert.AreEqual(JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "validRequest", false },
                { "errors", new [] {
                       "The number of 'PropertyReferences' given must be more than 0 and less than 200. (201 given)" }
                },
                { "properties", new List<string>() }
            }), json);
        }

        [Test]
        public void ReturnsCorrectResponseWithStatus()
        {
            var property = new Property
            {
                PropRef = "1",
                Telephone = "0500 906761",
                ManagedProperty = true,
                Ownership = "zuxmsjdxn",
                Letable = true,
                Lounge = true,
                Laundry = true,
                CoreShared = true,
                Asbestos = true,
                Tstamp = null,
                NoSingleBeds = 1,
                NoDoubleBeds = 3,
                Repairable = true,
                Dtstamp = new DateTime(2019, 03, 03, 12, 12, 12)
            };


            _mockGetMultiplePropertiesUseCase.Setup(s =>
                    s.Execute(It.IsAny<GetMultiplePropertiesUseCaseRequest>()))
                .Returns(new GetMultiplePropertiesUseCaseResponse(new List<Property>{ property }));

            ObjectResult response = (ObjectResult)_classUnderTest.GetMultipleByReference(new GetMultiplePropertiesUseCaseRequest(new List<String> { "foo" }));

            var json = JsonConvert.SerializeObject(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(expectedJSON(), json);
        }

        private string expectedJSON()
        {
            string json =
@"{
  ""validRequest"": true,
  ""errors"": [],
  ""properties"": [
    {
      ""propRef"": ""1"",
      ""levelCode"": null,
      ""majorRef"": null,
      ""manScheme"": null,
      ""postCode"": null,
      ""postDesig"": null,
      ""shortAddress"": null,
      ""telephone"": ""0500 906761"",
      ""managedProperty"": true,
      ""ownership"": ""zuxmsjdxn"",
      ""agent"": null,
      ""comments"": null,
      ""housingOfficer"": null,
      ""areaOffice"": null,
      ""subtypCode"": null,
      ""conditionCode"": null,
      ""wardenRef"": null,
      ""laRef"": null,
      ""waterRef"": null,
      ""schemeRef"": null,
      ""insurPolicy"": null,
      ""letable"": true,
      ""practicalCompletion"": null,
      ""handover"": null,
      ""catType"": null,
      ""lounge"": true,
      ""laundry"": true,
      ""visitorBed"": false,
      ""store"": false,
      ""wardenFlat"": false,
      ""sheltered"": false,
      ""houseRef"": null,
      ""occStat"": null,
      ""cyclicalDue"": null,
      ""shower"": false,
      ""heating"": null,
      ""repArea"": null,
      ""acMeth"": null,
      ""propsize"": null,
      ""rtb"": false,
      ""ratevalue"": null,
      ""postPreamble"": null,
      ""coreShared"": true,
      ""repOfficer"": null,
      ""insValue"": null,
      ""uNom2"": null,
      ""region"": null,
      ""asbestos"": true,
      ""accomfund"": null,
      ""candsfund"": null,
      ""propertySid"": null,
      ""keys"": null,
      ""company"": null,
      ""lettArea"": null,
      ""rtbApplication"": null,
      ""noMaint"": null,
      ""maintresp"": null,
      ""leasehold"": null,
      ""s125"": null,
      ""plannedRepairArea"": null,
      ""lraRef"": null,
      ""coCode"": null,
      ""repSubarea"": null,
      ""conKey"": null,
      ""walkNo"": null,
      ""walkSequence"": null,
      ""tstamp"": null,
      ""alinefull"": null,
      ""arrPatch"": null,
      ""arrOfficer"": null,
      ""dhStatus"": null,
      ""dhAssdate"": null,
      ""dhYearfail"": null,
      ""dhCostnow"": null,
      ""dhCostatfail"": null,
      ""sapRating"": null,
      ""nherRating"": null,
      ""numBedrooms"": null,
      ""commLifts"": null,
      ""entLevel"": null,
      ""intFloors"": null,
      ""gardenType"": null,
      ""petsAllowed"": null,
      ""parking"": null,
      ""minageRestric"": null,
      ""familySize"": null,
      ""childAllowed"": null,
      ""localConn"": null,
      ""allocPanel"": null,
      ""numSteps"": null,
      ""garage"": null,
      ""maxageRestric"": null,
      ""stairLift"": null,
      ""throughLift"": null,
      ""accShower"": null,
      ""ramp"": null,
      ""handRails"": null,
      ""diningRoom"": null,
      ""kitchenDining"": null,
      ""secToileta"": null,
      ""secToiletb"": null,
      ""cookingFuel"": null,
      ""compAvail"": null,
      ""compDisplay"": null,
      ""noSingleBeds"": 1,
      ""noDoubleBeds"": 3,
      ""onlineRepairs"": false,
      ""vmPropref"": null,
      ""voidmanLive"": null,
      ""repairable"": true,
      ""address1"": null,
      ""uPropZone"": null,
      ""uSurveyorPatch"": null,
      ""uEstate"": null,
      ""uBlock"": null,
      ""uLocation"": null,
      ""uRentAccount"": null,
      ""uFloors"": null,
      ""uLivingRooms"": null,
      ""uAccess"": null,
      ""uAmarchetype"": null,
      ""uPriorityEstate"": null,
      ""uCommEntry"": null,
      ""uConsultStat"": null,
      ""uCorrWidth"": null,
      ""uDpaService"": null,
      ""uEstQuality"": null,
      ""uEstSecurity"": null,
      ""uExtDecent"": null,
      ""uGasComments"": null,
      ""uGasServiceReq"": null,
      ""uIntDecent"": null,
      ""uLeverTaps"": null,
      ""uLiftManufact"": null,
      ""uRtbStart"": null,
      ""uSoldLeased"": null,
      ""uSoldLeasedDate"": null,
      ""uDisabledOnly"": null,
      ""uDateDisposedDue"": null,
      ""uLeasedFrom"": null,
      ""uLeaseEndDate"": null,
      ""uEstateManagement"": null,
      ""uAccessFloor"": null,
      ""uLiftAvailable"": null,
      ""uBlockFloors"": null,
      ""uBalcony"": null,
      ""uDoorEntry"": null,
      ""uCouncilProperty"": null,
      ""uOapOnly"": null,
      ""uDisabledOccupier"": null,
      ""uEstateMapRef"": null,
      ""uPlanType"": null,
      ""uYearConstructed"": null,
      ""uCollectionRound"": null,
      ""uTemporaryAccom"": null,
      ""uWindowType"": null,
      ""uQualityIndex"": null,
      ""uAsbestosItem"": null,
      ""uDisposedType"": null,
      ""uRentSubzone"": null,
      ""uLegalCases"": null,
      ""uAsbestosDate"": null,
      ""uLlpgRef"": null,
      ""uLiftType"": null,
      ""uGhostBlock"": null,
      ""uGhostAddress"": null,
      ""uPropAreaLoc"": null,
      ""uOldFinanceCode"": null,
      ""uHaProperty"": null,
      ""uMobilityStd"": null,
      ""uMobilityWchair"": null,
      ""uNoLifts"": null,
      ""uNorthing"": null,
      ""uOverallDecent"": null,
      ""uPropSortKey"": null,
      ""uRaisedSockets"": null,
      ""uRampedAccess"": null,
      ""uStairLift"": null,
      ""uWchairStd"": null,
      ""uKitchenunit"": null,
      ""uReasondisposed"": null,
      ""uMraarchetype"": null,
      ""uAssetarchetype"": null,
      ""uHraarchetype"": null,
      ""uLsvtarchetype"": null,
      ""uBeaconcodes"": null,
      ""uLlpgref1"": null,
      ""uAlarm"": null,
      ""uCatType"": null,
      ""uCeilingHoist"": null,
      ""uDisabledExtend"": null,
      ""uDhExtProg"": null,
      ""uDhIntProg"": null,
      ""uIntBalcony"": null,
      ""uWchairIntAccess"": null,
      ""uLoweredSwitches"": null,
      ""uRaisedSocket"": null,
      ""uFrontRamp"": null,
      ""uRearRamp"": null,
      ""uScooterStore"": null,
      ""uStairLiftType"": null,
      ""uHandRailType"": null,
      ""uRearEntSteps"": null,
      ""uThroughLift"": null,
      ""uNoWcs"": null,
      ""uWcClosomat"": null,
      ""uWidenedDoors"": null,
      ""ownerConf"": null,
      ""epcCertNo"": null,
      ""epcCertDate"": null,
      ""epcSurvDate"": null,
      ""epcRqDate"": null,
      ""epcRecDate"": null,
      ""epcEnergy"": null,
      ""epcCo2"": null,
      ""scSinkfund"": null,
      ""uS20Factor"": null,
      ""uBuyBackDate"": null,
      ""uSharedBathroom"": null,
      ""uSharedToilet"": null,
      ""uTempTenure"": null,
      ""uDisrepair"": null,
      ""uLhaArea"": null,
      ""uEstMan"": null,
      ""uCleaner"": null,
      ""uAhrCat"": null,
      ""uSharedKitchen"": null,
      ""uRslPropRef"": null,
      ""uUsesComBoiler"": null,
      ""uUsesDoorEnt"": null,
      ""uUsesLift"": null,
      ""uMwPatch"": null,
      ""uYearBuilt"": null,
      ""uHandBackDate"": null,
      ""uBedroomBedsize"": null,
      ""uMktInfoOnline"": null,
      ""uMktInfoMagazine"": null,
      ""dtstamp"": ""2019-03-03T12:12:12Z"",
      ""uHgas"": null,
      ""uAccessType"": null,
      ""uStorageSpace"": null,
      ""uInternalSteps"": null,
      ""uExternalSteps"": null,
      ""uFulAdaptdKitchen"": null,
      ""uHoists"": null,
      ""uIntercom"": null
    }
  ]
}";
            return json;
        }
    }
}
