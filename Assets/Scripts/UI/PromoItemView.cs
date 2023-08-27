using DG.Tweening;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Presenters;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RedPanda.Project.UI
{
    public class PromoItemView : View, IPromoItemView
    {
        private const float PunchScale = -0.065f;
        private const float PunchScaleTime = 0.2f;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _rarity;
        [SerializeField] private Transform _scalable;
        private PromoItemPresenter _presenter;
        private IPromoIconService _iconService;
        private IMoneyUI _moneyUI;
        private IUserService _userService;
        
        
        public void SetMoneyUI(IMoneyUI moneyUI)
        {
            _moneyUI = moneyUI;
        }
        
        public void SetModelView(IPromoModel model)
        {
            _iconService = Container.Locate<IPromoIconService>();
            _userService = Container.Locate<IUserService>();
            _presenter = new PromoItemPresenter(Container, model, this);
            SetIcon(model.GetIcon());
            SetPrice(model.Cost);
            SetType(model.Type);
            SetRarity(model.Rarity);
        }
        
        public void SetIcon(string iconName)
        {
            var icon = _iconService.GetSprite(iconName);
            if(icon != null)
                _icon.sprite = icon;
        }

        public void SetPrice(float cost)
        {
            _costText.text = $"x{cost}";
        }

        public void SetType(PromoType promoType)
        {
            _itemName.text = promoType.ToString().ToUpper();
        }

        public void SetRarity(PromoRarity rarity)
        {
            _rarity.text = rarity.ToString().ToUpper();
        }

        public void PlayPurchased()
        {
            _moneyUI.UpdateCount(_userService.Currency);
            ScalePurchased();
        }

        public void PlayNotPurchased()
        {
            ScaleNotPurchased();
        }

        private void OnPurchaseButton()
        {
            _presenter.TryPurchase();
        }

        private void ScalePurchased()
        {
            _scalable.DOKill();
            _scalable.localScale = Vector3.one;
            _scalable.DOPunchScale(Vector3.one * PunchScale, PunchScaleTime);   
        }

        private void ScaleNotPurchased()
        {
            _scalable.DOKill();
            _scalable.localScale = Vector3.one;
            _scalable.DOPunchScale(Vector3.one * PunchScale / 2, PunchScaleTime * 2);      
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnPurchaseButton);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnPurchaseButton);
        }
    }
}