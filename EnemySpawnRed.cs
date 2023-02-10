using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRed : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Enemy enemy;
    private Enemy newEnemy;
    public List<Enemy> enemiesSpawnedTop = new List<Enemy>();
    public List<Enemy> enemiesSpawnedMid = new List<Enemy>();
    public List<Enemy> enemiesSpawnedBot = new List<Enemy>();
    public Transform[] targetTop;
    public Transform[] targetMid;
    public Transform[] targetBot;
    int i = 0;
    float timeRemainingTop = 30;
    float timeRemainingMid = 30;
    float timeRemainingBot = 30;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        spawnEnemiesTop(enemiesSpawnedTop, "Top");
        if (enemiesSpawnedTop.Count != 0 && gameObject.name.Equals("spawnTop"))
        {
            for (int i = 0; i<enemiesSpawnedTop.Count;i++){
                if (enemiesSpawnedTop[i]!=null){
                    moveEnemies(enemiesSpawnedTop[i], targetTop);
                    if (Vector3.Distance(enemiesSpawnedTop[i].transform.position, targetTop[1].position) < 2){
                        enemiesSpawnedTop.Remove(enemiesSpawnedTop[i]);
                        Destroy (enemiesSpawnedTop[i].gameObject);
                    }
                }
                
            }
            
        }

        spawnEnemiesMid(enemiesSpawnedMid, "Mid");
        if (enemiesSpawnedMid.Count != 0 && gameObject.name.Equals("spawnMid"))
        {
            for (int i = 0; i<enemiesSpawnedMid.Count;i++){
                if (enemiesSpawnedMid[i]!= null){
                    moveEnemies(enemiesSpawnedMid[i], targetMid);
                    if (Vector3.Distance(enemiesSpawnedMid[i].transform.position, targetMid[1].position) < 2){
                        enemiesSpawnedMid.Remove(enemiesSpawnedMid[i]);
                        Destroy (enemiesSpawnedMid[i].gameObject);
                    }
                }
                
            }
            
        }

        spawnEnemiesBot(enemiesSpawnedBot, "Bot");
        if (enemiesSpawnedBot.Count != 0 && gameObject.name.Equals("spawnBot"))
        {
            for (int i = 0; i<enemiesSpawnedBot.Count;i++){
                if (enemiesSpawnedBot[i]!=null){
                    moveEnemies(enemiesSpawnedBot[i], targetBot);
                    if (Vector3.Distance(enemiesSpawnedBot[i].transform.position, targetBot[1].position) < 2){
                        enemiesSpawnedBot.Remove(enemiesSpawnedBot[i]);
                        Destroy (enemiesSpawnedBot[i].gameObject);
                    }
                }
                
            }
            
        }

    }

    public void moveEnemies(Enemy enemy, Transform[] target)
    {
        agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(target[i].position);

        if (i == 0 && Vector3.Distance(agent.transform.position, target[i].position) < 2)
        {
            i = 1;
        }

    }
    public void spawnEnemiesTop(List<Enemy> enemiesSpawned, string lanePos)
    {
        if (timeRemainingTop > 0)
        {
            timeRemainingTop -= Time.deltaTime;

        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                newEnemy = Instantiate(enemy, transform.position, transform.rotation);
                newEnemy.setIsBlue(false);
                newEnemy.setLanePos(lanePos);
                if (!enemiesSpawned.Contains(newEnemy))
                {
                    enemiesSpawned.Add(newEnemy);
                }
            }
            timeRemainingTop = 30;
        }
    }
    public void spawnEnemiesMid(List<Enemy> enemiesSpawned, string lanePos)
    {
        if (timeRemainingMid > 0)
        {
            timeRemainingMid -= Time.deltaTime;

        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                newEnemy = Instantiate(enemy, transform.position, transform.rotation);
                newEnemy.setIsBlue(false);
                newEnemy.setLanePos(lanePos);
                if (!enemiesSpawned.Contains(newEnemy))
                {
                    enemiesSpawned.Add(newEnemy);
                }
            }
            timeRemainingMid = 30;
        }
    }
    public void spawnEnemiesBot(List<Enemy> enemiesSpawned, string lanePos)
    {
        if (timeRemainingBot > 0)
        {
            timeRemainingBot -= Time.deltaTime;

        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                newEnemy = Instantiate(enemy, transform.position, transform.rotation);
                newEnemy.setIsBlue(false);
                newEnemy.setLanePos(lanePos);
                if (!enemiesSpawned.Contains(newEnemy))
                {
                    enemiesSpawned.Add(newEnemy);
                }
            }
            timeRemainingBot = 30;
        }
    }
    public List<Enemy> getEnemiesSpawnedTop()
    {
        return enemiesSpawnedTop;
    }
    public List<Enemy> getEnemiesSpawnedMid()
    {
        return enemiesSpawnedMid;
    }
    public List<Enemy> getEnemiesSpawnedBot()
    {
        return enemiesSpawnedBot;
    }

    public void setEnemiesSpawnedTop(List<Enemy> enemies)
    {
        enemiesSpawnedTop = enemies;
    }
    public void setEnemiesSpawnedMid(List<Enemy> enemies)
    {
        enemiesSpawnedMid = enemies;
    }
    public void getEnemiesSpawnedBot(List<Enemy> enemies)
    {
        enemiesSpawnedBot = enemies;
    }
}
