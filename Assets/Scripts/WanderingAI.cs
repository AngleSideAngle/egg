using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float range = 1.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance <= range)
            {
                float angle = Random.Range(-180, 180);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
