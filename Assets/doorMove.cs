using UnityEngine;
using UnityEngine.EventSystems;

public class doorMove : MonoBehaviour, IPointerClickHandler
{
    public GameObject camera;
    public GameObject nextRoom;

    public static int offsetX = 60;
    public static int offsetY = 31;

    // Use this for initialization
    void Start ()
    {
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print ("123");
        var transformPosition = nextRoom.transform.position - new Vector3(0, 0, 1);
        camera.transform.position = transformPosition;
        //hero.transform.position = nextRoom.transform.position;

        var room = nextRoom.GetComponent<room>();
        room.EnterRoom();

    }
}