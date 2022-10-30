using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25f;

    Grapple grapple;
    Transform start;
    Rigidbody rb;
    LineRenderer line;

    public void Initialize(Grapple grappleScript, Transform starting)
    {
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();

        start = starting;
        transform.forward = starting.forward;
        grapple = grappleScript;

        rb.AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        // create line from the grapple to the hook
        line.SetPositions(new Vector3[] {start.transform.position, transform.position});
    }

    void OnTriggerEnter(Collider other)
    {
        // bitshifting wizardy from the internet
        // layers are used for raycast hits and rendering
        // & is AND condition without short circuiting
        // `1 << other.gameObject.layer` shifts 00...1 left by the layer # of other
        // then they're combined using AND logic
        // I believe this is to make sure the grapple does not collide with itself
        if ((LayerMask.GetMask("Grapple") & 1 << other.gameObject.layer) > 0)
        {
            rb.useGravity = false;
            rb.isKinematic = true;

            grapple.StartPull();
        }
    }
}
