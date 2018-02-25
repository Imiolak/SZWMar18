using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SZWMar2018.Core.Custom;
using SZWMar2018.Core.Interactions;
using SZWMar2018.Core.Models;
using SZWMar2018.Core.Services;
using SZWMar2018.Core.ViewModels.Menu;
using ZXing;
using ZXing.Mobile;

namespace SZWMar2018.Core.ViewModels.Game
{
    public class GameStepNavigationViewModel : MvxViewModelWithNoBackStackNavigation
    {
        private readonly IDictionary<string, Type> _viewModelTypesByGamePartStepType = new Dictionary<string, Type>
        {
            { typeof(TextGameStep).FullName, typeof(TextGameStepViewModel) },
            { typeof(TaskGameStep).FullName, typeof(TaskGameStepViewModel) }
        };

        private readonly IGameStateService _gameStateService;
        private readonly IGamePartService _gamePartService;
        private readonly int _totalGameParts;

        private int _totalSteps;

        public GameStepNavigationViewModel(IGameStateService gameStateService, 
            IGamePartService gamePartService)
        {
            _gameStateService = gameStateService;
            _gamePartService = gamePartService;


            _totalGameParts = _gamePartService.GetTotalNumberOfGameParts();
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

                RefreshView();

                ShowViewModel(_viewModelTypesByGamePartStepType[gamePartStepType], new
                {
                    gamePartNo = _currentGamePart,
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

        private readonly MvxInteraction<DialogInteraction> _dialogInteraction = new MvxInteraction<DialogInteraction>();
        public IMvxInteraction<DialogInteraction> DialogInteraction => _dialogInteraction;

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
                await AdvanceToNextGamePart(scanResult.Text);
            }
        }

        private async Task AdvanceToNextGamePart(string scanResult)
        {
            var newActiveGamePart = _currentGamePart + 1;

            if (newActiveGamePart > _totalGameParts
                && VerifyScannedCode(scanResult, "END"))
            {
                _gameStateService.EndGame();
                ShowViewModelAndClearBackStack<GameSummaryViewModel>();
            }
            else if (VerifyScannedCode(scanResult, $"LACZNIK_{_currentGamePart}"))
            {
                _gameStateService.SetActiveGamePart(newActiveGamePart);
                await Task.Delay(TimeSpan.FromMilliseconds(150));

                CurrentGamePart = newActiveGamePart;
            }
            else
            {
                _dialogInteraction.Raise(new DialogInteraction
                {
                    Title = "Niepoprawny kod",
                    Text = "Kod, który próbujesz zeskanować jest niepoprawny, lub nie nadaje się do zeskanowania w tym momencie gry. Skontaktuj się z organizatorem."
                });
            }
        }

        private static bool VerifyScannedCode(string scannedCode, string expectedPrefix)
        {
            return scannedCode.StartsWith(expectedPrefix);
        }

        private void RefreshView()
        {
            RaisePropertyChanged(nameof(PreviousStepButtonVisible));
            RaisePropertyChanged(nameof(NextStepButtonVisible));
            RaisePropertyChanged(nameof(ScanCodeButtonVisible));
        }
    }
}
