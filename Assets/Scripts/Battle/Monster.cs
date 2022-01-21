using UnityEngine;

public class Monster : BattleUnit
{
    public void Init(MonsterInfo monsterInfo)	{        base.Init(monsterInfo.Kind, monsterInfo.HP, monsterInfo.Defence, monsterInfo.Attack, monsterInfo.Speed);	}	public override void GetDamage(int damage)	{		base.GetDamage(damage);		if (IsDead())		{			GameObject.Destroy(gameObject);		}	}	public void MoveToPos (Vector3 target)	{        transform.LookAt(target);        var angles = transform.localEulerAngles;        transform.localEulerAngles = new Vector3(0f, angles.y, 0f);        transform.localPosition += transform.localRotation * Vector3.forward * Speed;	}
}
