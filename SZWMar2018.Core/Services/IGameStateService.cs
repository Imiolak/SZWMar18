namespace SZWMar2018.Core.Services
{
    public interface IGameStateService
    {
        bool GetGameStarted();

        void StartGame();

        void ResetGame();

        int GetNumberOfObjectives();

        int GetCurrentActiveGamePart();

        void AdvanceToNextGamePart();
    }
}
