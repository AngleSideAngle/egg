using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAim : MonoBehaviour
{
    private Camera camera;
    private GameBehavior gameManager;
    [SerializeField] private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        // gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
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
                GameObject hitObject = hit.transform.gameObject;

                Target target = hitObject.GetComponent<Target>();
                if (target != null)
                {
                    gameManager.Items += 1;
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        // create new object for 5 seconds
        GameObject instance = Instantiate(obj, pos + Vector3.up, Quaternion.identity);
        yield return new WaitForSeconds(8);

        // disable rigidbody after 5 seconds
        // var rb = instance.GetComponent<Rigidbody>();
        // rb.isKinematic = true;
        // rb.detectCollisions = false;
        Destroy(instance);
    }
}
