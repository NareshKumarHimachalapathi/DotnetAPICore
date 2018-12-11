using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo1.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace CityInfo1.Api.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointOfInterest)
        {
           if (includePointOfInterest)
            {
                return _context.Cities.Include(c => c.PointOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }

           return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointOfInterest.Where(p => p.CityId == cityId && p.Id== pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointOfInterest.Where(p => p.CityId == cityId).ToList();
        }
    }
}
