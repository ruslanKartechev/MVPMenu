using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Presenters
{
    public class LobbyPresenter : ILobbyPresenter
    {
        private IUIService _uiService;
        
        [Import]
        public void Inject(IUIService uiService)
        {
            _uiService = uiService;
        }
        
        void ILobbyPresenter.Start()
        {
            _uiService.Close(UIResourcesNames.LobbyView);
            _uiService.Show(UIResourcesNames.PromoView);
        }
    }
}