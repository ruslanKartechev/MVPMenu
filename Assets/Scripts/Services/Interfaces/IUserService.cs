namespace RedPanda.Project.Services.Interfaces
{
    public interface IUserService
    {
        public int Currency { get; }
        void AddCurrency(int delta);
        void ReduceCurrency(int delta);
        bool HasCurrency(int amount);
    }
}