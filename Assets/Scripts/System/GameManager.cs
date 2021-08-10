using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] bool m_isKeyboardOperation;
    [SerializeField] GameObject m_playerPrefab;
    [SerializeField] GameObject m_playerGeneratorButton;
    public bool IsKeyboardOperation { private set { } get { return m_isKeyboardOperation; } }
    private void Start()
    {
        Instance = this;
        
        if (m_isKeyboardOperation)
        {
            GetComponent<PlayerInputManager>().enabled = false;
            m_playerGeneratorButton.SetActive(true);
        }
            
    }

    public void OnClickPlayer()
    {
        Instantiate(m_playerPrefab);
    }
}
