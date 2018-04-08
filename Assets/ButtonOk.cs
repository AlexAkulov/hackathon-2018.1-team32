using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonOk : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		FindObjectOfType<Game>().DialogOkHide();
	    if (HerowHp.Health <= 0)
	    {
	        SceneManager.LoadScene(0);
	    }
	}
}
