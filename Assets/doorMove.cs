using System.Runtime.Serialization.Formatters;
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
            float step = 8 * Time.deltaTime;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, TargetState.Target, step);
        }
    }

    public bool IsLocked()
    {
        var currentRoom = GetComponentInParent<room>();
        return currentRoom.HasEnemy();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (IsLocked())
        {
            return;
        }

        
        var p = GetComponentInParent<room>();

        if (p.name == "D3" && gameObject.name == "right_door")
        {
            var g = FindObjectOfType<Game>();
            if (!g.IsHaveKey)
            {
                g.DialogOkShow("Эта дверь закрыта", "Ок");
                return;
            }

            if (!g.D3OpenMessage)
            {
                g.DialogOkShow("Дверь удаётся открыть ключём", "Ок");
                g.D3OpenMessage = true;
                return;
            }
        }
        
        
        TargetState.Target = nextRoom.transform.position - new Vector3(0, 0, 1);
        TargetState.IsInited = true;
        var room = nextRoom.GetComponent<room>();
        var character = camera.GetComponentInChildren<character>();
        room.EnterRoom(character);

//        FindObjectOfType<Game>().DialogOkShow("Changed text", "button");

    }
}