using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Transform playerCameraTransform;

    [SerializeField] LayerMask pickUpPlaceLayerMask;

    //[SerializeField] MeshRenderer Fuse2;

    [SerializeField] GameObject Fuse2;

    [SerializeField] GameObject instructionGrabText;

    [SerializeField] GameObject instructionPlaceText;

    //[SerializeField]FirstPersonController firstPersonController;

    //[SerializeField] Rigidbody fuse1RigidBody;
    //[SerializeField] Rigidbody fuse2RigidBody;

    //[SerializeField] Transform fuse1;
    //[SerializeField] Transform fuse2;

    //[SerializeField] Transform objectPlacePoint1Transform;
    //[SerializeField] Transform objectPlacePoint2Transform;


    private ObjectGrab objectGrab;
    private ObjectPlace1 objectPlace1;
    private ObjectPlace2 objectPlace2;
    //private CameraController cameraController;
    //private FuseSpawn fuseSpawn;

    public float pickUpPlaceDistance = 2f;

    public bool objectGrabbed = false;
    public bool objectNowPlaced1 = false;
    public bool currentlyPlaced = false;

    Ray ray;
    RaycastHit raycastHit;
    //bool fuseHovered = false;

    //hi

    //private void Start()
    //{
    //    firstPersonController = GetComponent<FirstPersonController>();
    //}

    void Update()
    {
        StartCast();
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.transform.TryGetComponent(out objectGrab))
            {
                instructionGrabText.SetActive(true);
                //print(raycastHit.collider.name);

            }
            else
            {
                instructionGrabText.SetActive(false);
            }

            if (objectGrabbed == true)
            {
                instructionGrabText.SetActive(false);
            }
            //if ((objectNowPlaced1 == true) || (objectNowPlaced2 = true))
            //{
            //    instructionGrabText.SetActive(false);

            //    return;
            //}
        }
    }

    public void StartCast()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpPlaceDistance, pickUpPlaceLayerMask))
            {
                //float moveSpeed = firstPersonController.MoveSpeed;

                if (raycastHit.transform.TryGetComponent(out objectGrab) && objectGrabbed == false)
                 {
                     objectGrab.Grab();
                     objectGrabbed = true;

                    instructionPlaceText.SetActive(true);

                    //instructionPlaceText.SetActive(true);

                    //instructionText.SetActive(false);

                    //cameraController.ChangeCameraFOV();

                    //cameraController.ChangeCameraFOV(MoveSpeed);

                    //moveSpeed -= 2.5f;

                    return;
                }

                 //Figure out how to have the clicking the wrong fuseBox not still trigger
                 if (raycastHit.transform.TryGetComponent(out objectPlace1) && (objectGrabbed == true) && (objectNowPlaced1 == false))
                {
                    //if ((fuse1 = playerCameraTransform) && fuse2 != playerCameraTransform)
                    //{

                    Debug.Log("Place!");

                    objectPlace1.Place1();
                    objectGrabbed = false;

                    //Fuse2.enabled = true;

                    Fuse2.SetActive(true);


                    instructionPlaceText.SetActive(false);

                    objectNowPlaced1 = true;

                    currentlyPlaced = true;

                    //instructionGrabText.SetActive(false);

                    //moveSpeed += 2.5f;


                    return;
                    //}
                }

                if (raycastHit.transform.TryGetComponent(out objectPlace2) && (objectGrabbed == true) && (objectNowPlaced1 == true))
                {
                    //if ((fuse2 = playerCameraTransform) && (fuse1 != playerCameraTransform))
                    //{
                    
                    objectPlace2.Place2();
                    objectGrabbed = false;

                    currentlyPlaced = true;

                    instructionPlaceText.SetActive(false);

                    //instructionText.SetActive(false);

                    //moveSpeed += 2.5f;
                    //objectNowPlaced1 = true;

                    //fuseSpawn.Spawn();

                    return;
                    //}
                }
            }
        }
    }
}
