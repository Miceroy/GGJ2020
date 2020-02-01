using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main game controller.
/// </summary>
public class GameManager : MonoBehaviour
{
    private Vector3 getRandomSpawnPoint()
    {
        Debug.AssertFormat(GameObject.FindGameObjectWithTag("PlayerBoat"), "PlayerBoat not found");
        Vector3 res = GameObject.FindGameObjectWithTag("PlayerBoat").transform.position;
        float angle = Random.Range(0, 2.0f*Mathf.PI);
        float x = Mathf.Cos(angle) * spawnRadius;
        float y = Mathf.Sin(angle) * spawnRadius;
        res.x += x;
        res.y = 1;
        res.z += y;
        return res;
    }

    public GameObject enemyBoatPrefab;
    public float spawnRadius = 100;
    public List<GameComponent> gameComponents = new List<GameComponent>();
    public List<EnemyBoatController> enemyBoats = new List<EnemyBoatController>();

    public void registerComponent(GameComponent newComponent)
    {
        gameComponents.Add(newComponent);
        EnemyBoatController enemyBoat = (EnemyBoatController)newComponent;
        if (enemyBoat) enemyBoats.Add(enemyBoat);
    }

    public void unregisterComponent(GameComponent componentToRemove)
    {
        gameComponents.Remove(componentToRemove);
        EnemyBoatController enemyBoat = (EnemyBoatController)componentToRemove;
        if (enemyBoat) enemyBoats.Remove(enemyBoat);
    }

    public void spawnNewEnemy()
    {
        GameObject enemyBoat = GameObject.Instantiate(enemyBoatPrefab, getRandomSpawnPoint(),Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( enemyBoats.Count < 4)
        {
            spawnNewEnemy();
        }
    }
}
