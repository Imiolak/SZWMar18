namespace SZWMar2018.Core.Services
{
    public interface IGameStateService
    {
        bool GetGameStarted();

        void StartGame();

        void ResetGame();

        int GetNumberOfObjectives();

        int GetCurrentActiveObjectiveNo();

        void AdvanceToNextObjective();
    }
}
