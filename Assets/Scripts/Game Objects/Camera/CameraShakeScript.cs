using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    // Properties
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrength;

    // Methods
    /// <summary>
    /// Starts the screen shake effect
    /// </summary>
    public void StartShake()
    {
        StartCoroutine(CameraShake());
    }

    /// <summary>
    /// Repeatedly changes the camera's position to give a screen shake effect
    /// </summary>
    /// <returns>Null</returns>
    private IEnumerator CameraShake()
    {
        // Store the camera's starting position and set timer
        Vector3 startPos = transform.position;
        float timer = 0f;
        // Randomly change camera's position repeatedly
        while (timer < shakeDuration)
        {
            timer += Time.deltaTime;
            transform.position = startPos + (Random.insideUnitSphere * shakeStrength);
            yield return null;
        }
        // Reset camera position
        transform.position = startPos;
    }
}
