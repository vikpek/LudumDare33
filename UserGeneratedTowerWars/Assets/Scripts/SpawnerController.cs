using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour
{

    private float spawnDuration = 5f;

    private float spawnStart = 5f;

    [SerializeField]
    private GameObject enemy;



    void Start()
    {
        print(enemy.name);
        if (enemy.name == "EnemyBig")
        {
            spawnStart = 12f;
            spawnDuration = 10f;
        }
        if (enemy.name == "EnemyQuick")
        {
            spawnStart = 8f;
            spawnDuration = 5f;
        }
        if (enemy.name == "Enemy")
        {
            spawnStart = 3f;
            spawnDuration = 4f;
        }
        
         InvokeRepeating("LaunchEnemy", spawnStart, spawnDuration);
    }

    void LaunchEnemy()
    {
        

        for (int i = 0; i < GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>().GetPhaseCount(); i++)
        {
            enemy.transform.position = transform.position + (Vector3.down * i);
            Instantiate(enemy);
        }
        
        
    }   
}
