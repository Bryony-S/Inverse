using TMPro;
using UnityEngine;

public class ControllerTutorialTextScript : MonoBehaviour
{
    // Properties
    [SerializeField] private BoolVariable isControllerDetected;
    [SerializeField] private TMP_Text controlsText;

    private void Update()
    {
        if (isControllerDetected.value)
        {
            controlsText.text = "D-pad to move\n\nA (bottom) button to push blocks\n\nX (left) button to switch worlds\n\nRB (right shoulder) button to restart level";
        }
        else { controlsText.text = "WASD or Arrow keys to move\n\nSpacebar to push blocks\n\nTab to switch worlds\n\nR to restart level"; }
    }
}
