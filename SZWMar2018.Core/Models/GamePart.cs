using System.Collections.Generic;
using System.Linq;

namespace SZWMar2018.Core.Models
{
    public class GamePart
    {
        public IList<string> StepTypes { get; set; }

        public IList<GameStepBase> Steps { get; set; }

        public GameStepBase GetGamePartStep(int gamePartStepNo)
        {
            return Steps.FirstOrDefault(s => s.PlaceInGamePart == gamePartStepNo);
        }
    }

    public abstract class GameStepBase
    {
        public int PlaceInGamePart { get; set; }
    }

    public class TextGameStep : GameStepBase
    {
        public string Text { get; set; }
    }

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
