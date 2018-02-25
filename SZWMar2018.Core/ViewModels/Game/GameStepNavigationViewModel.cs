using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;
using ZXing;
using ZXing.Mobile;

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
        
        private int _totalSteps;

        public GameStepNavigationViewModel(IGameStateService gameStateService, 
            IGamePartService gamePartService)
        {
            _gameStateService = gameStateService;
            _gamePartService = gamePartService;

            CurrentGamePart = gameStateService.GetCurrentActiveGamePart();
        }

        private int _currentGamePart;
        public int CurrentGamePart
        {
            get => _currentGamePart;
            set
            {
                _currentGamePart = value;

                _totalSteps = _gamePartService.GetGamePart(_currentGamePart)
                    .Steps
                    .Count;

                CurrentGamePartStep = 1;
            }
        }

        private int _currentStep;
        public int CurrentGamePartStep
        {
            get => _currentStep;
            set
            {
                _currentStep = value;
                var gamePartStepType = _gamePartService.GetGamePart(_currentGamePart)
                    .GetGamePartStep(_currentStep)
                    .GetType()
                    .FullName;
                
                ShowViewModel(_viewModelTypesByGamePartStepType[gamePartStepType], new
                {
                    gamePartNo = _currentGamePart,
                    gameStepNo = _currentStep
                });

                RefreshView();
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
            RefreshView();
        }

        private void NextStep()
        {
            CurrentGamePartStep++;
            RefreshView();
        }

        private async void ScanCode()
        {
            var scannerOptions = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat>
                {
                    BarcodeFormat.QR_CODE
                }
            };
            var scanner = new MobileBarcodeScanner
            {
                TopText = "Zeskanuj kod",
                CancelButtonText = "Anuluj"
            };

            var scanResult = await scanner.Scan(scannerOptions);
            if (scanResult != null)
            {
                var newActiveGamePart = _currentGamePart + 1;

                _gameStateService.SetActiveGamePart(newActiveGamePart);
                await Task.Delay(TimeSpan.FromMilliseconds(150));

                CurrentGamePart = newActiveGamePart;
            }
        }

        private void RefreshView()
        {
            RaisePropertyChanged(nameof(PreviousStepButtonVisible));
            RaisePropertyChanged(nameof(NextStepButtonVisible));
            RaisePropertyChanged(nameof(ScanCodeButtonVisible));
        }
    }
}
