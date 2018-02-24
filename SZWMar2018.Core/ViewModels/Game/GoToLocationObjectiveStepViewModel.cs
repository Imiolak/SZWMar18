using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class GoToLocationObjectiveStepViewModel : MvxViewModel
    {
        private readonly IObjectiveService _objectiveService;
        private GoToLocationObjectiveStep _objectiveStep;

        public GoToLocationObjectiveStepViewModel(IObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        public void Init(int objectiveNo, int orderInObjective)
        {
            _objectiveStep = _objectiveService.GetObjectiveStep<GoToLocationObjectiveStep>(objectiveNo, orderInObjective);
        }

        public double Latitude => _objectiveStep.Latitude;

        public double Longitude => _objectiveStep.Longitude;
    }
}
