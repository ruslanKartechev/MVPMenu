using System.Collections.Generic;
using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Presenters;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoView : View, IPromoView
    {
        [SerializeField] private Transform _rowsParent;
        [SerializeField] private MoneyUI _moneyUI;
        private List<PromoRowUI> _promoRows = new List<PromoRowUI>();
        private IUIService _uiService;
        private PromoPresenter _presenter;
        
        
        private void Start()
        {
            _uiService = Container.Locate<IUIService>();
            _presenter = new PromoPresenter(this, Container);
        }

        public void ShowItemsGroup(string label, IList<IPromoModel> model)
        {
            var row = GetRow();
            row.SetLabel(label);
            row.SetItems(model, _moneyUI);
            _promoRows.Add(row);
        }

        public void SetMoney(float amount)
        {
            _moneyUI.Set(amount);
        }

        private PromoRowUI GetRow()
        {
            var instance = _uiService.SpawnElement<PromoRowUI>(UIResourcesNames.PromoRowUI, _rowsParent);
            Container.Inject(instance);
            return instance;
        }
    }
}