using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private Transform[] moonPivots;
    [SerializeField]
    private Transform[] buildings;
    [SerializeField]
    private Vector3[] initPositions;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int numBuildings = 4;
    [SerializeField]
    private float maxDistance = 9;

    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject("target");
        initPositions = new Vector3[numBuildings];
        buildings = new Transform[numBuildings];
        for (int i = 0; i < numBuildings; i++) {
            float x = Random.Range(-maxDistance, maxDistance);
            float z = Random.Range(-maxDistance, maxDistance);
            GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 pos = new Vector3(x, 0, z);
            building.transform.position = pos;
            initPositions[i] = pos;
            buildings[i] = building.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // update planet and satelite orbits
        transform.RotateAround(target.transform.position, Vector3.forward, 10 * Time.deltaTime);
        foreach (Transform moon in moonPivots)
        {
            moon.RotateAround(target.transform.position, Vector3.forward, 10 * Time.deltaTime);
            moon.RotateAround(transform.position, Vector3.forward, 5 * Time.deltaTime);
        }

        // shake buildings
        for (int i = 0; i < numBuildings; i++) {
            buildings[i].position = initPositions[i] + Vector3.left * Mathf.Sin(Time.deltaTime) * 10;
        }
    }
}
