using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{    /// <summary>
     /// プレイヤーのID
     /// </summary>
    int m_shooterID = -1;
    /// <summary>
    /// プレイヤーのID
    /// </summary>
    public int ShooterID { private set { m_shooterID = value; } get { return m_shooterID; } }

    public void Init(Transform mazzles, Transform shooter, int shooterID)
    {
        base.Init(mazzles, shooter);
        m_shooterID = shooterID;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))  // 衝突相手が 壁 だったら
        {
            Destroy(gameObject);  // 弾のオブジェクトを破棄する
        }
    }
}
