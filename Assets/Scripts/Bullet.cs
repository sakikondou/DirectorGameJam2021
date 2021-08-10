using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 弾速
    /// </summary>
    [Tooltip("弾速"), SerializeField] protected float m_speed = 5.0f;
    /// <summary>
    /// 弾の方向
    /// </summary>
    protected Vector2 m_direction;

    protected Rigidbody2D m_rb;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="muzzle">マズルのトランスフォーム</param>
    /// <param name="selfObj">自身のオブジェクト</param>
    /// <param name="id"></param>
    public void Init(Transform muzzle, Transform selfObj)
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_direction = muzzle.position - selfObj.position;
        m_rb.velocity = m_direction * m_speed;

        transform.parent = null;
    }

    /// <summary>
    /// 移動方向を変える
    /// </summary>
    /// <param name="direction">移動方向</param>
    public void ChangeDirection(Vector2 direction)
    {
        m_rb.velocity = direction * m_speed;
    }
}
