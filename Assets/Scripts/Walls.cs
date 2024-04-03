using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public Hook script;
    public GameObject walls;
    public float startY;
    
    private void Update()
    {
        
        if(script.state == HookStates.Throw && (script.transform.position.y-startY) <= 20)
        {
            startY -= 10;
            Instantiate(walls,new Vector3(0,startY,0),Quaternion.identity,transform);
            Instantiate(walls, new Vector3(-20, startY, 0), Quaternion.identity,transform);
        }
    }
}
