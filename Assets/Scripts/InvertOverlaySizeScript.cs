using UnityEngine;

public class InvertOverlaySizeScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        // Set overlay size equal to camera view
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = mainCamera.aspect * (cameraHeight / 2);
        transform.localScale = new Vector3(cameraWidth, cameraHeight, transform.localScale.z);
    }
}
