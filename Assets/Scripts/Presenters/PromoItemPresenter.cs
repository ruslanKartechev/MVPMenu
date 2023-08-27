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
        private IUserService _service;
        
        
        public PromoItemPresenter(IExportLocatorScope container, IPromoModel model, IPromoItemView view)
        {
            _container = container;
            _model = model;
            _view = view;
            _service = _container.Locate<IUserService>();
        }

        public void TryPurchase()
        {
            if (_service.HasCurrency(_model.Cost))
            {
                _service.ReduceCurrency(_model.Cost);
                _view.PlayPurchased();
                CLog.LogWHeader("PromoItem", $"Purchased item: {_model.Title}", "g", "w");
                return;
            }
            _view.PlayNotPurchased();
            CLog.LogWHeader("PromoItem", $"Error. Not enough money. Cost {_model.Cost}", "r", "w");
        }
        
    }
}
