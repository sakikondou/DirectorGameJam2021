using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全体の入力を管理する
/// </summary>
public class InputController : MonoBehaviour
{
    List<PlayerInputController> m_playerInputControllers;
    public List<PlayerInputController> PlayerInputControllers { private set { } get { return m_playerInputControllers; } }

    /// <summary>
    /// 全ての入力を止める
    /// </summary>
    public void AllStopInput()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].StopInput();
        }
    }

    /// <summary>
    /// 全ての入力を開始する
    /// </summary>
    public void AllStartInput()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].StartInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの入力をプレイヤー操作に切り換える
    /// </summary>
    public void AllPlayerInputPlayerChange()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].ChengePlayerInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの入力をUI操作に切り換える
    /// </summary>
    public void AllPlayerInputUIChange()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].ChengeUIInput();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの射撃を停止する
    /// </summary>
    public void AllPlayerOffFire()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].OffFire();
        }
    }

    /// <summary>
    /// 全てのプレイヤーの射撃を開始する
    /// </summary>
    public void AllPlayerOnFire()
    {
        for (int i = 0; i < m_playerInputControllers.Count; i++)
        {
            m_playerInputControllers[i].OnFire();
        }
    }
}
