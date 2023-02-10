using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    
    public Transform[] targetTop;
    public Transform[] targetMid;
    public Transform[] targetBot;
    public List<GameObject> enemiesSpawnedTop = new List<GameObject>();
    public List<GameObject> enemiesSpawnedMid = new List<GameObject>();
    public List<GameObject> enemiesSpawnedBot = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

}
