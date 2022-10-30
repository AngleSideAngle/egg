using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    [SerializeField] GameObject character;

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                Instantiate(character, new Vector3(i * 5, 0, j * 5), Quaternion.identity);
            }
        }
        

    }
}
