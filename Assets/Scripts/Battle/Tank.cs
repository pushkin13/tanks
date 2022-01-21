using UnityEngine;
using System;

public class Tank : BattleUnit
{

    [SerializeField]
    private TankCannon[] cannons;

    private DateTime lastBullet = DateTime.MinValue;
    private TankInfo tankInfo;
    private int currentCannon;

    private float minX;
    private float maxX;
    private float maxZ;
    private float minZ;

    public void Init(TankInfo tankInfo, Vector3 sizeLevel)

}