using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionForP2 : MonoBehaviour
{
    public GameObject m_Player2Prefab;

    void Start()
    {
        //１Ｐの座標を取得
        Vector2 Player1_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(Player1_pos.x,Player1_pos.y);


        //１Ｐの座標と対になるように２Ｐの座標を取得
        GameObject Player2 = Instantiate(m_Player2Prefab, new Vector2(-Player1_pos.x, -Player1_pos.y), Quaternion.identity);
        //GameObject Player2 = Instantiate(m_Player2Prefab, new Vector2(10, 10), Quaternion.identity);

    }

}
