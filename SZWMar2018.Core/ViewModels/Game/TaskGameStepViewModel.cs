using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
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

        public string TaskSummary => _gameStep.TaskText;

        public string Password => _gameStep.Password;

        public string Reply => _gameStep.Reply;

        public bool PasswordReplyVisible => !string.IsNullOrWhiteSpace(_gameStep.Password);

        public IList<LocationMarker> LocationMarkers => _gameStep.Locations;
    }
}
