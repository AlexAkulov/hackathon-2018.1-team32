using UnityEngine;
using UnityEngine.EventSystems;

public class doorMove : MonoBehaviour, IPointerClickHandler
{
    public new GameObject camera;
    public GameObject nextRoom;
    private  int speed = 10;


    private static readonly Vector3 fakePosition = new Vector3(-2000, -2000, -2000);
    private Vector3 position = fakePosition;


    private int i = 0;
    // Use this for initialization
    void Start ()
    {
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (position != fakePosition)
        {
            //print ("123");
            // if (i++ % 10000 == 0)
            // {
            //     print("321");
            //     // print(camera.transform.position);
            // }

            float step = speed * Time.deltaTime;
            camera.transform.position += new Vector3(step, 0f, -1);
            // camera.transform.position = Vector3.MoveTowards(camera.transform.position, position, step);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var transformPosition = nextRoom.transform.position - new Vector3(0, 0, 1);
        position = transformPosition;
        //print(position);
        //camera.transform.position = transformPosition;
        //hero.transform.position = nextRoom.transform.position;

        var room = nextRoom.GetComponent<room>();
        room.EnterRoom();
    }
}