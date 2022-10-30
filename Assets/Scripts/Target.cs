using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        rb.AddForce(Vector3.up * 600);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
