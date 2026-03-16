using UnityEngine;

public class ObjectPlace2 : MonoBehaviour
{

    [SerializeField] Rigidbody fuse2RigidBody;

    [SerializeField] Transform objectPlacePoint2Transform;

    Vector3 snapPosition;
    public float snapDistance = 1;

    bool objectPlaced = false;
    private Vector3 boxPosition;

    public void Place2()
    {

        objectPlaced = true;
    }
    public void FixedUpdate()
    {
        //If you click the power box while holding the second fuse/spark plug, Vector checks if you clicked close enough to the designated area of the box and is close enough, if so, tp the object to the box
        if (objectPlaced == true)
        {
            if (Vector3.Distance(snapPosition, boxPosition) < snapDistance)
            {
                fuse2RigidBody.MovePosition(objectPlacePoint2Transform.position);

                return;
            }
        }
    }
}
