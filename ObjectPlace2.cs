using UnityEngine;

public class ObjectPlace2 : MonoBehaviour
{

    [SerializeField] Rigidbody fuse2RigidBody;

    [SerializeField] Transform objectPlacePoint2Transform;

    Vector3 snapPosition;
    public float snapDistance = 1;
    //public float lerpSpeed = 10f;

    //const string fuse1String = "Fuse1";
    //const string fuse2String = "Fuse2";

    bool objectPlaced = false;
    private Vector3 boxPosition;

    public void Place2()
    {

        objectPlaced = true;
    }
    public void FixedUpdate()
    {

        if (objectPlaced == true)
        {
            if (Vector3.Distance(snapPosition, boxPosition) < snapDistance)
            {
                fuse2RigidBody.MovePosition(objectPlacePoint2Transform.position);

                return;
                //}
                //if (CompareTag(fuse2String))
                //{
                //    fuse2RigidBody.MovePosition(objectPlacePoint2Transform.position);
                //}

                //return;
            }
        }
    }
}
