using UnityEngine;

public class StartPositionForPlayer: MonoBehaviour
{
    public GameObject m_Player1Prefab;
    public GameObject m_Player2Prefab;

    void Start()
    {
        //スクリーン端座標
        var screen_top = 5.0f;
        var screen_bottom = -5.0f;
        var screen_left = -7.5f;

        //プレイヤーサイズ
        float player_width = GetComponent<Transform>().localScale.x;
        float player_height = GetComponent<Transform>().localScale.y;

        var playerPos_x = Random.Range(screen_left + player_width, -1.5f) ;
        var playerPos_y = Random.Range(screen_bottom + player_height, screen_top - player_width); 


        //１Ｐと２Ｐ生成
        GameObject Player1 = Instantiate(m_Player1Prefab, new Vector2(playerPos_x , playerPos_y),Quaternion.identity);
        GameObject Player2 = Instantiate(m_Player2Prefab, new Vector2(-playerPos_x , -playerPos_y),Quaternion.identity);

    }

}
