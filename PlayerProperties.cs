using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MovementProperties
{
    public float speed;
    [HideInInspector] private float _basicSpeed, _extraSpeed, _speedMultiplier;

    public float basicSpeed
    {
        get { return _basicSpeed; }
        set { _basicSpeed = value; SetSpeed(); }
    }

    public float extraSpeed
    { 
        get { return _extraSpeed; } 
        set { _extraSpeed = value; SetSpeed();} 
    }

    public float speedMultiplier
    {
        get { return _speedMultiplier; }
        set { _speedMultiplier = value; SetSpeed(); }
    }

    public void SetSpeed()
    {
        speed = (_basicSpeed + _extraSpeed) * _speedMultiplier;
    }

    public void Init()
    {
        basicSpeed = 5;
        extraSpeed = 0;
        speedMultiplier = 1;
    }
}

[Serializable]
public class FireProperties
{
    public float fireDelay;

    public GameObject bulletPrefeb;

    [HideInInspector] public List<BulletController> bulletArr;

    public int bulletCount = 50;

    public int bulletNum;

    public int _bulletLevel;
    public int bulletLevel
    {
        get { return _bulletLevel; }
        set 
        { 
            _bulletLevel = value; 
            if(_bulletLevel > 5) _bulletLevel = 5;
            else if(_bulletLevel < 0) _bulletLevel = 0;
            
        }
    }

    [HideInInspector] public float[,] bulletRot = new float[5, 5] { { 0, 0, 0, 0, 0 }, { -3, 3, 0, 0, 0 }, { -5, 0, 5, 0, 0 }, { -7, -2f, 2f, 7, 0 }, { -10, -5, 0, 5, 10 } };

    public Damage damage;

    public float range;

    public float bulletSpeed;

    public void Init()
    {
        bulletNum = 0;
    }
}