using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    [SerializeField] GameObject placable;
    [SerializeField] int range = 300;
    [SerializeField] int height = 100;
    [SerializeField] int times = 5;

    void Start()
    {
        for (int i = 0; i < times; i++)
        {
            float randX = Random.Range(0, range);
            float randY = Random.Range(0, range);
            Vector3 pos = new Vector3(randX, height, randY);
            Instantiate(placable, pos, Quaternion.identity);
        }
    }
}
