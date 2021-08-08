using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBar : MonoBehaviour
{
    [SerializeField] Damage m_damage;
    Slider _slider;
    float _hp = 10;

    //追記
    public static bool m_gameFinished = false;


    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }


    void Update()
    {
        // HP上昇
        _hp = m_damage.Hp / m_damage.MaxHp;
        if (_hp < 0)
        {
            // 最大を超えたら0に戻す
            _hp = 0;

            m_gameFinished = true;
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }
}