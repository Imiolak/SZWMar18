using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Menu
{
    public class GameSummaryViewModel : MvxViewModel
    {
        private readonly IGameStateService _gameStateService;

        public GameSummaryViewModel(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public string ElapsedTime
        {
            get
            {
                var totalElapsedMinutes = _gameStateService.GetGameElapsedTime();
                var hours = totalElapsedMinutes / 60;
                var minutes = totalElapsedMinutes % 60;

                return $"{hours}h {minutes}min";
            }
        }
    }
}
