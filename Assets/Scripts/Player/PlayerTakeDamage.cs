using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    float m_maxHp = 10;
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
    /// 負けた時のエフェクト
    /// </summary>
    [SerializeField] GameObject m_losingEffect = null;

    Player player = null;

    private void Start()
    {
        player = GetComponent<Player>();
        m_hp = m_maxHp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))  // 衝突相手が 弾 だったら
        {
            //もし自分で生成した弾だったら無視する
            PlayerBullet playerBullet = collision.gameObject.GetComponent<PlayerBullet>();
            if (playerBullet)
            {
                if (player.PlayerID == playerBullet.ShooterID)
                    return;
            }

            Destroy(collision.gameObject);  // 弾のオブジェクトを破棄する
            m_hp--;   // ライフを減らす

            // ライフが 0 だったら
            if (m_hp < 1)
            {
                // 爆発エフェクトを生成する
                if (m_losingEffect != null)
                {
                    Instantiate(m_losingEffect, transform.position, Quaternion.identity);
                }
                SceneController.Instance.Result(player.PlayerID);
                // 自分を破棄する
                Destroy(this.gameObject);
            }
        }
    }
}