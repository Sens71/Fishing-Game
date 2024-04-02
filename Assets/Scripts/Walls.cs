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
        
        if(script.state == HookStates.Throw && (script.transform.position.y-y) <= 20)
        {
            y -= 10;
            Instantiate(walls,new Vector3(0,y,0),Quaternion.identity,transform);
            Instantiate(walls, new Vector3(-20, y, 0), Quaternion.identity,transform);
        }
    }
}
