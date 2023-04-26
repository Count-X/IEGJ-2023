using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TaskManager.taskStates = tState;

public class Task : MonoBehaviour
{   

    tState state;
    Transform player;

    bool canFix;
    float goodTime;
    float BreakTime;

    public float TimeToBreak = 3f;
    public float TimeThatStaysGood = 5f;
    public float DistanceLimit = 1f;

    public GameObject[] stateObjects;

    public BaseSlider<T0> progressSlider;
    public GameObject AlertObject;
    
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        ChangeState(TaskManager.taskStates.Good);
        goodTime = TimeThatStaysGood;
        progressSlider.highValue = TimeToBreak;
    }

    // Update is called once per frame
    void Update()
    {



        if( state != TaskManager.taskStates.Issue && Vector3.Distance(transform.position, player.position) <= DistanceLimit){
            canFix = true;
        }
        else{
            canFix = false;
        }

        if(canFix && Input.GetKeyDown(KeyCode.E)){
            BreakTime += Time.deltaTime;
            if(BreakTime >= TimeToFix){
                ChangeState(TaskManager.taskStates.Good);
                goodTime = TimeThatStaysGood;
            }
        }
        else{
            BreakTime -= Time.deltaTime;
            
        }

        switch (state) {
            case (TaskManager.taskStates)0:
                AlertObject.SetActive(false);
                goodTime -= Time.deltaTime;
            break;

            case (TaskManager.taskStates)1:
                AlertObject.SetActive(true);
                progressSlider.value = BreakTime;
            break;

            case (TaskManager.taskStates)2:
                AlertObject.SetActive(false);
            break;
        }
    }

    public void ChangeState (TaskManager.taskStates newState) {
        state = newState;
    }
}
