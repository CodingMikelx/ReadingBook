using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpPrefab; // Reference to the pop-up prompt prefab.
    private GameObject currentPopUp; // Reference to the currently active pop-up.

    private void OnMouseDown()
    {
        Debug.Log("Running");
        // Check if a pop-up is already active, close it.
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
            currentPopUp = null;
        }

        // Instantiate and show the pop-up prompt at the object's position.
        currentPopUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
    }
}
