using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    /// <summary>
    /// キーボード入力にしているか
    /// </summary>
    [SerializeField] bool m_isKeyboardOperation;
    /// <summary>
    /// キーボード入力にしているか
    /// </summary>
    public bool IsKeyboardOperation { private set { } get { return m_isKeyboardOperation; } }
    /// <summary>
    /// プレイヤーのプレファブ
    /// </summary>
    [SerializeField] GameObject m_playerPrefab;
    /// <summary>
    /// プレイヤーを生成するボタン
    /// </summary>
    [SerializeField] GameObject m_playerGeneratorButton;

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
