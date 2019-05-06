using UnityEngine;
using UnityEngine.EventSystems;

public class PrivacyPolicyButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL("http://piekoszek.com/legal/dalton/privacy-policy-android.html");
    }
}