using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using SZWMar2018.Core.Custom;
using SZWMar2018.Core.Interactions;
using SZWMar2018.Core.Services;
using SZWMar2018.Core.ViewModels.Game;
using ZXing;
using ZXing.Mobile;

namespace SZWMar2018.Core.ViewModels.Menu
{
    public class MenuViewModel : MvxViewModelWithNoBackStackNavigation
    {
        private readonly IGameStateService _gameStateService;

        public MenuViewModel(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public IMvxCommand StartGameCommand => new MvxCommand(StartGame);

        public IMvxCommand ActionNotImplementedCommand => new MvxCommand(ActionNotImplemented);

        private readonly MvxInteraction<DialogInteraction> _dialogInteraction = new MvxInteraction<DialogInteraction>();
        public IMvxInteraction<DialogInteraction> DialogInteraction => _dialogInteraction;
        
        private async void StartGame()
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
                TopText = "Zeskanuj kod startowy",
                CancelButtonText = "Anuluj"
            };

            var scanResult = await scanner.Scan(scannerOptions);
            if (scanResult != null)
            {
                _gameStateService.StartGame();
                ShowViewModelAndClearBackStack<GameViewModel>();
            }
        }

        private void ActionNotImplemented()
        {
            _dialogInteraction.Raise(new DialogInteraction
            {
                Title = "Jeszcze niczego tu nie ma :(",
                Text = "Soon\u2122"
            });
        }
    }
}