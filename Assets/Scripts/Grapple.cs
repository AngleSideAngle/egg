using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] float pullSpeed = 5f;
    [SerializeField] float accel = 1f;
    [SerializeField] float minDistance = 2f;
    [SerializeField] GameObject hookObj;
    [SerializeField] GameObject player;
    [SerializeField] Transform tf;

    Camera cam;
    Rigidbody rb;
    Hook hook;
    MoveBehaviour movement;

    bool isPulling = false;
    float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        rb = player.GetComponent<Rigidbody>();
        movement = player.GetComponent<MoveBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isPulling || hook is null) { return; }
        
        if (Vector3.Distance(transform.position, hook.transform.position) <= minDistance)
        {
            DestroyHook();
        }
        else
        {
            Vector3 direction = (hook.transform.position - transform.position).normalized;
            float dTime = Time.time - startTime;
            rb.AddForce(direction * (pullSpeed + dTime * accel), ForceMode.VelocityChange);
            rb.AddForce(Vector3.up * (pullSpeed / dTime));
        }
    }
    
    public void StartPull()
    {
        isPulling = true;
    }

    public void HookAction()
    {
        DestroyHook();
        CreateHook();
    
    }

    private void CreateHook()
    {
        StopAllCoroutines();
        isPulling = false;
        tf.rotation = cam.transform.rotation;
        GameObject hookInstance = Instantiate(hookObj, tf.position, Quaternion.identity);
        hook = hookInstance.GetComponent<Hook>();
        hook.Initialize(this, tf);
        StartCoroutine(HookLifetime());

        movement.SetJump(true);
        startTime = Time.time;
    }

    private void DestroyHook()
    {
        if (hook is null) { return; }

        isPulling = false;
        Destroy(hook.gameObject);
        hook = null;

        movement.SetJump(false);
    }

    private IEnumerator HookLifetime()
    {
        yield return new WaitForSeconds(8);
        DestroyHook();
    }
}
