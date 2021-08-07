using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputController m_inputController = null;
    [SerializeField] float m_speed = 5;
    Rigidbody2D m_rb = null;

    Vector2 m_inputAxis = Vector2.zero;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_inputAxis = m_inputController.InputActions.Player.Move.ReadValue<Vector2>();

        m_rb.velocity = m_inputAxis * m_speed;
    }
}
