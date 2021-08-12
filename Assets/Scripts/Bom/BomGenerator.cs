using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomGenerator : MonoBehaviour
{
    [Tooltip("墓の生成場所"), SerializeField] GameObject m_spawn = default;
    [Tooltip("墓のPrefab"), SerializeField] GameObject m_bom = default;
    [Tooltip("横に何個並べるか"), SerializeField] int m_indexNumX = 16;
    [Tooltip("縦に何個並べるか"), SerializeField] int m_indexNumY = 10;
    /// <summary>
    /// 生成するポジションのリスト
    /// </summary>
    List<Transform> m_spawnPoints = new List<Transform>();

    /// <summary>
    /// 一度に生成される爆弾の最多個数
    /// </summary>
    [SerializeField] int m_maxSpawnCount = 10;
    /// <summary>
    /// 一度に生成される爆弾の最少個数
    /// </summary>
    [SerializeField] int m_minSpawnCount = 1;
    /// <summary>
    /// 生成する間隔
    /// </summary>
    [SerializeField] float m_interval = 5f;
    /// <summary>
    /// 生成する間隔を狭める値
    /// </summary>
    [SerializeField] float m_decreaseIntervalValue = 0.2f;
    /// <summary>
    /// bombの最大数
    /// </summary>
    [SerializeField] int m_count = 100;

    List<int> spawnedIndexs = new List<int>();

    List<GameObject> bombObjs = new List<GameObject>();



    void Start()
    {
        for (int y = 0; y < m_indexNumX; y++)
        {
            for (int x = 0; x < m_indexNumY; x++)
            {
                GameObject spawnPoint = Instantiate(m_spawn, transform);
                spawnPoint.transform.position = new Vector2(transform.position.x + y, transform.position.y + x);

                m_spawnPoints.Add(spawnPoint.transform);
                if (y == 0 && x == 0)//左下
                {
                    Spawn(0);
                }
                if (y == m_indexNumX - 1 && x == 0)//右下
                {
                    Spawn((m_indexNumX - 1) * m_indexNumY);
                }
                if (y == 0 && x == m_indexNumY - 1)//左上
                {
                    Spawn(m_indexNumY - 1);
                }
                if (y == m_indexNumX - 1 && x == m_indexNumY - 1)//右上
                {
                    Spawn(m_indexNumY * m_indexNumX - 1);
                }
            }
        }
    }
    float m_timer = 0;
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_interval)
        {
            SetBomb();
            m_timer = 0;
            m_interval -= m_decreaseIntervalValue;
        }
    }
    /// <summary>
    /// 爆弾の配置
    /// </summary>
    void SetBomb()
    {
        int spawnIndex = Random.Range(0, m_spawnPoints.Count + 1);

        if (!spawnedIndexs.Contains(spawnIndex))
        {
            Spawn(spawnIndex);
        }
    }
    void Spawn(int index)
    {
        if (spawnedIndexs.Count < m_count)
        {
            spawnedIndexs.Add(index);
            GameObject bombObj = Instantiate(m_bom, m_spawnPoints[index]);
            bombObj.GetComponent<Bom>().Init(this, index);
        }

    }
    public void RemoveSpawnPoints(int bombId)
    {
        spawnedIndexs.Remove(bombId);
        Debug.Log(bombObjs.Count);
    }
}
