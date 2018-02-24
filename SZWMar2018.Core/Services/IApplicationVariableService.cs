namespace SZWMar2018.Core.Services
{
    public interface IApplicationVariableService
    {
        string GetValueByKey(string key);

        void SetValue(string key, string value);
    }
}
