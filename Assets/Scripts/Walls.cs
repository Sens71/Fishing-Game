using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public Hook script;
    public GameObject walls;
    private float y=-10;
    
    private void Update()
    {
        
        if(script.state == HookStates.Throw && (y-script.transform.position.y) <= 20)
        {
            y -= 10;
            Instantiate(walls,new Vector3(10,y,0),Quaternion.identity);
        }
    }
}
