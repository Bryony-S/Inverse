using TMPro;
using UnityEngine;

public class ControllerDetectionTextScript : MonoBehaviour
{
    [SerializeField] private BoolVariable isControllerDetected;
    [SerializeField] private TMP_Text controllerDetectionText;

    private void Update()
    {
        controllerDetectionText.text = (isControllerDetected.value) ? "Controller detected!" : "Controller not detected - using Keyboard & Mouse controls";
    }
}
