using System.Collections.Generic;
using Grace.DependencyInjection;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Presenters;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Utils;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoView : View, IPromoView
    {
        [SerializeField] private Transform _rowsParent;
        [SerializeField] private MoneyUI _moneyUI;
        private List<PromoRowUI> _promoRows;
        private PromoPresenter _presenter;
        private IUIService _uiService;

        
        private void Start()
        {
            _uiService = Container.Locate<IUIService>();
            _presenter = new PromoPresenter(this, Container);
        }

        public void LoadItems(IReadOnlyList<IPromoModel> models)
        {
            var modelsByType = new Dictionary<PromoType, IList<IPromoModel>>();
            foreach (var model in models)
            {
                if (modelsByType.ContainsKey(model.Type) == false)
                    modelsByType.Add(model.Type, new List<IPromoModel>());
                modelsByType[model.Type].Add(model);
            }

            _promoRows = new List<PromoRowUI>();
            foreach (var pair in modelsByType)
            {
                PromoSorter.SortByRarity(pair.Value);
                var row = GetRow();
                row.SetLabel(pair.Key.ToString());
                row.SetItems(pair.Value, _moneyUI);
                _promoRows.Add(row);
            }
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