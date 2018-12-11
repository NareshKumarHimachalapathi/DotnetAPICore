using AutoMapper;
using CityInfo1.Api.Models;
using CityInfo1.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo1.Api
{
    public class CitiesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        //[HttpGet("api/cities")]
        //public JsonResult GetCities()
        //{
        //    return new JsonResult(CityDataStore.Current.Cities);            
        //}

        //[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CityDataStore.Current.Cities.FirstOrDefault( c => c.Id == id));
        //}

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet("api/cities")]
        public IActionResult GetCities()
        {
            //return Ok(CityDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();

            //var results = new List<CityWithoutPointsOfInterestDto>();

            //foreach(var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto {
            //        Id = cityEntity.Id,
            //        Description  = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
           var cityToReturn = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if(cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
