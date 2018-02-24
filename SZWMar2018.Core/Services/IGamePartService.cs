using SZWMar2018.Core.Models;

namespace SZWMar2018.Core.Services
{
    public interface IGamePartService
    {
        GamePart GetGamePart(int gamePartNo);
        int GetTotalNumberOfGameParts();
    }
}