using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSpawner : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool isDeadTimeActive = false;
    public UnityEvent onSpawnPressed, onSpawnReleased;
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !isDeadTimeActive)
        {
            onSpawnPressed.Invoke();
            SpawnRandomPrefab();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !isDeadTimeActive)
        {
            onSpawnReleased.Invoke();
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        isDeadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        isDeadTimeActive = false;
    }

    public void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Length > 0)
        {
            int randomIndex = Random.Range(0, prefabsToSpawn.Length);
            Instantiate(prefabsToSpawn[randomIndex], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs assigned for spawning.");
        }
    }
}
