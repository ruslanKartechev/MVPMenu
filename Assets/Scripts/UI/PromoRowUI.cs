using System.Collections.Generic;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoRowUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Transform _itemsParent;
        private IExportLocatorScope _container;
        private IUIService _uiService;

        
        [Import]
        public void Inject(IExportLocatorScope container, IUIService uiService)
        {
            _container = container;
            _uiService = uiService;
        }

        public void SetLabel(string label)
        {
            _label.text = label;
        }
        
        public void SetItems(IList<IPromoModel> models, IMoneyUI moneyUI)
        {
            foreach (var model in models)
            {
                var instance = GetItemView();
                instance.SetModelView(model);
                instance.SetMoneyUI(moneyUI);
            }
        }

        private PromoItemView GetItemView()
        {
            var instance =  _uiService.SpawnElement<PromoItemView>(UIResourcesNames.PromoItemView, _itemsParent);
            _container.Inject(instance, _container);
            return instance;
        }
    }
}