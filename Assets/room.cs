using UnityEngine;

public class room : MonoBehaviour 
{
    // Use this for initialization
    void Start ()
    {
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    public bool HasEnemy()
    {
        return GetComponentInChildren<rat>() != null;
    }
     
    public void EnterRoom ()
    {
        if (HasEnemy())
        {
            print("Oppps! There is enemy in this room.");
        }
    }
}