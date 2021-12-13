using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject destination;
    public float spawnSpeed = 3.0f;
    public int number = 10;
    

    float delta = 0;
    EnemyAI target1;
    Pathfinding.AIDestinationSetter target2;
    Enemy dmg;

    private void Start()
    {
        target1 = spawn.GetComponent<EnemyAI>();
        target2 = spawn.GetComponent<Pathfinding.AIDestinationSetter>();
        if (target1 != null)
        {
            target1.target = destination.transform;
        }
        if (target2 != null)
        {
            target2.target = destination.transform;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (number > 0)
        {
            delta += Time.deltaTime;
            if (delta > spawnSpeed)
            {
                delta = 0;
                Instantiate(spawn);
                number--;
            }
        }
    }
}
