using UnityEngine;

public class ActivateObjectsOnStart : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Array of GameObjects to activate on game start

    void Start()
    {
        // Loop through the array and activate each GameObject
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null) // Check if the object exists to prevent errors
            {
                obj.SetActive(true); // Activate the GameObject
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array.");
            }
        }
    }
}
