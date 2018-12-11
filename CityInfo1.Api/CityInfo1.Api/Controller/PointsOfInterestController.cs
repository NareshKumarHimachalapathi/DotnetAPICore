using CityInfo1.Api.Models;
using CityInfo1.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CityInfo1.Api.Controller
{
    [Route("api/cities")]
    public class PointsOfInterestController :  Microsoft.AspNetCore.Mvc.Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private ILocalMailService _localMailService;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, ILocalMailService localMailService)
        {
            _logger = logger;
            _localMailService = localMailService;
        }

        [HttpGet("{cityId}/pointofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                //throw new System.Exception("Exception Sample");

                var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} wasnt found");
                    return NotFound();
                }
                _localMailService.Send("test subject", "Test message");
                return Ok(city.PointOfInterest);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Exception while getting the City : {cityId}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{cityId}/pointofinterest/{id}" , Name ="GetPointOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointofinterest")]
        public IActionResult CreatePointsOfInterest(int cityId, [FromBody] PointOfInterestCreationDto pointofInterest)
        {
            if (pointofInterest == null)
            {
                return BadRequest();
            }

            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CityDataStore.Current.Cities.SelectMany(c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointofInterest.Name,
                Description = pointofInterest.Description
            };

            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",new {cityId = cityId, Id= finalPointOfInterest .Id});
        }

        [HttpPatch("{cityId}/pointofinterest/{id}")]
        public IActionResult UpdatePointsOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
    }
}
