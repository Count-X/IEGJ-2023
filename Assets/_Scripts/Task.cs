using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

    TaskManager.taskStates state;
    
    public GameObject[] stateObjects;

    public Slider progressSlider;
    public Sprite alertSprite;
    

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState (TaskManager.taskStates newState) {
        state = newState;
        switch (state) {
            case (TaskManager.taskStates)0:
                break;
            case (TaskManager.taskStates)1:
                break;
            case (TaskManager.taskStates)2:
                break;
        }
    }
}
