using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerStat
{
    Listen,
    Think,
    Choose,
    Die,
}

public class Player :  Singleton<Player>
{
    public PlayerStat stat;
}
