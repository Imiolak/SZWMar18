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
}
