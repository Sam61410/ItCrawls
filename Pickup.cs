using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Transform playerCameraTransform;

    //Put the fuse/spark plug on unique layer
    [SerializeField] LayerMask pickUpLayerMask;
    [SerializeField] GameObject Fuse2;
    [SerializeField] GameObject instructionGrabText;
    [SerializeField] GameObject instructionPlaceText;

    private ObjectGrab objectGrab;
    private ObjectPlace1 objectPlace1;
    private ObjectPlace2 objectPlace2;
    private EndGame endGame;


    public float pickUpPlaceDistance = 2f;

    public bool objectGrabbed = false;
    public bool objectNowPlaced1 = false;
    public bool bothPlaced = false;

    Ray ray;
    RaycastHit raycastHit;

    void Update()
    {
        StartCast();
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
        {
            //If you are aimed at a fuse/spark plug, enable the "grab" instructions to know to how pick it up
            if (raycastHit.transform.TryGetComponent(out objectGrab))
            {
                instructionGrabText.SetActive(true);

            }
            //If not aimed at the fuse/spark plug, don't enable instructions
            else
            {
                instructionGrabText.SetActive(false);
            }
            //If you are holding the fuse/spark plug and hover over said object, do not enable instructions
            if (objectGrabbed == true)
            {
                instructionGrabText.SetActive(false);
            }
        }
    }

    public void StartCast()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpPlaceDistance, pickUpLayerMask))
            {
                //Pick up the fuse/spark plug if you aren't doing so already
                //Enable the "place" instructions
                if (raycastHit.transform.TryGetComponent(out objectGrab) && objectGrabbed == false)
                {
                    objectGrab.Grab();
                    objectGrabbed = true;

                    instructionPlaceText.SetActive(true);

                    return;
                }

                //Place first fuse/spark plug if it's grabbed and you are clicking the correct power box
                //Disable the "place" instructions
                //Enable fuse/spark plug 2
                if (raycastHit.transform.TryGetComponent(out objectPlace1) && (objectGrabbed == true) && (objectNowPlaced1 == false))
                {
                    objectPlace1.Place1();
                    objectGrabbed = false;

                    Fuse2.SetActive(true);

                    instructionPlaceText.SetActive(false);

                    objectNowPlaced1 = true;

                    return;
                }

                //Place secound fuse/spark plug if it is grabbed, you are clicking the correct power box and you've already placed the first fuse/spark plug
                //Disable the "place" instructions
                //Enable "bothPlaced" to help end the game
                if (raycastHit.transform.TryGetComponent(out objectPlace2) && (objectGrabbed == true) && (objectNowPlaced1 == true))
                {
                    objectPlace2.Place2();
                    objectGrabbed = false;

                    bothPlaced = true;

                    instructionPlaceText.SetActive(false);
                }


                //If you click the door and placed both fuses, end game
                if (raycastHit.transform.TryGetComponent(out endGame) && (bothPlaced == true))
                {
                    endGame.EndGameScene();
                }
            }
        }
    }
}
