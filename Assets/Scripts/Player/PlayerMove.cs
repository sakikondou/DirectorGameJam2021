using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// デフォルトのスピード
    /// </summary>
    float m_defaultSpeed = 5;
    /// <summary>
    /// 現在のスピード
    /// </summary>
    float m_speed = 5;
    /// <summary>
    /// 入力された移動方向
    /// </summary>
    Vector2 m_inputMoveAxis = Vector2.zero;
    /// <summary>
    /// 入力されたプレイヤーの向き
    /// </summary>
    Vector2 m_inputForwardAxis = Vector2.zero;
    Player m_player = null;

    Rigidbody2D m_rb = null;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_speed = m_defaultSpeed;
        m_player = GetComponent<Player>();
    }

    public void PlayerRotate(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.IsKeyboardOperation)
        {
            m_inputForwardAxis = context.ReadValue<Vector2>();
            if (m_inputForwardAxis != Vector2.zero)
            {
                transform.up = m_inputForwardAxis;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.IsKeyboardOperation)
        {
            m_inputMoveAxis = context.ReadValue<Vector2>();
            m_rb.velocity = m_inputMoveAxis * m_speed;
        }
    }

    /// <summary>
    /// スピードを上げる
    /// </summary>
    /// <param name="addSpeed">加算するスピード</param>
    public void SpeedUp(float addSpeed)
    {
        m_speed = m_defaultSpeed + addSpeed;
    }

    /// <summary>
    /// 元のスピードに戻す
    /// </summary>
    public void RestoreOriginalSpeed()
    {
        m_speed = m_defaultSpeed;
    }


    #region キーボード操作

    public void Move1(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 0)
        {
            m_inputMoveAxis = context.ReadValue<Vector2>();
            m_rb.velocity = m_inputMoveAxis * m_speed;
        }
    }

    public void Move2(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 1)
        {
            m_inputMoveAxis = context.ReadValue<Vector2>();
            m_rb.velocity = m_inputMoveAxis * m_speed;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.IsKeyboardOperation)
            transform.Rotate(0, 0, -m_inputForwardAxis.x);
    }

    public void PlayerRotate1(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 0)
        {
            m_inputForwardAxis = context.ReadValue<Vector2>();
        }
    }

    public void PlayerRotate2(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 1)
        {
            m_inputForwardAxis = context.ReadValue<Vector2>();
        }
    }

    #endregion 
}
