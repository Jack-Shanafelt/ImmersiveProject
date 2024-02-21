using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public float triggerDistance = 5f; // The distance at which the audio should be triggered

    private Transform player; // Reference to the player's transform
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool hasPlayed = false; // Flag to track whether the audio has been played

    private void Start()
    {
        // Find the player object using a tag, assuming the player object is tagged as "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Calculate the distance between this object and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the trigger distance and the audio has not been played yet
        if (distanceToPlayer <= triggerDistance && !hasPlayed)
        {
            // Play the audio clip through the AudioSource component attached to this GameObject
            audioSource.Play();
            hasPlayed = true; // Set the flag to true to indicate that the audio has been played
        }
    }
}
