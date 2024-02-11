using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Singleton instance
    public static SoundPlayer instance;

    // The audio clip to be played
    public AudioClip soundClip;

    // Ensure only one instance of SoundPlayer exists
    private void Awake()
    {
        // If an instance already exists and it's not this instance, destroy this instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Ensure this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);
    }

    // Play the sound
    public void PlaySound(AudioClip soundClipTemp)
    {
        soundClip = soundClipTemp;
        // Check if there's an audio clip assigned
        if (soundClip != null)
        {
            // Create an AudioSource component if there isn't one attached
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Play the sound clip
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to play.");
        }
    }

    // Get the singleton instance of SoundPlayer
    public static SoundPlayer GetInstance()
    {
        return instance;
    }
}