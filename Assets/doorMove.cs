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
    public GameObject camera;
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
        var locked = currentRoom.HasEnemy();
        
        if (locked)
        {
//            FindObjectOfType<Game>().FightLabel.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
            FindObjectOfType<Game>().FightLabel.transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
//            FindObjectOfType<Game>().FightLabel.transform.position = new Vector3(-300, -500, 0);
            FindObjectOfType<Game>().FightLabel.transform.localScale = new Vector3(0, 0, 0);
        }

        return locked;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (IsLocked())
        {
            var g = FindObjectOfType<Game>();
            g.DialogOkShow("Вы не можете покинуть эту комнату во время боя", "Ок");
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
                g.DialogOkShow("Ключ подходит к двери", "Ок");
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