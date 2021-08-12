using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [SerializeField] GameObject[] ResultUI;

    InputController m_inputController;

    string loadSceneName;
    bool IsLoaded = false;



    private void Start()
    {
        Instance = this;
        m_inputController = FindObjectOfType<InputController>();
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
    public void Result(int playerId)
    {
        if (playerId == 0)
        {
            ResultUI[0].SetActive(true);
        }
        else if (playerId == 1)
        {
            ResultUI[1].SetActive(true);
        }
        FindObjectOfType<BomGenerator>().enabled = false;
        m_inputController.AllPlayerInputGameChange();
    }
}
