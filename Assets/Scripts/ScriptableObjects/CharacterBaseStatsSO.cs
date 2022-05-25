using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CharStats", menuName = "Game/Character/Character Stats SO", order = 1)]
public class CharacterBaseStatsSO : ScriptableObject
{
    #region DurabilityStats

    [SerializeField]
    private float _health = 0;
    public float Health => _health;

    #endregion
    
    #region MovementStats
    
    [SerializeField]
    private float _walkSpeed = 0;
    public float WalkSpeed => _walkSpeed;
    [SerializeField]
    private float _dashSpeed = 0;  
    public float DashSpeed => _dashSpeed;
    [SerializeField]
    private float _dashDuration = 0;
    public float DashDuration => _dashDuration;
    [SerializeField]
    private float _jumpHeight = 0;
    public float JumpHeight => _jumpHeight;
    [SerializeField]
    private int _extraJumps = 0;
    public int ExtraJumps => _extraJumps;
    
    #endregion
    
    
    #region DamageStats
    
    [SerializeField]
    private float _lightAttackDmg = 0;
    public float LightAttackDmg => _lightAttackDmg;
    [SerializeField]
    private float _heavyAttackDmg = 0;
    public float HeavyAttackDmg => _heavyAttackDmg;  
    [SerializeField]
    private float _inAirAttackLightDmg = 0;
    public float InAirAttackLightDmg => _inAirAttackLightDmg;
    [SerializeField]
    private float _inAirHeavyDmg = 0;
    public float InAirHeavyDmg => _inAirHeavyDmg;
    [SerializeField]
    private float _ultimateAttackDmg = 0;
    public float UltimateAttackDmg => _ultimateAttackDmg;
    [SerializeField]
    private float _distanceAttackDmg = 0;
    public float DistanceAttackDmg => _distanceAttackDmg;
    
    #endregion
    
    
    #region AttackStats
    
    [SerializeField]
    private int _maxAttackRange;
    public int MaxAttackRange => _maxAttackRange;
    
    #endregion
    


}

