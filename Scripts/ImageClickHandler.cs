using UnityEngine;
using UnityEngine.EventSystems;
public class ImageClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Image clicked at position: " +  eventData.position);
    }
}
