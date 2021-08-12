using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全体の入力を管理する
/// </summary>
public class InputController : MonoBehaviour
{
    PlayerInputController[] m_playerInputControllers = null;
    public PlayerInputController[] PlayerInputControllers { private set { } get { return m_playerInputControllers; } }

    /// <summary>
    /// 全ての入力を止める
    /// </summary>
    public void AllStopInput()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].StopInput();
        }
    }

    /// <summary>
    /// 全ての入力を開始する
    /// </summary>
    public void AllStartInput()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].StartInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの入力をプレイヤー操作に切り換える
    /// </summary>
    public void AllPlayerInputPlayerChange()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].ChangePlayerInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの入力をUI操作に切り換える
    /// </summary>
    public void AllPlayerInputUIChange()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].ChangeUIInput();
        }
    }
    /// <summary>
    /// 全てのプレイヤーの入力をプレイヤー操作に切り換える
    /// </summary>
    public void AllPlayerInputGameChange()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].ChangeGameInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの射撃を停止する
    /// </summary>
    public void AllPlayerOffFire()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].OffFire();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの射撃を開始する
    /// </summary>
    public void AllPlayerOnFire()
    {
        m_playerInputControllers = FindObjectsOfType<PlayerInputController>();
        for (int i = 0; i < m_playerInputControllers.Length; i++)
        {
            m_playerInputControllers[i].OnFire();
        }
    }
}
