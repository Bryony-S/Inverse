using UnityEngine;

public class InvertOverlaySizeScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Methods
    private void Start()
    {
        // Centre overlay to same position as camera
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z);
        // Set overlay size equal to camera view
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = mainCamera.aspect * cameraHeight;
        transform.localScale = new Vector3(cameraWidth, cameraHeight, transform.localScale.z);
    }

    /// <summary>
    /// Cuts the overlay's width in half and positions it over one side of the level to display symmetry
    /// </summary>
    public void HalfWidth()
    {
        transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y, transform.localScale.z);
        // Randomly select side to position overlay
        float xPos = transform.localScale.x / 2;
        if (Random.value > 0.5) xPos *= -1;
        transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
    }
}
