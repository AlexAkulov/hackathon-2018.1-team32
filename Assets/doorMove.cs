using UnityEngine;
using UnityEngine.EventSystems;

public class doorMove : MonoBehaviour, IPointerClickHandler
{
    public GameObject camera;
    public GameObject nextRoom;
    public GameObject hero;

    public static int offsetX = 60;
    public static int offsetY = 31;
    private Renderer renderer;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider2D;

    // Use this for initialization
	void Start ()
	{
	    renderer = GetComponent<Renderer>();
	    rigidbody = GetComponent<Rigidbody2D>();
	    boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {


        
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        var transformPosition = nextRoom.transform.position - new Vector3(0, 0, 1);
        camera.transform.position = transformPosition;
        //hero.transform.position = nextRoom.transform.position;

        var room = nextRoom.GetComponent<room>();
        room.EnterRoom();

        Debug.Log("AHDKFLJDSKLF:HJH:SDLKJHFLKSJDHFKJDSHF");

    }
}
