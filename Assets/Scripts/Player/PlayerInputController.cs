﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤー単体の入力を管理する
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    PlayerInput m_playerInput;

    void Start()
    {
        m_playerInput = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// ユーザーの入力を許可する
    /// </summary>
    public void StartInput()
    {
        m_playerInput.enabled = true;
    }

    /// <summary>
    /// ユーザーからの入力を拒否する
    /// </summary>
    public void StopInput()
    {
        m_playerInput.enabled = false;
    }

    /// <summary>
    /// プレイヤー操作の入力に切り換える
    /// </summary>
    public void ChangePlayerInput()
    {
        m_playerInput.SwitchCurrentActionMap("Player");
    }

    /// <summary>
    /// UI操作の入力に切り換える
    /// </summary>
    public void ChangeUIInput()
    {
        m_playerInput.SwitchCurrentActionMap("UI");
    }
    /// <summary>
    /// Gameの状態を切り替える入力
    /// </summary>
    public void ChangeGameInput()
    {
        m_playerInput.SwitchCurrentActionMap("Game");
    }

    /// <summary>
    /// 射撃を出来なくする
    /// </summary>
    public void OffFire()
    {
        m_playerInput.actions.FindAction("Fire").Disable();
    }

    /// <summary>
    /// 射撃をできるようにする
    /// </summary>
    public void OnFire()
    {
        m_playerInput.actions.FindAction("Fire").Enable();
    }
}
