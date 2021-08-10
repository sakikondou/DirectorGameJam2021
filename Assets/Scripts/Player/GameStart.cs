using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    /// <summary>
    /// シーンの名前
    /// </summary>
    [SerializeField] string m_sceneName;

    PlayerInputManager m_playerInputManager;

    private void Start()
    {
        m_playerInputManager = FindObjectOfType<PlayerInputManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        Debug.Log("OnStart");

        //プレイヤーの数が揃ってて、
        //タイトルまたはゲーム終了時で無ければ何もしない
        if (m_playerInputManager.playerCount != m_playerInputManager.maxPlayerCount)
            return;

        //プレイヤータグのついたオブジェクトを探して取得する
        GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Player");

        SetPlayerID(playerObjs);

        SceneController.Instance.SceneLoad(m_sceneName);
    }

    /// <summary>
    /// プレイヤーIDを設定する
    /// </summary>
    /// <param name="playerObjs">全プレイヤー</param>
    void SetPlayerID(GameObject[] playerObjs)
    {
        Player[] players = new Player[playerObjs.Length];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = playerObjs[i].GetComponent<Player>();
        }

        for (int i = 0; i < players.Length; i++)
        {
            for (int id = 0; id < players.Length; id++)
            {
                if (AlreadyIdUsedIs(players[i], players, id))
                    continue;
                players[i].PlayerID = id;
            }
        }


        for (int i = 0; i < playerObjs.Length; i++)
        {
            playerObjs[i].name = playerObjs[i].name + players[i].PlayerID;
        }
    }

    /// <summary>
    /// 既にIDが使われているか
    /// </summary>
    /// <param name="player">調べたいプレイヤーのPlayerFire</param>
    /// <param name="players">全プレイヤーのPlayerFire</param>
    /// <param name="id">使いたいID</param>
    /// <returns>true: 使われている false: 使われていない</returns>
    bool AlreadyIdUsedIs(Player player, Player[] players, int id)
    {
        for (int i = 0; i < players.Length; i++)
        {
            //同じプレイヤーだったらとばす
            if (player == players[i])
                continue;

            //同じIDだったらtrueを返す
            if (id == players[i].PlayerID)
                return true;
        }
        //結果、全てのプレイヤーと違うIDだったらtrueを返す
        return false;
    }
}
