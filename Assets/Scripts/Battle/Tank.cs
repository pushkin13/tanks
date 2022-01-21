using UnityEngine;
using System;

public class Tank : BattleUnit
{    public delegate void ChangeHP(int newHP);    public static event ChangeHP OnChangeHP;

    [SerializeField]
    private TankCannon[] cannons;

    private DateTime lastBullet = DateTime.MinValue;
    private TankInfo tankInfo;
    private int currentCannon;

    private float minX;
    private float maxX;
    private float maxZ;
    private float minZ;

    public void Init(TankInfo tankInfo, Vector3 sizeLevel)    {        this.tankInfo = tankInfo;        base.Init(tankInfo.Kind, tankInfo.HP, tankInfo.Defence, 0, tankInfo.Speed);        minX = - sizeLevel.x / 2;        maxX = sizeLevel.x / 2;        minZ = -sizeLevel.z / 2;        maxZ = sizeLevel.z / 2;        currentCannon = 0;        RefreshCannonView();    }    private void RefreshCannonView()	{        for (var i=0; i< tankInfo.Cannons.Length; i++)		{            cannons[i].gameObject.SetActive(i == currentCannon);		}	}    public void ChangeCannon(int newCannon)	{        currentCannon = newCannon;        RefreshCannonView();	}    private CannonInfo CurrentCannon => tankInfo.Cannons[currentCannon];    public override int GetAttack()	{        return CurrentCannon.Attack;	}    private void OnCollisionEnter(Collision collision)    {        var monster = collision.gameObject.GetComponent<Monster>();        if (monster != null)		{            GetDamage(monster.GetAttack());		}    }	public override void GetDamage(int damage)	{		base.GetDamage(damage);        OnChangeHP?.Invoke(currentHP);	}	public void Move(bool forward)	{        var diffMove = new Vector3(0.0f, 0f, Speed);        if (!forward)		{            diffMove = new Vector3(0.0f, 0f, -Speed);        }        var newPos = transform.localPosition + transform.localRotation * diffMove;        if (newPos.x < minX || newPos.x > maxX || newPos.z < minZ || newPos.z > maxZ)            return;        transform.localPosition = newPos;    }    public void Rotate(bool right)	{        var diffAngle = new Vector3(0.0f, -1f, 0f);        if (right)		{            diffAngle = new Vector3(0.0f, 1f, 0f);        }        transform.localEulerAngles += diffAngle;    }    public void Fire()	{        var now = DateTime.Now;        if (now > lastBullet.AddSeconds(CurrentCannon.TimeRecharge))        {            lastBullet = now;            var bullet = Bullet.Instantiate(cannons[currentCannon].BulletPrefab,transform.parent, false);            bullet.Init(GetAttack(), CurrentCannon.Speed);            bullet.transform.localPosition = transform.localPosition;            bullet.transform.localRotation = transform.localRotation;            Destroy(bullet.gameObject, 2f);        }    }

}
