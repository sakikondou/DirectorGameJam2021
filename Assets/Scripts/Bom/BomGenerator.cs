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

    void Start()
    {
        for (int x = 0; x < m_indexNumX; x++)
        {
            for (int y = 0; y < m_indexNumY; y++)
            {
                GameObject spawnPoint = Instantiate(m_spawn, transform);

                spawnPoint.transform.position = new Vector2(transform.position.x + x, transform.position.y + y);

                m_spawnPoints.Add(spawnPoint.transform);
                if (x == 0 && y == 0)
                {
                    Instantiate(m_bom, spawnPoint.transform);
                }
                if (x == m_indexNumX - 1 && y == 0)
                {
                    Instantiate(m_bom, spawnPoint.transform);
                }
                if (x == 0 && y == m_indexNumY - 1)
                {
                    Instantiate(m_bom, spawnPoint.transform);
                }
                if (x == m_indexNumX - 1 && y == m_indexNumY - 1)
                {
                    Instantiate(m_bom, spawnPoint.transform);
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
            Spawn();
            m_timer = 0;
            m_interval -= m_decreaseIntervalValue;
            if (m_interval < 1)
            {
                m_minSpawnCount = 20;
                m_maxSpawnCount = 40;
            }
            if (m_interval < 2)
            {
                m_minSpawnCount = 15;
                m_maxSpawnCount = 30;
            }
            if (m_interval < 3)
            {
                m_minSpawnCount = 10;
                m_maxSpawnCount = 20;
            }
        }
    }
    /// <summary>
    /// 爆弾のランダム配置
    /// </summary>
    void Spawn()
    {
        List<int> spawnedIndexs = new List<int>();
        int spawnCount = Random.Range(m_minSpawnCount, m_maxSpawnCount);
        for (int count = 0; count < spawnCount; count++)
        {
            int spawnIndex = Random.Range(0, m_spawnPoints.Count);
            if (!spawnedIndexs.Contains(spawnIndex))
            {
                Instantiate(m_bom, m_spawnPoints[spawnIndex]);
                spawnedIndexs.Add(spawnIndex);
            }
            else
            {
                count--;
            }
        }
    }
}
