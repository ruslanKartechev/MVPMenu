using System.Collections.Generic;
using RedPanda.Project.Interfaces;

namespace RedPanda.Project.UI
{
    public interface IPromoView
    {
        void LoadItems(IReadOnlyList<IPromoModel> models);
        void SetMoney(float amount);
    }
}