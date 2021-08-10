using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmEf : MonoBehaviour
{
    [SerializeField] GameObject m_hpBar = null;

    private void OnTriggerEnter2D(Collider2D collider)
    {
      Instantiate(m_hpBar, this.transform.position, m_hpBar.transform.rotation);
    }
}
