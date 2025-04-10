using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerDetectionScript : MonoBehaviour
{
    [SerializeField] private BoolVariable isControllerDetected;

    private void Update()
    {
        isControllerDetected.value = Gamepad.all.Count > 0;
    }
}
