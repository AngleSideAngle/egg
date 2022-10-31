using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] Mesh replacementMesh;

    MeshFilter MeshFilter;

    public void Awake()
    {
        MeshFilter = GetComponent<MeshFilter>();
    }

    public void ReactToHit()
    {
        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        MeshFilter.mesh = replacementMesh;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
