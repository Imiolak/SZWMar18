using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Services;
using SZWMar2018.Core.ViewModels.Game;
using SZWMar2018.Core.ViewModels.Menu;

namespace SZWMar2018.Core.Custom
{
    public class CustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IGameStateService _gameStateService;

        public CustomAppStart(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void Start(object hint = null)
        {
            if (_gameStateService.GetGameStarted())
            {
                if (!_gameStateService.GetGameEnded())
                {
                    ShowViewModel<GameViewModel>();
                }
                else
                {
                    ShowViewModel<GameSummaryViewModel>();
                }
            }
            else
            {
                ShowViewModel<MenuViewModel>();
            }
        }
    }
}
