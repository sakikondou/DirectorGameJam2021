using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] float m_maxHp = 10;

    public float MaxHp { private set { }get { return m_maxHp; } }

    float m_hp = 0;
    public float Hp { private set { } get { return m_hp; } }
    [SerializeField] GameObject m_explosionPrefab = null;
    //[SerializeField] GameObject m_winPrefab = null;
    public GameObject winLabel;

    private void Start()
    {
        m_hp = m_maxHp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))  // 衝突相手が 弾 だったら
        {
            Debug.Log("ダメージ");
            Destroy(collision.gameObject);  // 弾のオブジェクトを破棄する
            m_hp--;   // ライフを減らす

            // ライフが 0 だったら
            if (m_hp < 1)
            {
                // 爆発エフェクトを生成する
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                    winLabel.SetActive(true);
                }
               
                Destroy(this.gameObject);       // そして自分も破棄する
                    Debug.Log("破壊");

            }
        }
    }
}