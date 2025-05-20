using UnityEngine;

public class ReturnMenu : MonoBehaviour
{
    public GameObject returnMenuButton;

    private void Start()
    {
        returnMenuButton.SetActive(false); // Hide the button at game start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            returnMenuButton.SetActive(true); // Show the button
        }
    }
}
