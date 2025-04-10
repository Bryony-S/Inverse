using UnityEngine;

public class CameraViewScript : MonoBehaviour
{
    // Source: https://gamedev.stackexchange.com/a/167332
    // Properties
    [SerializeField] private float sceneWidth;
    [SerializeField] private float sceneHeight;
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        // Ensure camera view shows all of the scene
        float unitsPerPixelWidth = sceneWidth / Screen.width;
        float unitsPerPixelHeight = sceneHeight / Screen.height;
        float desiredHalfHeight = Mathf.Max(0.5f * unitsPerPixelWidth * Screen.height, 0.5f * unitsPerPixelHeight * Screen.height);
        mainCamera.orthographicSize = desiredHalfHeight;
    }
}
