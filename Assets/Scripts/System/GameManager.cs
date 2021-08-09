using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject ResultUI;

    string loadSceneName;
    bool IsLoaded = false;

    GameObject[] m_playerObjs;
    [SerializeField] Color m_color;


    private void Start()
    {
        Instance = this;
        SceneManager.sceneLoaded += SendPlayer; 
        DontDestroyOnLoad(gameObject);
    }

    //シーン遷移
    public void SceneLoad(string sceneName) {

        loadSceneName = sceneName;
        SceneManager.LoadScene(loadSceneName);
    }

    //Retry
    public void RestartScene() {

        loadSceneName = SceneManager.GetActiveScene().name;
        IsLoaded = true;

        //デバッグ用
        Debug.Log("現在のシーン：" + loadSceneName);
    
    }

    //リザルト表示(仮)
    public void Result() {

        ResultUI.SetActive(true);

    }

    void SendPlayer(Scene scene, LoadSceneMode mode)
    {
        StartPositionForPlayer startPositionForPlayer = FindObjectOfType<StartPositionForPlayer>();
        startPositionForPlayer.PlayerObjs = m_playerObjs;
        startPositionForPlayer.m_color = m_color;
    }

    public void SetPlayers(GameObject[] players)
    {
        m_playerObjs = players;
    }
}
