using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    RaycastHit hit;
    public LayerMask layerToHit;
    public static Player instance;
    [SerializeField] private Camera topCamera;

    [SerializeField] private int hp;
    [SerializeField] private int xp;
    [SerializeField] private int attackValue;
    [SerializeField] private Slider sliderHealthbar = null;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        rightClickAttack();
    }

    private void rightClickAttack()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = topCamera.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(1))
        {

            if (Physics.Raycast(ray, out hit))
            {

                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                

                if (enemy != null && enemy.name.Equals("EnemyBlue(Clone)"))
                {

                    int actualHp = enemy.getHp() - attackValue;
                    
                    if (actualHp < 0){
                        enemy.setHp(0);
                    }
                    else{
                        enemy.setHp(actualHp);
                    }
                    
                    Debug.Log("Now hp = " + enemy.getHp());
                    if (enemy.getHp() <= 0)
                    {
                        xp += enemy.getXp();
                        Destroy(enemy.gameObject);
                    }

                }

            }
        }
    }

    public int getHp()
    {
        return this.hp;
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
