using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

    void Start()
    {
        SpawnBox();
    }

    public void SpawnBox()
    {
        GameObject box_Obj = Instantiate(box_Prefab);
        box_Obj.transform.position = transform.position;
    }
}
