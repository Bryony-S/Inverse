using TMPro;
using UnityEngine;

public class ControllerTextSwitchScript : MonoBehaviour
{
    // Properties
    [SerializeField] private BoolVariable isControllerDetected;
    [SerializeField] private TMP_Text displayText;
    [Header("Text to display")]
    [Multiline][SerializeField] private string controllerText;
    [Multiline][SerializeField] private string keyboardText;

    private void Update()
    {
        if (isControllerDetected.value)
        {
            displayText.text = controllerText;
        }
        else { displayText.text = keyboardText; }
    }
}
