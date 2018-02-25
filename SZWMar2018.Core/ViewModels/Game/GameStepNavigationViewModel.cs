using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class GameStepNavigationViewModel : MvxViewModel
    {
        private readonly IDictionary<string, Type> _viewModelTypesByGamePartStepType = new Dictionary<string, Type>
        {
            { typeof(TextGameStep).FullName, typeof(TextGameStepViewModel) },
            { typeof(TaskGameStep).FullName, typeof(TaskGameStepViewModel) }
        };

        private readonly IGameStateService _gameStateService;
        private readonly IGamePartService _gamePartService;

        private int _gamePartNo;
        private int _totalSteps;
        private GamePart _gamePart;

        public GameStepNavigationViewModel(IGameStateService gameStateService, 
            IGamePartService gamePartService)
        {
            _gameStateService = gameStateService;
            _gamePartService = gamePartService;

            _gamePartNo = gameStateService.GetCurrentActiveGamePart();
            _gamePart = _gamePartService.GetGamePart(_gamePartNo);
            _totalSteps = _gamePart.Steps
                .Count;

            CurrentGamePartStep = 1;
        }

        private int _currentStep;
        public int CurrentGamePartStep
        {
            get => _currentStep;
            set
            {
                _currentStep = value;
                var gamePartStepType = _gamePart.GetGamePartStep(_currentStep)
                    .GetType()
                    .FullName;
                
                ShowViewModel(_viewModelTypesByGamePartStepType[gamePartStepType], new
                {
                    gamePartNo = _gamePartNo,
                    gameStepNo = _currentStep
                });
            }
        }

        public bool PreviousStepButtonVisible => _currentStep > 1;

        public bool NextStepButtonVisible => _currentStep != _totalSteps;

        public bool ScanCodeButtonVisible => _currentStep == _totalSteps;

        public IMvxCommand PreviousStepCommand => new MvxCommand(PreviousStep);

        public IMvxCommand NextStepCommand => new MvxCommand(NextStep);

        public IMvxCommand ScanCodeCommand => new MvxCommand(ScanCode);

        private void PreviousStep()
        {
            CurrentGamePartStep--;

            RaisePropertyChanged(nameof(PreviousStepButtonVisible));
            RaisePropertyChanged(nameof(NextStepButtonVisible));
            RaisePropertyChanged(nameof(ScanCodeButtonVisible));
        }

        private void NextStep()
        {
            CurrentGamePartStep++;

            RaisePropertyChanged(nameof(PreviousStepButtonVisible));
            RaisePropertyChanged(nameof(NextStepButtonVisible));
            RaisePropertyChanged(nameof(ScanCodeButtonVisible));
        }

        private void ScanCode()
        {
        }
    }
}
