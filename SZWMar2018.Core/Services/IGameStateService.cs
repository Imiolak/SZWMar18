﻿namespace SZWMar2018.Core.Services
{
    public interface IGameStateService
    {
        bool GetGameStarted();

        void StartGame();

        void ResetGame();

        int GetNumberOfObjectives();

        int GetCurrentActiveGamePart();

        void SetActiveGamePart(int newActiveGamePart);

        bool GetGameEnded();

        void EndGame();

        int GetGameElapsedTime();
    }
}
