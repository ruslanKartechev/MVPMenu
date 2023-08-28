using Grace.DependencyInjection;
using RedPanda.Project.Presenters;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        private ILobbyPresenter _presenter;
        

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