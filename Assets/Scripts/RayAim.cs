using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAim : MonoBehaviour
{
    private Camera camera;
    private Grapple grapple;
    private GameBehavior gameManager;
    // [SerializeField] private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        grapple = camera.GetComponent<Grapple>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Vector3 point = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("raycast hit");
                GameObject hitObject = hit.transform.gameObject;

                Treasure target = hitObject.GetComponent<Treasure>();
                Debug.Log(hitObject);
                if (target != null)
                {
                    Debug.Log("hit isnt null");
                    gameManager.Items += 1;
                    target.ReactToHit();
                }
                return;
            }
            grapple.DestroyHook();
        }
    }
}
