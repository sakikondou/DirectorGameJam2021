using UnityEngine;
using UnityEngine.InputSystem;

public class GameFinished : MonoBehaviour
{
    [SerializeField] string m_sceneName;
    [SerializeField] GameObject m_resultUI;
    PlayerInputManager m_inputManager;

    void Start()
    {
        m_inputManager = FindObjectOfType<PlayerInputManager>();
    }

    void Update()
    {
        //HPberの値が０になったらゲーム終了・結果画面の表示
        if (HpBar.m_gameFinished) {
            GameManager.Instance.Result(m_resultUI);

            //画面遷移（タイトルorリトライ)
            if (Input.GetKey(KeyCode.Return))
            {
                GameManager.Instance.SceneLoad(m_sceneName);
                HpBar.m_gameFinished = false;
            }

        }
    }
}
