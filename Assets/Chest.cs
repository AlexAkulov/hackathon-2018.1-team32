using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPointerClickHandler {

	
	SpriteRenderer m_SpriteRenderer;
	private bool destroyed;
	static float t = 0.0f;
	
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyed)
		{
			t += 3 * Time.deltaTime;
			var a = Mathf.Lerp(1.0f, 0.0f, t);
			m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, a);
			if (a == 0)
			{
				Destroy(gameObject);
				t = 0.0f;
				GetLoot();
			}
		}		
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		destroyed = true;
	}


	void GetLoot()
	{

		var Loot = new string[] {
			string.Format("золото +{0}", UnityEngine.Random.Range(1, 100)),
			string.Format("меч +{0}", UnityEngine.Random.Range(1, 6)),
			string.Format("доспехи +{0}", UnityEngine.Random.Range(1, 6)),
			string.Format("щит +{0}", UnityEngine.Random.Range(1, 6)),
			string.Format("золото +{0}", UnityEngine.Random.Range(10, 100)*10),
			"эликсир здоровья",
			"эликсир маны",
			"кирку (зачем она тут?)", 
			"верблюжее дерьмо", 
			"свиток \"молния\"" };
		FindObjectOfType<Game>().DialogOkShow(string.Format("В сундуке вы находите: {0}", Loot[UnityEngine.Random.Range(0, Loot.Length)]), "забрать");
	} 
}
