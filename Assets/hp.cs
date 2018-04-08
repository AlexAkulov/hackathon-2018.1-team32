using System.Linq;
using UnityEngine;

public static class HerowHp
{
    public static int startHealth;
    public static float startScale;
    public static int Health { get; set; }
}

public class hp : MonoBehaviour
{
    public int Health {
        get { return HerowHp.Health; }
        set { HerowHp.Health = value; }
    }
    // Use this for initialization
    void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var hpTransform = GameObject.FindWithTag("hero_hp").transform; ;

        print("startHealth: " + HerowHp.startHealth + " StartScale " + HerowHp.startScale + " Health: " + HerowHp.Health);
	    hpTransform.localScale = new Vector3(
            HerowHp.startScale / HerowHp.startHealth * HerowHp.Health,
            hpTransform.gameObject.transform.localScale.y,
            hpTransform.gameObject.transform.localScale.z); 


	}

    public void Init(int startHealth)
    {
        HerowHp.startHealth = startHealth;
        HerowHp.Health = startHealth;
        HerowHp.startScale = GameObject.FindWithTag("hero_hp").transform.localScale.x;
    }
}
