using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float bulletSpeed;

    public void Init (int damage,
    {
        transform.localPosition += transform.localRotation * Vector3.forward * bulletSpeed;
    }
}