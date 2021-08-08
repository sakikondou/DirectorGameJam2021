using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    [SerializeField] string m_sceneName;
    PlayerInputManager m_inputManager;

    private void Start()
    {
        m_inputManager = FindObjectOfType<PlayerInputManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        Debug.Log("OnStart");

        if (m_inputManager.playerCount == m_inputManager.maxPlayerCount)
        {
            PlayerInput[] playerInputs = FindObjectsOfType<PlayerInput>();
            GameObject[] playerObjs = new GameObject[playerInputs.Length];
            for (int i = 0; i < playerInputs.Length; i++)
            {
                playerObjs[i] = playerInputs[i].gameObject;
            }

            GameManager.Instance.SetPlayers(playerObjs);
        }

        if (context.started)
            GameManager.Instance.SceneLoad(m_sceneName);
    }
}
