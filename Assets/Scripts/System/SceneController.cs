using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [SerializeField] GameObject ResultUI;

    string loadSceneName;
    bool IsLoaded = false;

    GameObject[] m_playerObjs;
    [SerializeField] Color m_color;


    private void Start()
    {
        Instance = this;
    }

    //シーン遷移
    public void SceneLoad(string sceneName)
    {
        loadSceneName = sceneName;
        SceneManager.LoadScene(loadSceneName);
    }

    //Retry
    public void RestartScene()
    {

        loadSceneName = SceneManager.GetActiveScene().name;
        IsLoaded = true;

        //デバッグ用
        Debug.Log("現在のシーン：" + loadSceneName);

    }

    //リザルト表示(仮)
    public void Result()
    {
        ResultUI.SetActive(true);
    }
}
