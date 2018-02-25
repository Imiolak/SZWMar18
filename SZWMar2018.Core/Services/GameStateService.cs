namespace SZWMar2018.Core.Services
{
    public class GameStateService : IGameStateService
    {
        private const string GameStartedKey = "GameStarted";
        private const string GameEndedKey = "GameEnded";
        private const string CurrentActiveGamePartKey = "CurrentActiveGamePart";

        private readonly IApplicationVariableService _applicationVariableService;

        public GameStateService(IApplicationVariableService applicationVariableService)
        {
            _applicationVariableService = applicationVariableService;
        }

        public bool GetGameStarted()
        {
            var gameStarted = _applicationVariableService.GetValueByKey(GameStartedKey);
            return gameStarted != null && bool.Parse(gameStarted);
        }

        public void StartGame()
        {
            _applicationVariableService.SetValue(GameStartedKey, true.ToString());
            _applicationVariableService.SetValue(CurrentActiveGamePartKey, 1.ToString());
        }

        public void ResetGame()
        {
            _applicationVariableService.SetValue(GameStartedKey, false.ToString());
            _applicationVariableService.SetValue(GameEndedKey, false.ToString());
        }

        public int GetNumberOfObjectives()
        {
            return int.Parse(_applicationVariableService.GetValueByKey("NumberOfObjectives"));
        }

        public int GetCurrentActiveGamePart()
        {
            return int.Parse(_applicationVariableService.GetValueByKey(CurrentActiveGamePartKey));
        }

        public void SetActiveGamePart(int newActiveGamePart)
        {
            _applicationVariableService.SetValue(CurrentActiveGamePartKey, newActiveGamePart.ToString());
        }

        public bool GetGameEnded()
        {
            var gameEndedVariable = _applicationVariableService.GetValueByKey(GameEndedKey);

            return gameEndedVariable != null
                ? bool.Parse(gameEndedVariable)
                : false;
        }

        public void EndGame()
        {
            _applicationVariableService.SetValue(GameEndedKey, true.ToString());
        }
    }
}
