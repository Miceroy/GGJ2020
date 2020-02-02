using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashSpawner : MonoBehaviour
{
    [SerializeField]
    private bool m_useRandomSplashes = true;
    [SerializeField]
    private List<Transform> m_waterSplashPositions = null;
    [SerializeField]
    private GameObject m_waterSplashPrefab = null;

    [SerializeField]
    private float m_splashTime = 10f;


    private float m_timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!m_useRandomSplashes)
            return;

        m_timer += Time.deltaTime;
        if (m_timer >= m_splashTime)
        {
            m_timer = 0f;
            Transform _splashPosition = m_waterSplashPositions[Random.Range(0, m_waterSplashPositions.Count)];
            spawnSplash(_splashPosition);
        }
    }

    private void spawnSplash(Transform positionToSpawnSplash)
    {
        float _xOffset = Random.Range(-1f, 1f);
        float _zOffset = Random.Range(-1f, 1f);
        Vector3 _spawnPos = positionToSpawnSplash.position;
        _spawnPos.x += _xOffset;
        _spawnPos.z += _zOffset;

        GameObject _go = Instantiate(m_waterSplashPrefab, _spawnPos, positionToSpawnSplash.rotation, positionToSpawnSplash);
        _go.SetActive(true);
        Destroy(_go, 2f);
    }
}
