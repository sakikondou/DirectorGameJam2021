using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject ResultUI;

    string loadSceneName;
    bool IsLoaded = false;


    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {

        if (IsLoaded) {

            SceneManager.LoadScene(loadSceneName);

        }

    }

    //シーン遷移
    public void SceneLoad(string sceneName) {

        loadSceneName = sceneName;
        IsLoaded = true;
    
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


}
