using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // Reference to the UI Text element
    public AudioSource audioSource; // Reference to the AudioSource component
    public Color targetColor = Color.red; // Default target color

    private Color initialTextColor; // Store the initial text color

    private void Start()
    {
        initialTextColor = dialogueText.color;

        string sentence = "Hey, do you want to eat some salads?"; // The dialogue sentence
        AudioClip audioClip = audioSource.clip/* Assign your audio clip here */; // Assign the audio clip

        // Call StartDialogue automatically when the scene starts
        StartDialogue(sentence, audioClip);
    }

    public void StartDialogue(string text, AudioClip audioClip)
    {
        dialogueText.text = text;
        audioSource.clip = audioClip;
        audioSource.Play();

        // Change the text color instantly to the target color
        dialogueText.color = targetColor;

        // Reset the text color after a delay
        Invoke("ResetTextColor", 0.5f);
    }

    private void ResetTextColor()
    {
        dialogueText.color = initialTextColor; // Reset to the initial text color
    }
}
