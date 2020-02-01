using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatySpawner : MonoBehaviour
{
    public List<GameObject> ilands;
    public float spawnTimeIsland;
    public float timer = 0;

    //Animals
    public List<GameObject> animals;
    public float spawTimerAnimal;
    public float animalTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        animalTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1 * Time.deltaTime;
        if(timer >= spawnTimeIsland)
        {
            //Select random fom iland 
            int rng = Random.Range(0, ilands.Count);
            GameObject selected = ilands[rng];
            //Give random variaton for spawn
            float rng2 = Random.Range(200, 800);
            Random gen = new Random();
            bool Boolean = (Random.value > 0.5f);
            if (Boolean != true)
            {
                rng2 = -rng2;
            }
            GameObject spawned = Instantiate(selected, new Vector3(2000, 0, 0), selected.transform.rotation);
            spawned.transform.parent = this.gameObject.transform;
            spawned.transform.localScale = new Vector3(10000, 10000, 10000);
            spawned.gameObject.AddComponent<ilandMover>().moveSpeed = 50;
            spawned.gameObject.GetComponent<ilandMover>().ofset = new Vector3(0, 0, rng2);
            //New random target to spawnIsland
            spawnTimeIsland = Random.Range(5.0f, 15.0f);
            timer = 0;
        }
        animalTimer = animalTimer + 1 * Time.deltaTime;
        if (animalTimer >= spawTimerAnimal)
        {
            //Select random fom animal 
            int rng = Random.Range(0, animals.Count);
            //Give random variaton for spawn
            float rng2 = Random.Range(200, 800);
            Random gen = new Random();
            bool Boolean = (Random.value > 0.5f);
            if (Boolean != true)
            {
                rng2 = -rng2;
            }
            GameObject selected = animals[rng];
            GameObject spawned = Instantiate(selected, new Vector3(1000, 0, 0), selected.transform.rotation);
            spawned.transform.parent = this.gameObject.transform;
            spawned.gameObject.AddComponent<ilandMover>().moveSpeed = 25;
            spawned.gameObject.AddComponent<Crest.SimpleFloatingObject>();
            spawned.gameObject.AddComponent<Rigidbody>();
            spawnTimeIsland = Random.Range(2.0f, 5.0f);
            animalTimer = 0;
        }


    }
}
