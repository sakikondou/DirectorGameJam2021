using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    /// <summary>
    /// 入力
    /// </summary>
    PlayerInputActions m_inputActions;
    public PlayerInputActions InputActions { private set { } get { return m_inputActions; } }

    public void Init()
    {
        if (m_inputActions == null)
        {
            m_inputActions = new PlayerInputActions();
            m_inputActions.Enable();
        }
    }

    /// <summary>
    /// ユーザーからの入力を受け付けを許可する
    /// </summary>
    public void StartInput()
    {
        m_inputActions.Enable();
    }

    /// <summary>
    /// ユーザーからの入力を受け付けを拒否する
    /// </summary>
    public void StopInput()
    {
        m_inputActions.Disable();
    }

    /// <summary>
    /// プレイヤー操作の入力に切り換える
    /// </summary>
    public void ChengePlayerInput()
    {
        m_inputActions.Player.Enable();
        m_inputActions.UI.Disable();
    }

    /// <summary>
    /// UI操作の入力に切り換える
    /// </summary>
    public void ChengeUIInput()
    {
        m_inputActions.UI.Enable();
        m_inputActions.Player.Disable();
    }
}
