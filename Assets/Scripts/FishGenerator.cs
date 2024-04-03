using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public Fish[] fishPrefabs;
    private List<Fish> fishList = new List<Fish>();
    public Hook hook;
    void Start()
    {
        Fish[] startFish = FindObjectsOfType<Fish>();
        foreach(Fish f in startFish)
        {
            fishList.Add(f);
        }
    }
    private void OnEnable()
    {
        hook.OnRetrieve += GenerateFish;
    }
    private void OnDisable()
    {
        hook.OnRetrieve -= GenerateFish;
    }


    private void GenerateFish()
    {
        foreach(Fish f in fishList)
        {
            fishList.Remove(f);
            Destroy(f.gameObject);
        }
        for(int i = 1; i < 10; i++)
        {
            Fish newfish= Instantiate(fishPrefabs[0],new Vector3(-10,-2*i,0),Quaternion.identity,transform);
            fishList.Add(newfish);
        }
    }
    void Update()
    {
        
    }
}
