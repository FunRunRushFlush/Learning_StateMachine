using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/BaseData" )]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float walkVelocity = 10f;

    [Header("Run State")]
    public float runVelocity = 15f;

    [Header("Backwards State")]
    public float backwardsVelocity = 5f;
}
