using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] InputController m_inputController = null;
    [SerializeField] GameObject m_bullet = null;
    [SerializeField] Transform[] m_muzzles = null;

    /// <summary>
    /// 射撃速度
    /// </summary>
    [SerializeField] float m_fireRate = 0.3f;
    float m_timer = 0;
    /// <summary>
    /// 入力角度
    /// </summary>
    Vector3 m_inputAxis = Vector2.zero;
    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField] float m_rotateSpeed = 0;
    /// <summary>
    /// 撃っているか
    /// </summary>
    bool m_isFire = false;

    private void Start()
    {
        m_inputController.Init();
        m_inputController.InputActions.Player.Fire.started += contxt => OnFire();
        m_inputController.InputActions.Player.Fire.canceled += contxt => OffFire();
    }

    private void Update()
    {
        m_inputAxis = m_inputController.InputActions.Player.RotateMuzzle.ReadValue<Vector2>();
        transform.up = m_inputAxis;

        m_timer += Time.deltaTime;

        if (m_isFire && m_timer >= m_fireRate)
        {
            Fire();
            m_timer = 0;
        }
    }

    void OnFire()
    {
        m_isFire = true;
    }

    void OffFire()
    {
        m_isFire = false;
    }

    void Fire()
    {
        for (int i = 0; i < m_muzzles.Length; i++)
        {
            GameObject obj = Instantiate(m_bullet, m_muzzles[i]);
            obj.GetComponent<Bullet>().Init(m_muzzles[i], transform);
            obj.transform.parent = null;
        }
    }
}
