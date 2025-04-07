using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerDeathRestartScript : MonoBehaviour
{
    public void Restart(InputAction.CallbackContext context)
    {
        if (context.performed) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
