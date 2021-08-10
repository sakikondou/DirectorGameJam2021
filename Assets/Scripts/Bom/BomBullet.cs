using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBullet : Bullet
{
    /// <summary>
    /// 消える時間
    /// </summary>
    [SerializeField] float m_destroyTime = 2.0f;
    float m_timer = 0f;
    /// <summary>
    /// 跳ね返る方向
    /// </summary>
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
                ChangeDirection(m_reflectDir);
                break;

            case "RightWall":
                m_reflectDir = new Vector2(m_direction.x * -1, m_direction.y);
                ChangeDirection(m_reflectDir);
                break;

            case "LeftWall":
                m_reflectDir = new Vector2(m_direction.x * -1, m_direction.y);
                ChangeDirection(m_reflectDir);
                break;

            case "BottomWall":
                m_reflectDir = new Vector2(m_direction.x, m_direction.y * -1);
                ChangeDirection(m_reflectDir);
                break;
        }
    }
}
