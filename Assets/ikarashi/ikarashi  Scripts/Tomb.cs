using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    //[Tooltip("墓のPrefab"), SerializeField] GameObject m_tomb = default;

    [Tooltip("墓から出る怨霊のPrefab"), SerializeField] GameObject m_bullet = default;

    [Tooltip("墓のMuzzleの位置"), SerializeField] GameObject[] m_muzzles;

    [Tooltip("墓が消えるまでの時間"), SerializeField] float m_timer = 2.0f;

    /// <summary>
    /// プレイヤーの弾に当たったら自身から弾を発射して自身は消える
    /// </summary>
    /// <param name="collider">自身に当たってきた物</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("b");
        if (collider.gameObject.tag != "PlayerBullet") { return; }

        else
        {
            Debug.Log("a");
            for (int i = 0; i < m_muzzles.Length; i++)
            {
                GameObject go = Instantiate(m_bullet, m_muzzles[i].transform);
                Bullet bullet = go.GetComponent<Bullet>();
                if (bullet)
                {
                    bullet.Init(m_muzzles[i].transform, transform);
                }
                go.transform.parent = null;
            }
            Destroy(this, m_timer);
        }
    }
}
