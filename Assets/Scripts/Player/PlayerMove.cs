using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// デフォルトのスピード
    /// </summary>
    [SerializeField] float m_defaultSpeed = 5;
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

    Rigidbody2D m_rb = null;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_speed = m_defaultSpeed;
    }

    private void Update()
    {
        if (m_inputForwardAxis != Vector2.zero)
        {
            transform.up = m_inputForwardAxis;
        }
    }

    public void PlayerRotate(InputAction.CallbackContext context)
    {
        Debug.Log("hohooh");
        m_inputForwardAxis = context.ReadValue<Vector2>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        m_inputMoveAxis = context.ReadValue<Vector2>();
        m_rb.velocity = m_inputMoveAxis * m_speed;
    }

    /// <summary>
    /// スピードを上げる
    /// </summary>
    /// <param name="addSpeed"></param>
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
}
