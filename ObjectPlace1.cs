using UnityEngine;

public class ObjectPlace1 : MonoBehaviour
{

    [SerializeField] Rigidbody fuse1RigidBody;

    [SerializeField] Transform objectPlacePoint1Transform;

    Vector3 snapPosition;
    public float snapDistance = 1;

    bool objectPlaced = false;

    Vector3 powerBoxPosition;

    public void Place1()
    {
        objectPlaced = true;
    }
    public void FixedUpdate()
    {
        //If you click the power box while holding the first fuse/spark plug, Vector checks if you clicked close enough to the designated area of the box and is close enough, if so, tp the object to the box
        if (objectPlaced == true)
        {
            if (Vector3.Distance(snapPosition, powerBoxPosition) < snapDistance)
            {
                {
                    fuse1RigidBody.MovePosition(objectPlacePoint1Transform.position);

                }
            }
        }
    }
}
