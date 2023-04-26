using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Task : MonoBehaviour
{   

    TaskManager.taskStates state;
    Transform player;

    bool canFix;
    float goodTime;
    float BreakTime;
    
    public float TimeToBreak = 3f;
    public float TimeThatStaysGoodMin = 5f;
    public float TimeThatStaysGoodMax = 30f;
    public float DistanceLimit = 1f;

    public Slider progressSlider;
    public GameObject AlertObject;
    
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        ChangeState(TaskManager.taskStates.Good);
        goodTime = RandomizeTime();
        BreakTime = TimeToBreak;
        
    }

    // Update is called once per frame
    void Update()
    {


        switch (state) {
            case (TaskManager.taskStates)0:
                AlertObject.SetActive(false);
                if(goodTime <= 0f){
                    ChangeState(TaskManager.taskStates.Issue);
                    gameObject.GetComponent<AudioSource>().Play();
                }
                else{
                goodTime -= Time.deltaTime;
                }
                Debug.Log("Hello");
            break;

            case (TaskManager.taskStates)1:
                AlertObject.SetActive(true);
                progressSlider.value = BreakTime;
                if(Vector3.Distance(transform.position, player.position) >= DistanceLimit){
                    canFix = true;
                    Debug.Log("Canfix" + canFix);
                }
                else{
                    canFix = false;
                }

                if(canFix && Input.GetKeyDown(KeyCode.E)){
                    BreakTime += Time.deltaTime;
                    if(BreakTime > TimeToBreak){
                        ChangeState(TaskManager.taskStates.Good);
                        goodTime = RandomizeTime();
                        BreakTime = TimeToBreak;
                    }
                }
                else{
                    BreakTime -= Time.deltaTime;
                    if(BreakTime <= 0f){
                        ChangeState(TaskManager.taskStates.Broken);
                    }
                }
                Debug.Log("Hello1");
            break;

            case (TaskManager.taskStates)2:
                AlertObject.SetActive(false);
                Destroy(AlertObject);
                Destroy(this);
            break;
        }
    }

    public void ChangeState (TaskManager.taskStates newState) {
        state = newState;
    }
    
    float RandomizeTime(){
        return Random.Range(TimeThatStaysGoodMin, TimeThatStaysGoodMax);
    }
}
