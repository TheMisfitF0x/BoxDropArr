using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

   

    public void SpawnBox()
    {
        GameObject box_Obj = Instantiate(box_Prefab);

        RandomizeBoxSize(box_Obj);

        Vector3 temp = transform.position;
        temp.z = 0f;

        box_Obj.transform.position = temp;
    }

    private void RandomizeBoxSize(GameObject box)
    {
        float minSize = .2f;
        float maxSize = .6f;

        float scaleX = Random.Range(minSize, maxSize);
        float scaleY = Random.Range(minSize, maxSize);

        box.transform.localScale = new Vector3(scaleX, scaleY, 1);
    }
}
