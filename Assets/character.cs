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
        healthStatus = new hp();
	    healthStatus.Init(Consts.BaseHerowHelth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        healthStatus.Health -= damage;
        if (healthStatus.Health <= 0)
        {
            SceneManager.LoadScene(0);
            TargetState.IsInited = false;
        }
    }
    
}
