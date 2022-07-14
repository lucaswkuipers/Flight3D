using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Develop : MonoBehaviour
{
    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
