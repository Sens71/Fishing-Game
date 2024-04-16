using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public Fish[] fishPrefabs;
    private List<Fish> fishList = new List<Fish>();
    public Hook hook;
    public int fishAmount;
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
            if (f == null)
            {
                continue;
            }
            Destroy(f.gameObject);
        }
        fishList.Clear();
        for(int i = 1; i < fishAmount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-12, -7), Random.Range(-3, -2) * i, 0);
            Fish prefab;
            if(position.y > -20)
            {
                prefab = fishPrefabs[0];
            }
            else if (position.y <= -20 && position.y > -40)
            {
                prefab = fishPrefabs[1];
            }
            else
            {
                prefab= fishPrefabs[2];
            }
            Fish newfish= Instantiate(prefab,position,Quaternion.identity,transform);
            fishList.Add(newfish);
        }
    }
    void Update()
    {
        
    }
}
