using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacter : MonoBehaviour, IDamageableEntity, IDamagerEntity
{
    //Este codigo esta basado en los videos https://www.youtube.com/watch?v=w4YV8s9Wi3w&list=PLLTae1_1NyOOqKBz2WXeqrWRhvD0ttv5L&index=16&t=284s
    //y https://www.youtube.com/watch?v=j111eKN8sJw&t=2s.
    
    public GameObject LightAttackObject => _lightAttackObject;
    public GameObject HeavyAttackObject => _heavyAttackObject;
    public GameObject AirLightAttackObject => _airLightAttackObject;
    public GameObject AirHeavyAttackObject => _airHeavyAttackObject;
    public GameObject UltimateAttackObject => _ultimateAttackObject;
    public GameObject DistanceAttackObject => _distanceAttackObject;
    public int MaxDistanceAttackObject => _maxDistanceAttackObject;
    public GameObject DistanceAttackObjectStartPosition => _distanceAttackObjectStartPosition;
    public float CheckRadius => _checkRadius;
    public bool ActivateDash => _activateDash;
    public bool UsesForceMovement => _usesForceMovement;
    public string JumpButton => _jumpButton;
    public string DashButton => _dashButton;
    public Transform FeetPos => _feetPos;
    public Rigidbody2D Rb => _rb;
    public LayerMask Floor => _floor;
    public bool IsInvincible => _invincible;
    public float Health => _currentHealth;


    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private GameObject _lightAttackObject;
    [SerializeField]
    private GameObject _heavyAttackObject;
    [SerializeField]
    private GameObject _airLightAttackObject;
    [SerializeField]
    private GameObject _airHeavyAttackObject;
    [SerializeField]
    private GameObject _ultimateAttackObject;
    [SerializeField]
    private GameObject _distanceAttackObject;
    [SerializeField]
    private int _maxDistanceAttackObject;
    [SerializeField]
    private GameObject _distanceAttackObjectStartPosition;
    
    [SerializeField]
    private float _checkRadius;
    [SerializeField]
    private bool _activateDash = true;
    [SerializeField]
    private bool _usesForceMovement = false;
    [SerializeField]
    private string _jumpButton;
    [SerializeField]
    private string _dashButton;
    [SerializeField]
    private Transform _feetPos;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private LayerMask _floor;
    [SerializeField]
    private bool _invincible = false;

    [SerializeField]
    private Vector2 moveInput;
    
    [SerializeField]
    private CharacterBaseStatsSO _baseStats;

    private float startingDashTime = 0;
    private float damageValue = 0;
    private int startJumps = 0;
    private bool attacking = false;
    private bool touchingFloor = true;
    private bool dashIsActive = false;
    private Vector2 dashDirection = Vector2.zero;
    private List<GameObject> projectileList = new List<GameObject>();

    private Collider2D CurrentAttackCollider = null;

    protected Animator animator;

    private readonly List<Collider2D> _enemiesToHit = new List<Collider2D>();
    private readonly List<Collider2D> _enemiesHit = new List<Collider2D>();
    private ContactFilter2D _contactFilter = new ContactFilter2D();

    protected virtual void Start()
    {
        startingDashTime = _baseStats.DashDuration;
        startJumps = _baseStats.ExtraJumps;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        EventManager.playerSpawnEvent += RestoreHealth;
    }
    
    public virtual void DoLightAttack(InputAction.CallbackContext context)
    {
        animator.Play("lightAttack");
    }

    public virtual void DoHeavyAttack(InputAction.CallbackContext context)
    {
        animator.Play("heavyAttack");
    }
    public virtual void Hurt()
    {
        if (_currentHealth > 0)
        animator.Play("hurt");
    }
    public virtual void DoUltimateAttack(InputAction.CallbackContext context)
    {
        animator.Play("ultimateAbility");
    }

    public virtual void DoDistanceAttack(InputAction.CallbackContext context)
    {
        animator.Play("specialAbility");
    }

    public virtual void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!attacking)
        {
            animator.Play("run");
        }
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchingFloor = Physics2D.OverlapCircle(_feetPos.position, _checkRadius, _floor);
            if (startJumps > 0 || touchingFloor && !attacking)
            {
                _rb.velocity += Vector2.up * _baseStats.JumpHeight;
                animator.Play("jump");
            }
            if (touchingFloor)
            {
                startJumps = _baseStats.ExtraJumps;
            }
        }
    }

    public virtual void Dash(InputAction.CallbackContext context)
    {
        if (_activateDash)
        {
            if (!dashIsActive && _rb.velocity != Vector2.zero && !attacking)
            {
                if (!attacking)
                {
                    animator.Play("dash");
                }
                if (_rb.velocity.x < 0)  
                {
                    dashDirection += Vector2.left;
                }
                if (_rb.velocity.x > 0)
                {
                    dashDirection += Vector2.right;
                }
                dashIsActive = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!dashIsActive && !attacking)
        {
            _rb.velocity = new Vector2(moveInput.x * _baseStats.WalkSpeed, _rb.velocity.y);
        }
    }

    private void Update()
    {
        if (attacking && CurrentAttackCollider)
        {
            CurrentAttackCollider.gameObject.GetComponent<Collider2D>().OverlapCollider(_contactFilter, _enemiesToHit);
            DamageEnemiesInCollider(damageValue);
        }

        if (!dashIsActive || attacking) return;
        if (startingDashTime < 0)
        {
            dashIsActive = false;
            startingDashTime = _baseStats.DashDuration;
            dashDirection = Vector2.zero;
            _rb.velocity = Vector2.zero;
        }
        else if (dashIsActive)
        {
            startingDashTime -= Time.deltaTime;
            _rb.velocity = dashDirection * _baseStats.DashSpeed;
        }
    }
    

    public void ApplyDamage(float dmg)
    {
        _currentHealth -= dmg;
        Die();
    }

    public void HealDamage(float dmg)
    {
        _currentHealth += dmg;
    }

    public void DoDamage(IDamageableEntity damageableEntity)
    {
        damageableEntity.ApplyDamage(10f);
    }

    private void Die()
    {
        if (_currentHealth <= 0)
        {
            animator.Play("death");
            EventManager.PlayerDeath(gameObject);
        }
    }

    private void RestoreHealth()
    {
        _currentHealth = _baseStats.Health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 && !attacking)
        {
            animator.Play("IdleAnimation");
        }
    }

    private void DamageEnemiesInCollider(float damageValue)
    {
        if (_enemiesToHit.Count > 0)
        {
            foreach (Collider2D enemy in _enemiesToHit)
            {
                if (!_enemiesHit.Contains(enemy))
                {
                    enemy.GetComponent<PlayableCharacter>().ApplyDamage(damageValue);
                    enemy.GetComponent<PlayableCharacter>().Hurt();
                    _enemiesHit.Add(enemy);
                }
            }
        }
        _enemiesToHit.Clear();
    }

    public void Attack(string attackType)
    {
        _enemiesHit.Clear();
        switch (attackType)
        {
            case "lightAttack":
                CurrentAttackCollider = LightAttackObject.gameObject.GetComponent<Collider2D>();
                damageValue = _baseStats.LightAttackDmg;
                break;
            case "heavyAttack":
                CurrentAttackCollider = HeavyAttackObject.gameObject.GetComponent<Collider2D>();
                damageValue = _baseStats.HeavyAttackDmg;
                break;
            case "ultimateAttack":
                CurrentAttackCollider = UltimateAttackObject.gameObject.GetComponent<Collider2D>();
                damageValue = _baseStats.UltimateAttackDmg;
                break;
            case "distanceAttack":
                if(projectileList.Count < _maxDistanceAttackObject)
                {
                    GameObject projectile = Instantiate(_distanceAttackObject, _distanceAttackObjectStartPosition.transform.position, _distanceAttackObjectStartPosition.transform.rotation);
                    projectile.GetComponent<Projectile>().Damage = _baseStats.DistanceAttackDmg;
                    projectileList.Add(projectile);
                }
                else
                {
                    foreach(GameObject projectile in projectileList)
                    {
                        if (!projectile.activeSelf)
                        {
                            projectile.transform.position = _distanceAttackObjectStartPosition.transform.position;
                            projectile.transform.rotation = _distanceAttackObjectStartPosition.transform.rotation;
                            projectile.GetComponent<Projectile>().ReactivateProjectile();
                            break;
                        }
                    }
                }
                break;
        }
        attacking = true;
    }

    public void StopAttack()
    {
        attacking = false;
        damageValue = 0;
        CurrentAttackCollider = null;
    }
}
