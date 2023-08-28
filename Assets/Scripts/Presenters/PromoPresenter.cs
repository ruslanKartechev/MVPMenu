using System.Collections.Generic;
using Grace.DependencyInjection;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI;
using RedPanda.Project.Utils;

namespace RedPanda.Project.Presenters
{
    public class PromoPresenter
    {
        private IPromoView _view;
        private IExportLocatorScope _container;
        
        public PromoPresenter(IPromoView view, IExportLocatorScope container)
        {
            _view = view;
            _container = container;
            var promoService = _container.Locate<IPromoService>();
            var userService = _container.Locate<IUserService>();
            _view.SetMoney(userService.Currency);
            DisplaySortedModels(promoService.GetPromos());
        }

        private void DisplaySortedModels(IEnumerable<IPromoModel> promoModels)
        {
            var modelsByType = new Dictionary<PromoType, IList<IPromoModel>>();
            foreach (var model in promoModels)
            {
                if (modelsByType.ContainsKey(model.Type) == false)
                    modelsByType.Add(model.Type, new List<IPromoModel>());
                modelsByType[model.Type].Add(model);
            }

            foreach (var pair in modelsByType)
            {
                PromoSorter.SortByRarity(pair.Value);
                _view.ShowItemsGroup(pair.Key.ToString(), pair.Value);
            }
        }
        
    }
}