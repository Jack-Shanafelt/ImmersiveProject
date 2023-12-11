using UnityEngine;
using UnityEngine.InputSystem;

public class OculusControllerSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public Transform spawnArea; // The area where objects will spawn
    private InputAction gripAction;

    private Transform rightHandTransform; // Reference to the right hand's transform

    private void Start()
    {
        GameObject rightHand = GameObject.Find("Right Controller Stabilized"); // Update "RightHandAnchor" to match your right hand anchor name

        if (rightHand != null)
        {
            rightHandTransform = rightHand.transform;

            // Enable the GripButton action from the Input Actions asset
            gripAction = new InputAction(binding: "/user/hand/right/grip", type: InputActionType.Button, interactions: "press");
            gripAction.Enable();

            // Register a callback for when the grip button is pressed
            gripAction.performed += GripButtonPerformed;
        }
        else
        {
            Debug.LogError("Right hand anchor not found. Make sure it's named correctly.");
        }
    }

    private void OnDisable()
    {
        if (gripAction != null)
        {
            gripAction.Disable();
            gripAction.performed -= GripButtonPerformed;
        }
    }

    private void GripButtonPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Grip button pressed"); // Check if this log appears in the Console window
        if (context.ReadValue<float>() > 0.5f)
        {
            Vector3 handPosition = rightHandTransform.position;
            if (IsWithinSpawnArea(handPosition))
            {
                int randomIndex = Random.Range(0, prefabsToSpawn.Length);
                GameObject prefabToSpawn = prefabsToSpawn[randomIndex];
                Instantiate(prefabToSpawn, handPosition, Quaternion.identity);
            }
        }
    }

    private bool IsWithinSpawnArea(Vector3 position)
    {
        return spawnArea.GetComponent<Collider>().bounds.Contains(position);
    }
}