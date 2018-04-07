using UnityEngine;
using UnityEngine.EventSystems;

public static class TargetState
{
    static TargetState()
    {
        IsInited = false;
    }

    public static bool IsInited { get; set; }
    public static Vector3 Target { get; set; }
}

public class doorMove : MonoBehaviour, IPointerClickHandler
{
    public new GameObject camera;
    public GameObject nextRoom;

    // Use this for initialization
    public void Start ()
    {
    }
    
    // Update is called once per frame
    public void Update ()
    {
        if (TargetState.IsInited)
        {
<<<<<<< HEAD
            float step = 8 * Time.deltaTime;
=======
            float step = 2 * Time.deltaTime;
>>>>>>> c13e8ff4b306824761d4d593181847f343b843d9
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, TargetState.Target, step);

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TargetState.Target = nextRoom.transform.position - new Vector3(0, 0, 1);
        TargetState.IsInited = true;
<<<<<<< HEAD
=======

>>>>>>> c13e8ff4b306824761d4d593181847f343b843d9
        var room = nextRoom.GetComponent<room>();
        room.EnterRoom();
    }
}