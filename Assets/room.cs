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
         return GetEnemy() != null;
    }

    public IEnemy GetEnemy()
    {
        return GetComponentInChildren<rat>();
    }
     
    public void EnterRoom (character character)
    {
        if (HasEnemy())
        {
            print("Oppps! There is enemy in this room.");
            var enemy = GetEnemy();
            character.Fight(enemy);
        }
    }
}