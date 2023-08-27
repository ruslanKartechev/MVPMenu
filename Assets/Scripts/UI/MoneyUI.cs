using DG.Tweening;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class MoneyUI : MonoBehaviour, IMoneyUI
    {
        private const float PunchScale = -0.065f;
        private const float PunchScaleTime = 0.2f;
        
        [SerializeField] private Transform _scalable;
        [SerializeField] private TextMeshProUGUI _text;


        public void Set(float count)
        {
            _text.text = count.ToString();
        }

        public void UpdateCount(float count)
        {
            Set(count);
            _scalable.DOKill();
            _scalable.localScale = Vector3.one;
            _scalable.DOPunchScale(Vector3.one * PunchScale, PunchScaleTime);
        }
    }
}