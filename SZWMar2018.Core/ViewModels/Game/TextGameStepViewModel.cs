using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class TextGameStepViewModel : MvxViewModel
    {
        private readonly IGamePartService _gamePartService;

        private TextGameStep _gameStep;

        public TextGameStepViewModel(IGamePartService gamePartService)
        {
            _gamePartService = gamePartService;
        }

        public void Init(int gamePartNo, int gameStepNo)
        {
            _gameStep = _gamePartService.GetGamePart(gamePartNo)
                .GetGamePartStep(gameStepNo) as TextGameStep;
        }

        public string Content => _gameStep.Text;
    }
}
