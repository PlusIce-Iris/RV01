using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody.AddForceAtPosition(Physics.gravity/ floaterCount, transform.position, ForceMode.Acceleration);
        float waveheight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveheight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveheight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position,ForceMode.Acceleration);
            rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        
    }
}
