﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("弾の速度"), SerializeField] float m_speed = 5.0f;
    private Rigidbody2D m_rb;
    public Vector2 m_direction;

    public void Init(Transform muzzle, Transform gun)
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_direction = muzzle.position - gun.position;
        m_rb.velocity = m_direction * m_speed;
    }
    public void ChangeVelo()
    {
        m_rb.velocity = m_direction * m_speed;
    }
}
