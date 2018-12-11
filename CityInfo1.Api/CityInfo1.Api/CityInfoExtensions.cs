using CityInfo1.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo1.Api
{
    public  static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if(context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Name1",
                    Description= "Description1",
                    PointOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "POCName1"
                            //Description= "Description1",
                        },
                        new PointOfInterest()
                        {
                             Name = "POCName2"
                            //Description= "Description2",
                        }
                    }
                },
                new City()
                {
                    Name = "Name2",
                    Description= "Description2",
                    PointOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "POCName3"
                            //Description= "Description3",
                        },
                        new PointOfInterest()
                        {
                            Name = "POCName4"
                            //Description= "Description4",
                        }
                    }
                },
                new City()
                {
                    Name = "Name3",
                    Description= "Description3",
                    PointOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "POCName5"
                            //Description= "Description5",
                        },
                        new PointOfInterest()
                        {
                            Name = "POCName6",
                            //Description= "Description6",
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
