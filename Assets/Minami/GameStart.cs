using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{   
    public void OnStart(InputAction.CallbackContext context)
    {
        if(context.started)
            GameManager.Instance.SceneLoad("Test");
    }
}
