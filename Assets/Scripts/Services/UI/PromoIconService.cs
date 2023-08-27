using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class PromoIconService : IPromoIconService
    {
        public Sprite GetSprite(string name)
        {
            var path = $"Icons/{name}";
            return Resources.Load<Sprite>(path);
        }
    }
}