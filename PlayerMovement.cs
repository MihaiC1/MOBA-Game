using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Camera mainCamera;
    public Camera topCamera;
    public UnityEngine.AI.NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        mainCamera.enabled = false;
        topCamera.enabled = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.enabled){
            if (Input.GetMouseButtonDown(0)){
                Ray mouseClickRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(mouseClickRay, out hit)){
                    agent.SetDestination(hit.point);
                }
            }
        }
        else{
            if (Input.GetMouseButtonDown(0)){
                Ray mouseClickRay = topCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(mouseClickRay, out hit)){
                    //this.gameObject.GetComponent<Animator>().Play("Fox_Run_InPlace");
                    
                    agent.SetDestination(hit.point);
                    this.gameObject.GetComponent<Animator>().SetBool("isRunning", true);

                    if (this.transform.position == hit.transform.position){
                        
                        this.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
                    }
                    //this.gameObject.GetComponent<Animator>().Play("Fox_Idle");
                }
            }
        }
            

        if (Input.GetKeyDown(KeyCode.M)){
            mainCamera.enabled = true;
            topCamera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.T)){
            mainCamera.enabled = false;
            topCamera.enabled = true;
        }
    }
}
