using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float height = 0f;
    [SerializeField] private float rate = 0.01f;
    [SerializeField] private GameObject thing;

    // Update is called once per frame
    void Update()
    {
        if (Random.value <= rate)
        {
            Instantiate(thing, new Vector3(Random.Range(-range, range) + transform.position.x, height, + Random.Range(-range, range) + transform.position.z), Quaternion.identity);
        }
    }
}
