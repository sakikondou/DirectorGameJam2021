using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    #region 変数
    /// <summary>
    /// 弾のプレファブ
    /// </summary>
    [SerializeField] GameObject m_bullet = null;
    /// <summary>
    /// マズル
    /// </summary>
    [SerializeField] Transform[] m_muzzles = null;
    /// <summary>
    /// デフォルトの射撃速度
    /// </summary>
    [SerializeField] float m_defaultFireRate = 0.3f;
    /// <summary>
    /// 射撃速度
    /// </summary>
    float m_fireRate = 0.3f;
    /// <summary>
    /// 射撃間隔
    /// </summary>
    float m_fireInterval = 0;
    /// <summary>
    /// 射撃間隔を計るタイマー
    /// </summary>
    float m_fireIntervalTimer = 0;
    /// <summary>
    /// 撃っているか
    /// </summary>
    bool m_isFire = false;
    Player m_player = null;
    #endregion

    private void Start()
    {
        m_fireRate = m_defaultFireRate;
        m_fireInterval = 60 / m_fireRate;
        m_player = GetComponent<Player>();
    }

    private void Update()
    {
        m_fireIntervalTimer += Time.deltaTime;

        #region キーボード操作
        if (GameManager.Instance.IsKeyboardOperation)
        {
            if (m_isFire &&
            m_fireIntervalTimer >= m_fireInterval)
            {
                m_fireIntervalTimer = 0;
                //マズルの数だけ弾を生成する
                for (int i = 0; i < m_muzzles.Length; i++)
                {
                    GameObject obj = Instantiate(m_bullet, m_muzzles[i]);
                    obj.SetActive(true);
                    obj.GetComponent<PlayerBullet>().Init(m_muzzles[i], transform, m_player.PlayerID);
                }
            }
            return;
        }

        #endregion

        if (m_isFire &&
            m_fireIntervalTimer >= m_fireInterval)
        {
            m_fireIntervalTimer = 0;
            //マズルの数だけ弾を生成する
            for (int i = 0; i < m_muzzles.Length; i++)
            {
                GameObject obj = Instantiate(m_bullet, m_muzzles[i]);
                obj.SetActive(true);
                obj.GetComponent<PlayerBullet>().Init(m_muzzles[i], transform, m_player.PlayerID);
            }
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
            m_isFire = true;
        if (context.canceled)
            m_isFire = false;
    }

    /// <summary>
    /// 連射速度を上げる
    /// </summary>
    /// <param name="addFireRate">加算する連射速度[弾数/分]</param>
    public void FireRateUp(float addFireRate)
    {
        m_fireRate = m_defaultFireRate + addFireRate;
        m_fireInterval = 60 / m_fireRate;
    }

    #region キーボード操作

    public void OnFire1(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 0)
        {
            if (context.started)
                m_isFire = true;
            if (context.canceled)
                m_isFire = false;
        }
    }

    public void OnFire2(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.IsKeyboardOperation && m_player.PlayerID == 1)
        {
            if (context.started)
                m_isFire = true;
            if (context.canceled)
                m_isFire = false;
        }
    }

    #endregion
}
