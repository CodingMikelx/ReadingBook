using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image imageUI; // Reference to the Image UI element in the Inspector
    public string imagePath; // Path to the image in the "Assets" folder

    void Start()
    {
        LoadAndDisplayImage();
    }

    void LoadAndDisplayImage()
    {
        // Load the image from the provided path
        Sprite sprite = Resources.Load<Sprite>(imagePath);

        // Update the Image UI element's sprite
        if (sprite != null)
        {
            imageUI.sprite = sprite;
        }
        else
        {
            Debug.LogError("Image not found at path: " + imagePath);
        }
    }
}
