using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{

    [Tooltip("墓から出る怨霊のPrefab"), SerializeField] GameObject m_bullet = default;

    [Tooltip("墓のMuzzleの位置"), SerializeField] GameObject[] m_muzzles;

    [Tooltip("墓が消えるまでの時間"), SerializeField] float m_timer = 2.0f;

    [SerializeField] GameObject m_bomEfect = null;

    /// <summary>
    /// プレイヤーの弾に当たったら自身から弾を発射して自身は消える
    /// </summary>
    /// <param name="collider">自身に当たってきた物</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Bullet")
            return;

        for (int i = 0; i < m_muzzles.Length; i++)
        {
            GameObject go = Instantiate(m_bullet, m_muzzles[i].transform);
            go.SetActive(true);
            BomBullet bullet = go.GetComponent<BomBullet>();
            if (bullet)
            {
                bullet.Init(m_muzzles[i].transform, transform);
            }
            go.transform.parent = null;
        }

        if (m_bomEfect)
            Instantiate(m_bomEfect, this.transform.position, m_bomEfect.transform.rotation);

        Destroy(this.gameObject);
    }

}
