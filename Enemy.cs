using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private int hp = 100;
    private int maxHp = 100;
    [SerializeField] private int xp = 4;
    private float radius = 1f;
    [SerializeField] private GameObject interactionPoint;

    private bool isBlue = true;
    private string lanePos = "";
    public static Enemy instance;
    [SerializeField] private Slider sliderHealthbar;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        interactionPoint = GameObject.Find("InteractionPoint");
        sliderHealthbar.value = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        sliderHealthbar.value = hp;
    }

    void OnCollisionEnter(Collider collider)
    {
        string actualName = this.gameObject.name;
        if (actualName.Contains("blue"))
        {
            if (collider.gameObject.name.Contains("red"))
            {
                collider.gameObject.GetComponent<Enemy>().setHp(0);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(interactionPoint.transform.position, radius);
    }
    public void setIsBlue(bool value)
    {
        this.isBlue = value;
    }
    public bool getIsBlue()
    {
        return isBlue;
    }

    public void setLanePos(string position)
    {
        this.lanePos = position;
    }
    public string getLanePos()
    {
        return lanePos;
    }

    public static explicit operator Enemy(GameObject v)
    {
        throw new NotImplementedException();
    }
    public int getHp()
    {
        return this.hp;
    }
    public int getMaxHp()
    {
        return this.maxHp;
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }

    public int getXp()
    {
        return this.xp;
    }
    public void setXp(int xp)
    {
        this.xp = xp;
    }

}
