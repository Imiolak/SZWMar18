using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Custom;
using SZWMar2018.Core.Services;
using SZWMar2018.Core.ViewModels.Menu;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class GameViewModel : MvxViewModelWithNoBackStackNavigation
    {
        private readonly IGameStateService _gameStateService;

        public GameViewModel(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public IMvxCommand ResetGameCommand => new MvxCommand(ResetGame);

        private void ResetGame()
        {
            _gameStateService.ResetGame();
            ShowViewModelAndClearBackStack<MenuViewModel>();
        }
    }
}
