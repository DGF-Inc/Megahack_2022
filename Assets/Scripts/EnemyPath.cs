using UnityEngine;

public class EnemyPath : MonoBehaviour
{
	[SerializeField] private Shop shop;

	private void OnMouseEnter()
	{
		shop.setEnabled(false);
	}

	private void OnMouseExit()
	{
		shop.setEnabled(true);
	}
}
	