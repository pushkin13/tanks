using UnityEngine;

public class TankCannon : MonoBehaviour
{
	[SerializeField]
	private Bullet bulletPrefab;

	public Bullet BulletPrefab => bulletPrefab;
}
