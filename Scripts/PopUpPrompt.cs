using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpPrompt : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelPrefab; // Reference to your pop-up panel prefab.
    private GameObject currentPanel;

    private void OnEnable()
    {
        currentPanel = panelPrefab;
        HidePanel();
    }
    private void OnMouseDown()
    {
        if (currentPanel != null)
        {
            ShowPanel();
            Debug.Log("current panel != null");
            // Start a coroutine to hide the panel after 2 seconds
            StartCoroutine(HidePanelAfterDelay(2f));
        }
        else
        {
            HidePanel();

        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentPanel != null)
        {
            ShowPanel();
            Debug.Log("current panel != null");
            // Start a coroutine to hide the panel after 2 seconds
            StartCoroutine(HidePanelAfterDelay(2f));
        }
        else
        {
            HidePanel();
            
        }
    }

    private void ShowPanel()
    {
        if (panelPrefab != null && currentPanel != null)
        {            
            GameObject currentPanel = Instantiate(panelPrefab, transform);
            currentPanel.transform.SetParent(transform);

            currentPanel.SetActive(true);

            RectTransform panelRect = panelPrefab.GetComponent<RectTransform>();
            RectTransform popupRect = currentPanel.GetComponent<RectTransform>();

            if (panelRect != null && popupRect != null)
            {
                popupRect.sizeDelta = panelRect.sizeDelta;
            }
            Destroy(currentPanel,2f);
        }
    }

    private void HidePanel()
    {
        Debug.Log("hide");
        if (currentPanel != null)
        {
            Debug.Log("set activity");
            // Disable the panel instead of destroying it
            currentPanel.SetActive(false);
        }
    }

    // Coroutine to show the panel for a specified duration
    private IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HidePanel();
    }

    // This method is called when the GameObject is disabled.
    private void OnDisable()
    {
        HidePanel();
        Destroy(currentPanel);
    }
}
