using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public int Damage;
    private hp healthStatus;
    // Use this for initialization
	void Start ()
	{
	    Damage = Consts.BaseHerowDamage;
        healthStatus = GetComponentInChildren<hp>();
	    healthStatus.Init(Consts.BaseHerowHelth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        healthStatus.Health -= damage;
        if (damage > 0)
        {
            GetComponentInChildren<hp>().GetComponent<Animator>().Play(0);
        }

        if (healthStatus.Health <= 0)
        {
	        var g = FindObjectOfType<Game>();
	        g.DialogOkShow("Вы мертвы", "Ну ок");
	        
	        
            SceneManager.LoadScene(0);
            TargetState.IsInited = false;
        }
    }
    
}
