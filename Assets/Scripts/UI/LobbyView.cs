using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Presenters;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        private ILobbyPresenter _presenter;
        
        private void Awake()
        {
            //Example for services
            //var promoService = Container.Locate<IPromoService>();
            //UIService.Close();
        }

        private void Start()
        {
            _presenter = new LobbyPresenter();
            Container.Inject(_presenter);            
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _presenter.Start();
        }

    
    }
}