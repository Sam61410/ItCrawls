using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] Transform objectGrabPointTransform;

    public float lerpSpeed = 10f;

    bool objectGrabbed = false;

    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        objectGrabbed = true;
    }

    public void FixedUpdate()
    {
        //If you grabbed the fuse/spark plug, the object smoothly draws/floats to you(objectGrabPointTransform)
        if (objectGrabbed == true)
        {
            Vector3 newGrabbedPosition = Vector3.Lerp(rigidBody.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);

            rigidBody.MovePosition(newGrabbedPosition);

            return;
        }
    }
}
