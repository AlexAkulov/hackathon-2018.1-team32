using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public int Health;
    public int Damage;
	// Use this for initialization
	void Start ()
	{
	    Health = Consts.BaseHerowHelth;
	    Damage = Consts.BaseHerowDamage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
            TargetState.IsInited = false;
        }
    }

    public void Fight(IEnemy enemy)
    {
        print("Enemy was hitted wiht "  + Damage + "dmg");
        //enemy.Hit(Damage);
    }
}
