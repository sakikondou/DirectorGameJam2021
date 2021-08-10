using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBar : MonoBehaviour
{
    [SerializeField] PlayerTakeDamage m_damage;
    Image _slider;
    float _hp = 10;

    private void Start()
    {
        _slider = GetComponent<Image>();
    }

    void Update()
    {
        // HP上昇
        _hp = m_damage.Hp / m_damage.MaxHp;
        if (_hp < 0)
        {
            // 最大を超えたら0に戻す
            _hp = 0;
        }

        // HPゲージに値を設定
        _slider.fillAmount = _hp;
    }
}