using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo1.Api.Models
{
    public class CityWithoutPointsOfInterestDto
    {
        public int Id { get; internal set; }
        public string Description { get; internal set; }
        public string Name { get; internal set; }
    }
}
