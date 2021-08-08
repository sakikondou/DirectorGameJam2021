using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombBullet : Bullet
{
    [SerializeField] float m_destroyTime = 2.0f;
    float m_timer = 0f;
    Vector2 m_reflectDir;
    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_destroyTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "TopWall":
                m_reflectDir = new Vector2(m_direction.x, m_direction.y * -1);
                m_direction = m_reflectDir;
                ChangeVelo();
                break;

            case "RightWall":
                m_reflectDir = new Vector2(m_direction.x * -1, m_direction.y);
                m_direction = m_reflectDir;
                ChangeVelo();
                break;

            case "LeftWall":
                m_reflectDir = new Vector2(m_direction.x * -1, m_direction.y);
                m_direction = m_reflectDir;
                ChangeVelo();
                break;
            case "BottomWall":
                m_reflectDir = new Vector2(m_direction.x, m_direction.y * -1);
                m_direction = m_reflectDir;
                ChangeVelo();
                break;
        }
    }
}
