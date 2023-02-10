using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agentRed;
    [SerializeField] private NavMeshAgent agentBlue;
    [SerializeField] private GameObject spawnRed;
    [SerializeField] private GameObject spawnBlue;
    [SerializeField] private Transform[] checkPointsTop;
    [SerializeField] private Transform[] checkPointsBot;
    [SerializeField] private Transform[] checkPointsMid;

    [SerializeField] private GameObject enemiesSpawned;
    private int timeUntilSpawn = 10;
    private int i = 0;
    private int timeBetweenSpawns = 20;
    private int radius = 3;
    private bool cancelInvoke = false;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("spawnEnemies", timeUntilSpawn, timeBetweenSpawns);
    }

    public void spawnEnemies()
    {
        

        NavMeshAgent redEnemyTop;
        NavMeshAgent redEnemyMid;
        NavMeshAgent redEnemyBot;

        NavMeshAgent blueEnemyTop;
        NavMeshAgent blueEnemyMid;
        NavMeshAgent blueEnemyBot;

        for (int i = 0; i < 2; i++)
        {
            redEnemyTop = Instantiate(agentRed, spawnRed.transform.GetChild(0).transform.position, spawnRed.transform.GetChild(0).transform.rotation);
            redEnemyTop.transform.parent = enemiesSpawned.transform;
            redEnemyTop.gameObject.GetComponent<Enemy>().setLanePos("Top");
            moveEnemies(redEnemyTop, checkPointsTop);

            redEnemyMid = Instantiate(agentRed, spawnRed.transform.GetChild(1).transform.position, spawnRed.transform.GetChild(1).transform.rotation);
            redEnemyMid.transform.parent = enemiesSpawned.transform;
            redEnemyTop.gameObject.GetComponent<Enemy>().setLanePos("Mid");
            moveEnemies(redEnemyMid, checkPointsMid);

            redEnemyBot = Instantiate(agentRed, spawnRed.transform.GetChild(2).transform.position, spawnRed.transform.GetChild(2).transform.rotation);
            redEnemyBot.transform.parent = enemiesSpawned.transform;
            redEnemyTop.gameObject.GetComponent<Enemy>().setLanePos("Bot");
            moveEnemies(redEnemyBot, checkPointsBot);

            blueEnemyTop = Instantiate(agentBlue, spawnBlue.transform.GetChild(0).transform.position, spawnBlue.transform.GetChild(0).transform.rotation);
            blueEnemyTop.transform.parent = enemiesSpawned.transform;
            blueEnemyTop.gameObject.GetComponent<Enemy>().setLanePos("Top");
            moveEnemies(blueEnemyTop, checkPointsTop);

            blueEnemyMid = Instantiate(agentBlue, spawnBlue.transform.GetChild(1).transform.position, spawnBlue.transform.GetChild(1).transform.rotation);
            blueEnemyMid.transform.parent = enemiesSpawned.transform;
            blueEnemyMid.gameObject.GetComponent<Enemy>().setLanePos("Mid");
            moveEnemies(blueEnemyMid, checkPointsMid);

            blueEnemyBot = Instantiate(agentBlue, spawnBlue.transform.GetChild(2).transform.position, spawnBlue.transform.GetChild(2).transform.rotation);
            blueEnemyBot.transform.parent = enemiesSpawned.transform;
            blueEnemyBot.gameObject.GetComponent<Enemy>().setLanePos("Bot");
            moveEnemies(blueEnemyBot, checkPointsBot);
           
        }

        if (cancelInvoke)
        {
            CancelInvoke("spawnEnemies");
        }
    }
    public void moveEnemies(NavMeshAgent enemy, Transform[] target)
    {
        
        enemy.SetDestination(target[0].position);
        

        float d = Vector3.Distance(enemy.transform.position, Player.instance.gameObject.transform.position);
        if (d < radius && enemy.gameObject.name.Contains("blue"))
        {
            enemy.SetDestination(Player.instance.gameObject.transform.position);
        }
        
        if (Vector3.Distance(enemy.transform.position, target[0].position) < 2)
        {
            
            enemy.SetDestination(target[1].position);
        }


        if (Vector3.Distance(enemy.transform.position, GameObject.Find("RedBase").transform.position) < 2 && enemy.gameObject.name.Contains("red"))
        {
            Debug.Log("Enemies are in our base!");
            Destroy(enemy);
        }
        if (Vector3.Distance(enemy.transform.position, GameObject.Find("BlueBase").transform.position) < 2 && enemy.gameObject.name.Contains("blue"))
        {
            Debug.Log("Enemies are in our base!");
            Destroy(enemy);
        }


    }
}
