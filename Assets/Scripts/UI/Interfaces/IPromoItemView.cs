namespace RedPanda.Project.UI
{
    public interface IPromoItemView
    {
        void PlayPurchased();
        void PlayNotPurchased();
        void UpdateMoney(float amount);
    }
}