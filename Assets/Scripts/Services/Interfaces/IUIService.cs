using UnityEngine;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUIService
    {
        void Show(string viewName);
        void Close(string viewName);
        T SpawnElement<T>(string elementName, Transform parent) where T : MonoBehaviour;
    }
}