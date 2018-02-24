namespace SZWMar2018.Core.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly IApplicationVariableService _applicationVariableService;

        public GameStateService(IApplicationVariableService applicationVariableService)
        {
            _applicationVariableService = applicationVariableService;
        }

        public bool GetGameStarted()
        {
            var gameStarted = _applicationVariableService.GetValueByKey("GameStarted");
            return gameStarted != null && bool.Parse(gameStarted);
        }

        public void StartGame()
        {
            _applicationVariableService.SetValue("GameStarted", true.ToString());
            _applicationVariableService.SetValue("CurrentActiveGamePart", 1.ToString());
        }

        public void ResetGame()
        {
            _applicationVariableService.SetValue("GameStarted", false.ToString());
        }

        public int GetNumberOfObjectives()
        {
            return int.Parse(_applicationVariableService.GetValueByKey("NumberOfObjectives"));
        }

        public int GetCurrentActiveGamePart()
        {
            return int.Parse(_applicationVariableService.GetValueByKey("CurrentActiveGamePart"));
        }

        public void AdvanceToNextGamePart()
        {
            throw new System.NotImplementedException();
        }
    }
}
