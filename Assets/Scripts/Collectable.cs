using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
	private int cherries = 0;
	[SerializeField] private TMP_Text cherriesText;
	private void OnTriggerEnter2D(Collider2D collision)
	{
	if (collision.gameObject.CompareTag("Collectable"))
		{
			Destroy(collision.gameObject);
			cherries++;
			cherriesText.text = " Cherries: " + cherries;
		}
	}


}
