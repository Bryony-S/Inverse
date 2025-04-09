using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    // Properties
    public static AudioManagerScript Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;

    // Methods
    private void Awake()
    {
        // Set Instance to this if null, otherwise Instance already exists so destroy this
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else { Instance = this; }
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
