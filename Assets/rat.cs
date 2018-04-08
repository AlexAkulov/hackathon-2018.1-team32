using UnityEngine;
using UnityEngine.EventSystems;

public static class Consts
{
    public const int BaseHerowHelth = 100;
    public const int BaseHerowDamage = 5;

    public const int RatDamage = 10;
    public const int RatHealth = 10;
}

public interface IEnemy
{
    int Health { get; }
    int Damage { get; }
    void Hit(character hero);
}

public class rat : MonoBehaviour, IEnemy, IPointerClickHandler
{
 
    void Start ()
    {
        Health = Random.Range(5, 20);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(character hero)
    {
        Health -= hero.Damage;
        if (Health <= 0)
        {
            Destroy(gameObject); 
        }

        hero.Hit(Damage);

        print("rat was dmaged with " + hero.Damage + " and returned " + Damage);
    }

    public int Health { get; private set; }
    public int Damage {get { return Random.Range(1, 50); }}


    public void OnPointerClick(PointerEventData eventData)
    {
        var character = FindObjectOfType<character>();
        Hit(character);        
    }
}
