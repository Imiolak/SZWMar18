using MvvmCross.Core.ViewModels;
using System.Text;
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

        public string MarkersPlaceholder => BuildMarkersPlaceholder();

        private string BuildMarkersPlaceholder()
        {
            var builder = new StringBuilder("Tu będzie mapa z zaznaczonymi następującymi punktami:");
            builder.AppendLine();

            foreach (var location in _gameStep.Locations)
            {
                builder.AppendLine(location.Tooltip);
                builder.AppendLine($"Szerokość geo: {location.Latitude}");
                builder.AppendLine($"Długość geo: {location.Longitude}");
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
