using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class TaskGameStepViewModel : MvxViewModel
    {
        private readonly IGamePartService _gamePartService;

        private TaskGameStep _gameStep;

        public TaskGameStepViewModel(IGamePartService gamePartService)
        {
            _gamePartService = gamePartService;
        }

        public void Init(int gamePartNo, int gameStepNo)
        {
            _gameStep = _gamePartService.GetGamePart(gamePartNo)
                .GetGamePartStep(gameStepNo) as TaskGameStep;
        }
    }
}
