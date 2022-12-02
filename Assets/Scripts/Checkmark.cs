using UnityEngine;
using UnityEngine.EventSystems;

public class Checkmark : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _checkmark;

    public void OnPointerClick(PointerEventData data)
    {
        _checkmark.SetActive(!_checkmark.activeInHierarchy);
    }

}
