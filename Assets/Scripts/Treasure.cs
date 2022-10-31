using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] Mesh replacementMesh;

    MeshFilter meshFilter;
    AudioSource audio;

    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        audio = GetComponent<AudioSource>();
    }

    public void ReactToHit()
    {
        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        meshFilter.mesh = replacementMesh;
        audio.Play();
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
