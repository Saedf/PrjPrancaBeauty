namespace PrancaBeauty.WebApp.Localization
{
    public interface ILocalizer
    {
        public string this[string Name] { get; }
        public string this[string Name, params object[] argumets] { get; }
    }
}
