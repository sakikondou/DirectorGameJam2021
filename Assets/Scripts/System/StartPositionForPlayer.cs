using UnityEngine;

public class StartPositionForPlayer : MonoBehaviour
{
    GameObject[] playerObjs;
    [SerializeField] GameObject m_result1;
    [SerializeField] GameObject m_result2;
    public Color m_color;
    void Start()
    {
        //プレイヤータグのオブジェクトを検索する
        playerObjs = GameObject.FindGameObjectsWithTag("Player");

        //スクリーン端座標
        var screen_top = 5.0f;
        var screen_bottom = -5.0f;
        var screen_left = -7.5f;

        //プレイヤーサイズ
        float player_width = GetComponent<Transform>().localScale.x;
        float player_height = GetComponent<Transform>().localScale.y;

        var playerPos_x = Random.Range(screen_left + player_width, -1.5f);
        var playerPos_y = Random.Range(screen_bottom + player_height, screen_top - player_width);

        playerObjs[0].transform.position = new Vector2(playerPos_x, playerPos_y);
        playerObjs[1].transform.position = new Vector2(-playerPos_x, -playerPos_y);
    }
}
