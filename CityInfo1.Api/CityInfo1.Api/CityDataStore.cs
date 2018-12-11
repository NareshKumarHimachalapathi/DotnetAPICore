using CityInfo1.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo1.Api
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<CityDto> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Name1",
                    Description= "Description1",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "POCName1",
                            Description= "Description1",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "POCName2",
                            Description= "Description2",
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Name2",
                    Description= "Description2",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "POCName3",
                            Description= "Description3",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "POCName4",
                            Description= "Description4",
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Name3",
                    Description= "Description3",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "POCName5",
                            Description= "Description5",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "POCName6",
                            Description= "Description6",
                        }
                    }
                }
            };
        }
    }
}
