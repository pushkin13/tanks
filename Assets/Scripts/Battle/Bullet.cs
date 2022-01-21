using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float bulletSpeed;

    public void Init (int damage,        float bulletSpeed)	{        this.damage = damage;        this.bulletSpeed = bulletSpeed * 0.001f;	}	private void OnCollisionEnter(Collision collision)	{        var monster = collision.gameObject.GetComponent<Monster>();        if (monster != null)		{            monster.GetDamage(damage);            Destroy(gameObject);        }    }	void Update()
    {
        transform.localPosition += transform.localRotation * Vector3.forward * bulletSpeed;
    }
}
