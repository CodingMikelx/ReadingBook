using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextAudioSync : MonoBehaviour
{
    public TextMeshProUGUI[] textElements; // Array of Text elements to display different texts
    public AudioClip audioClip; // Single audio clip to play
    private AudioSource audioSource;
    private int currentIndex = 0;

    private float delayBetweenTexts = 0.26f; // Adjust the delay time here

    private void Start()
    {
        // Ensure that an AudioSource component is attached to this game object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource is missing, create and attach one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start the text display using Invoke
        InvokeRepeating("PlayNextTextWithAudio", 0f, delayBetweenTexts);

        // Play the audio clip
        audioSource.clip = audioClip;
        audioSource.Play();

    }

    private async void PlayNextTextWithAudio()
    {
        if (currentIndex < textElements.Length)
        {

            // Change text color (you can customize this)
            if (currentIndex > 0)
            {
                 ChangeTextColor(textElements[currentIndex-1], Color.black);
            }
             ChangeTextColor(textElements[currentIndex], Color.red);
            currentIndex++;
        }
        else
        {
            
            ChangeTextColor(textElements[currentIndex - 1], Color.black);
            // All text elements have been displayed, so stop the invoking
            CancelInvoke("PlayNextTextWithAudio");
        }
    }


    private void ChangeTextColor(TextMeshProUGUI originalText, Color color)
    {
        //return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{originalText}</color>";
        originalText.color = color;
    }
}
