using UnityEngine;

public class ColliderClick : MonoBehaviour
{
    public GameObject promptCanvas; // Reference to your pop-up prompt Canvas
    private bool isPromptVisible = false;

    private void OnMouseDown()
    {
        if (!isPromptVisible)
        {
            // Show the pop-up prompt
            promptCanvas.SetActive(true);
            isPromptVisible = true;
        }
        else
        {
            // Hide the pop-up prompt if it's already visible
            promptCanvas.SetActive(false);
            isPromptVisible = false;
        }
    }
}
