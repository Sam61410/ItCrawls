using UnityEngine;

public class ObjectPlace1 : MonoBehaviour
{
    //[SerializeField] Transform playerCameraTransform;

    [SerializeField] Rigidbody fuse1RigidBody;
    //[SerializeField] Rigidbody fuse2RigidBody;
    //Rigidbody fuse1RigidBody;

    //[SerializeField] Transform fuse1;
    //[SerializeField] Transform fuse2;

    [SerializeField] Transform objectPlacePoint1Transform;
    //[SerializeField] Transform objectPlacePoint2Transform;

    

    Vector3 snapPosition;
    public float snapDistance = 1;
    //public float lerpSpeed = 10f;

    bool objectPlaced = false;
    //bool objectPlaced1 = false;
    //bool objectPlaced2 = false;

    Vector3 powerBoxPosition;

    public void Place1()
    {
        objectPlaced = true;
    }
    public void FixedUpdate()
    {
        
        if (objectPlaced == true)
        {
            //boxPosition = powerBox.position;

            if (Vector3.Distance(snapPosition, powerBoxPosition) < snapDistance)
            {
                //Fix so the other fuse doesn't move when clicking the wrong box

                //if ((fuse1 = playerCameraTransform) && fuse2 != playerCameraTransform)
                {
                    fuse1RigidBody.MovePosition(objectPlacePoint1Transform.position);
                    //objectPlaced1 = true;
                    //    return;
                    //}
                    //rigidBody.MovePosition(objectPlacePointTransform.position);

                    //if ((fuse2 = playerCameraTransform) && fuse1 != playerCameraTransform)
                    //{
                    //    fuse2RigidBody.MovePosition(objectPlacePoint2Transform.position);
                    //    //objectPlaced2 = true;
                    //    return;
                    //}

                }
            }
        }
    }
}
