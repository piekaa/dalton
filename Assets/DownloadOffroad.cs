using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class DownloadOffroad : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=piekoszek.offroad");
        var request = UnityWebRequest.Post("http://piekoszek.com/api/dalton/download", "");
        request.SendWebRequest();
    }
}