using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class TextObjectiveStepViewModel : MvxViewModel
    {
        private readonly IObjectiveService _objectiveService;
        private TextObjectiveStep _objectiveStep;

        public TextObjectiveStepViewModel(IObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        public void Init(int objectiveNo, int orderInObjective)
        {
            _objectiveStep = _objectiveService.GetObjectiveStep<TextObjectiveStep>(objectiveNo, orderInObjective);
        }

        public string Content => _objectiveStep.Text;
    }
}
