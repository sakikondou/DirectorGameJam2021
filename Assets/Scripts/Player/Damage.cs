﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    [SerializeField] float m_maxHp = 10;
    /// <summary>
    /// 最大HP
    /// </summary>
    public float MaxHp { private set { } get { return m_maxHp; } }
    /// <summary>
    /// 現在のHP
    /// </summary>
    float m_hp = 0;
    /// <summary>
    /// 現在のHP
    /// </summary>
    public float Hp { private set { } get { return m_hp; } }
    /// <summary>
    /// HPバー
    /// </summary>
    [SerializeField] GameObject m_hpBar = null;
    public GameObject m_winPrefab = null;
    public GameObject winLabel;

    PlayerFire m_playerFire;

    private void Start()
    {
        m_hp = m_maxHp;
        m_playerFire = GetComponent<PlayerFire>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))  // 衝突相手が 弾 だったら
        {
            if (m_playerFire.ID == collision.gameObject.GetComponent<Bullet>().ID)
            {
                Debug.Log(m_playerFire.ID);
                return;
            }

            Debug.Log("ダメージ");
            Destroy(collision.gameObject);  // 弾のオブジェクトを破棄する
            m_hp--;   // ライフを減らす

            // ライフが 0 だったら
            if (m_hp < 1)
            {
                // 爆発エフェクトを生成する
                if (m_hpBar)
                {
                    Instantiate(m_hpBar, this.transform.position, m_hpBar.transform.rotation);
                    if (winLabel != null)
                    {
                        winLabel.SetActive(true);
                        Instantiate(m_winPrefab, transform.position, Quaternion.identity);
                    }
                }
                Destroy(this.gameObject);       // そして自分も破棄する
                Debug.Log("破壊");
            }
        }
    }
}