using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update

    bool mouseButtonBeingPressed;

    void Start()
    {
        mouseButtonBeingPressed = false;
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    void Update()
    {
        if(!Input.GetMouseButton(0)){
            return;
        }
    }

    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            if (Input.GetMouseButton(0) ){
    
                return Input.GetAxis("Mouse X");
            } else{
       
                return 0;
            }
        }
        else if (axisName == "Mouse Y" ){
            if (Input.GetMouseButton(0)){
            
                return Input.GetAxis("Mouse Y");
            } else{

                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}

