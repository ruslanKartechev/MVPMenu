using System.Collections.Generic;
using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI;

namespace RedPanda.Project.Presenters
{
    public class PromoPresenter
    {
        private IPromoView _view;
        private IExportLocatorScope _container;
        private IReadOnlyList<IPromoModel> _promoModels;

        public PromoPresenter(IPromoView view, IExportLocatorScope container)
        {
            _view = view;
            _container = container;
            var promoService = _container.Locate<IPromoService>();
            _promoModels = promoService.GetPromos();
            _view.LoadItems(_promoModels);
            var userService = _container.Locate<IUserService>();
            _view.SetMoney(userService.Currency);
        }
        
    }
}