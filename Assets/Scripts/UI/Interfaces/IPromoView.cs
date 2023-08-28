using System.Collections.Generic;
using RedPanda.Project.Interfaces;

namespace RedPanda.Project.UI
{
    public interface IPromoView
    {
        public void ShowItemsGroup(string label, IList<IPromoModel> model);
        void SetMoney(float amount);
    }
}