using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI;
using Utils;

namespace RedPanda.Project.Presenters
{
    public class PromoItemPresenter
    {
        private IExportLocatorScope _container;
        private IPromoItemView _view;
        private IPromoModel _model;
        private IUserService _userService;
        
        
        public PromoItemPresenter(IExportLocatorScope container, IPromoModel model, IPromoItemView view)
        {
            _container = container;
            _model = model;
            _view = view;
            _userService = _container.Locate<IUserService>();
        }

        public void TryPurchase()
        {
            if (_userService.HasCurrency(_model.Cost))
            {
                _userService.ReduceCurrency(_model.Cost);
                _view.PlayPurchased();
                _view.UpdateMoney(_userService.Currency);
                CLog.LogWHeader("PromoItem", $"Purchased item: {_model.Title}", "g", "w");
                return;
            }
            _view.PlayNotPurchased();
            CLog.LogWHeader("PromoItem ERROR", $"Not enough money. Cost {_model.Cost}", "r", "w");
        }
        
    }
}
