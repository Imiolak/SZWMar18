using System.Collections.Generic;

namespace SZWMar2018.Core.Models
{
    public class TaskGameStep : GameStepBase
    {
        public string TaskText { get; set; }

        public IList<LocationMarker> Locations { get; set; }

        public string Password { get; set; }

        public string Reply { get; set; }
    }

    public class LocationMarker
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Tooltip { get; set; }
    }
}