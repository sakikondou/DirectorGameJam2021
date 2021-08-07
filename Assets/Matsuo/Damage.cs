using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int m_life = 10;
    [SerializeField] GameObject m_explosionPrefab = null;





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))  // 衝突相手が 弾 だったら
        {
            Debug.Log("ダメージ");
            Destroy(collision.gameObject);  // 弾のオブジェクトを破棄する
            m_life--;   // ライフを減らす

            // ライフが 0 だったら
            if (m_life < 1)
            {
                // 爆発エフェクトを生成する
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }
                Destroy(this.gameObject);       // そして自分も破棄する
                Debug.Log("破壊");

            }
        }
    }
}