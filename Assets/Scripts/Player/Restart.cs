using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Restart : MonoBehaviour
{
    public GameObject result;
    string sceneName = "Title";

    public void ReStart(InputAction.CallbackContext context)
    {
        if (result.activeSelf)
        {
            GameManager.Instance.SceneLoad(sceneName);
            result.SetActive(false);
        }
    }
}
