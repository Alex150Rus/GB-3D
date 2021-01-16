using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _ballsAmmoQty;
    [SerializeField] private int _minesQty;

    public int BallsAmmoQty
    {
        get { return _ballsAmmoQty; }
        set { _ballsAmmoQty = value; }
    }

    public int MinesQty
    {
        get { return _minesQty; }
        set { _minesQty = value; }
    }
}
