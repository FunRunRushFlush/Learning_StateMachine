using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/BaseData" )]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float walkVelocity = 10f;
}
