using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class MapViewModel : MvxViewModel
    {
        private readonly IGamePartService _gamePartService;

        public MapViewModel(IGamePartService gamePartService)
        {
            _gamePartService = gamePartService;
        }

        public void Init(int gamePartNo, int gameStepNo)
        {
            var gameStep = (TaskGameStep) _gamePartService.GetGamePart(gamePartNo)
                .Steps
                .First(s => s.PlaceInGamePart == gameStepNo);

            LocationMarkers = gameStep.Locations;
        }

        public IList<LocationMarker> LocationMarkers { get; set; }
    }
}
