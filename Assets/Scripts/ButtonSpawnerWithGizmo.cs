using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSpawnerWithGizmo: MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool isDeadTimeActive = false;
    public UnityEvent onSpawnPressed, onSpawnReleased;
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public Transform spawnPosition; // Reference to the spawn position object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !isDeadTimeActive)
        {
            onSpawnPressed.Invoke();
            SpawnRandomPrefab();
        }
    }

    private void OnTriggerExit(Collider other)
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
        if (prefabsToSpawn.Length > 0 && spawnPosition != null)
        {
            int randomIndex = Random.Range(0, prefabsToSpawn.Length);
            GameObject prefabToSpawn = prefabsToSpawn[randomIndex];
            Instantiate(prefabToSpawn, spawnPosition.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs assigned for spawning or spawn position is not set.");
        }
    }

    // Draw a gizmo to visualize the spawn position in the editor
    private void OnDrawGizmosSelected()
    {
        if (spawnPosition != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPosition.position, 0.5f);
        }
    }
}
