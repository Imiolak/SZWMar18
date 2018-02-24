using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class ObjectiveStepViewModel : MvxViewModel
    {
        private readonly IObjectiveService _objectiveService;
        private ObjectiveStepBase _objective;

        public ObjectiveStepViewModel(IObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        public void Init(int objectiveNo, int orderInObjective)
        {
            _objective = _objectiveService.GetObjectiveStep<TextObjectiveStep>(objectiveNo, orderInObjective);
        }

        public string ObjectiveStepText => _objective.Type;
    }
}
