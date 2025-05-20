using UnityEngine;
using TMPro;
using System.Collections;

public class YouWin : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public float displayDuration = 5f;

    private Coroutine hideCoroutine;

    void Start()
    {
        hintText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintText.gameObject.SetActive(true);

            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            hideCoroutine = StartCoroutine(HideTextAfterDelay());
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        hintText.gameObject.SetActive(false);
        hideCoroutine = null;
    }
}


