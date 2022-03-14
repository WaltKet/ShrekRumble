using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacter : MonoBehaviour, IDamageable, IDamager
{
    //Este codigo esta basado en los videos https://www.youtube.com/watch?v=w4YV8s9Wi3w&list=PLLTae1_1NyOOqKBz2WXeqrWRhvD0ttv5L&index=16&t=284s
    //y https://www.youtube.com/watch?v=j111eKN8sJw&t=2s.

    public float LightDmg
    {
        get
        {
            return lightDmg;
        }
        set
        {
            lightDmg = value;
        }
    }
    public GameObject LightAttackObject
    {
        get
        {
            return lightAttackObject;
        }
        set
        {
            lightAttackObject = value;
        }
    }
    public float HeavyDmg
    {
        get
        {
            return heavyDmg;
        }
        set
        {
            heavyDmg = value;
        }
    }
    public GameObject HeavyAttackbject
    {
        get
        {
            return heavyAttackObject;
        }
        set
        {
            heavyAttackObject = value;
        }
    }
    public float AirLightDmg
    {
        get
        {
            return airLightDmg;
        }
        set
        {
            airLightDmg = value;
        }
    }
    public GameObject AirLightAttackObject
    {
        get
        {
            return airLightAttackObject;
        }
        set
        {
            airLightAttackObject = value;
        }
    }
    public float AirHeavyDmg
    {
        get
        {
            return airHeavyDmg;
        }
        set
        {
            airHeavyDmg = value;
        }
    }
    public GameObject AirHeavyAttackObject
    {
        get
        {
            return airHeavyAttackObject;
        }
        set
        {
            airHeavyAttackObject = value;
        }
    }
    public float UltimateDmg
    {
        get
        {
            return ultimateDmg;
        }
        set
        {
            ultimateDmg = value;
        }
    }
    public GameObject UltimateAttackObject
    {
        get
        {
            return ultimateAttackObject;
        }
        set
        {
            ultimateAttackObject = value;
        }
    }
    public float DistanceAttackDmg
    {
        get
        {
            return distanceAttackDmg;
        }
        set
        {
            distanceAttackDmg = value;
        }
    }
    public GameObject DistanceAttackObject
    {
        get
        {
            return distanceAttackObject;
        }
        set
        {
            distanceAttackObject = value;
        }
    }
    public int MaxDistanceAttackObject
    {
        get
        {
            return maxDistanceAttackObject;
        }
        set
        {
            maxDistanceAttackObject = value;
        }
    }
    public GameObject DistanceAttackObjectStartPosition
    {
        get
        {
            return distanceAttackObjectStartPosition;
        }
        set
        {
            value = distanceAttackObjectStartPosition;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public float DashSpeed
    {
        get
        {
            return dashSpeed;
        }
        set
        {
            dashSpeed = value;
        }
    }
    public float DashTime
    {
        get
        {
            return dashTime;
        }
        set
        {
            dashTime = value;
        }
    }
    public float JumpHight
    {
        get
        {
            return jumpHight;
        }
        set
        {
            jumpHight = value;
        }
    }

    public int ExtraJumps
    {
        get
        {
            return extreJumps;
        }
        set
        {
            extreJumps = value;
        }
    }
    public float CheckRadius
    {
        get
        {
            return checkRadius;
        }
        set
        {
            checkRadius = value;
        }
    }
    public bool ActivateDash
    {
        get
        {
            return activateDash;
        }
        set
        {
            activateDash = value;
        }
    }
    public bool UsesForceMovement
    {
        get
        {
            return usesForceMovement;
        }
        set
        {
            usesForceMovement = value;
        }
    }
    public string JumpButton
    {
        get
        {
            return jumpButton;
        }
        set
        {
            jumpButton = value;
        }
    }
    public string DashButton
    {
        get
        {
            return dashButton;
        }
        set
        {
            dashButton = value;
        }
    }
    public Transform FeetPos
    {
        get
        {
            return feetPos;
        }
        set
        {
            feetPos = value;
        }
    }
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
        set
        {
            rb = value;
        }
    }
    public LayerMask Floor
    {
        get
        {
            return floor;
        }
        set
        {
            floor = value;
        }
    }
    public bool Invincible
    {
        set
        {
            invincible = value;
        }
    }

    public float Health => throw new System.NotImplementedException();

    float IDamageable.Health { get =>  health; set => health = value; }

    [SerializeField]
    private float health = 0;
    [SerializeField]
    private float lightDmg = 0;
    [SerializeField]
    private GameObject lightAttackObject;
    [SerializeField]
    private float heavyDmg = 0;
    [SerializeField]
    private GameObject heavyAttackObject;
    [SerializeField]
    private float airLightDmg = 0;
    [SerializeField]
    private GameObject airLightAttackObject;
    [SerializeField]
    private float airHeavyDmg = 0;
    [SerializeField]
    private GameObject airHeavyAttackObject;
    [SerializeField]
    private float ultimateDmg = 0;
    [SerializeField]
    private GameObject ultimateAttackObject;
    [SerializeField]
    private float distanceAttackDmg = 0;
    [SerializeField]
    private GameObject distanceAttackObject;
    [SerializeField]
    private int maxDistanceAttackObject;
    [SerializeField]
    private GameObject distanceAttackObjectStartPosition;

    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float dashSpeed = 0;    
    [SerializeField]
    private float dashTime = 0;
    [SerializeField]
    private float jumpHight = 0;
    [SerializeField]
    private int extreJumps = 0;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private bool activateDash = true;
    [SerializeField]
    private bool usesForceMovement = false;
    [SerializeField]
    private string jumpButton;
    [SerializeField]
    private string dashButton;
    [SerializeField]
    private Transform feetPos;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private LayerMask floor;
    [SerializeField]
    private bool invincible = false;

    [SerializeField]
    private Vector2 moveInput;

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

    List<Collider2D> enemiesToHit = new List<Collider2D>();
    List<Collider2D> enemiesHit = new List<Collider2D>();
    ContactFilter2D contactFilter = new ContactFilter2D();

    protected virtual void Start()
    {
        startingDashTime = dashTime;
        startJumps = extreJumps;
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        if (health > 0)
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
            touchingFloor = Physics2D.OverlapCircle(feetPos.position, checkRadius, floor);
            if (startJumps > 0 || touchingFloor && !attacking)
            {
                rb.velocity += Vector2.up * jumpHight;
                animator.Play("jump");
            }
            if (touchingFloor)
            {
                startJumps = extreJumps;
            }
        }
    }

    public virtual void Dash(InputAction.CallbackContext context)
    {
        if (activateDash)
        {
            if (!dashIsActive && rb.velocity != Vector2.zero && !attacking)
            {
                if (!attacking)
                {
                    animator.Play("dash");
                }
                if (rb.velocity.x < 0)  
                {
                    dashDirection += Vector2.left;
                }
                if (rb.velocity.x > 0)
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
            rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        }
    }

    private void Update()
    {
        if (attacking && CurrentAttackCollider)
        {
            CurrentAttackCollider.gameObject.GetComponent<Collider2D>().OverlapCollider(contactFilter, enemiesToHit);
            DamageEnemiesInCollider(damageValue);
        }

        if (!dashIsActive || attacking) return;
        if (startingDashTime < 0)
        {
            dashIsActive = false;
            startingDashTime = dashTime;
            dashDirection = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
        else if (dashIsActive)
        {
            startingDashTime -= Time.deltaTime;
            rb.velocity = dashDirection * dashSpeed;
        }
    }

    public void SetHealth(float hp)
    {
        health = hp;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Die();
    }

    public void HealDamage(float dmg)
    {
        health += dmg;
    }

    public void DoDamage(IDamageable damageable)
    {
        damageable.TakeDamage(10f);
    }

    private void Die()
    {
        if (health <= 0)
        {
            animator.Play("death");
            EventManager.PlayerDeath(gameObject);
        }
    }

    private void RestoreHealth()
    {
        health = 100;
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
        if (enemiesToHit.Count > 0)
        {
            foreach (Collider2D enemy in enemiesToHit)
            {
                if (!enemiesHit.Contains(enemy))
                {
                    enemy.GetComponent<PlayableCharacter>().TakeDamage(damageValue);
                    enemy.GetComponent<PlayableCharacter>().Hurt();
                    enemiesHit.Add(enemy);
                }
            }
        }
        enemiesToHit.Clear();
    }

    public void Attack(string attackType)
    {
        enemiesHit.Clear();
        switch (attackType)
        {
            case "lightAttack":
                CurrentAttackCollider = LightAttackObject.gameObject.GetComponent<Collider2D>();
                damageValue = LightDmg;
                break;
            case "heavyAttack":
                CurrentAttackCollider = HeavyAttackbject.gameObject.GetComponent<Collider2D>();
                damageValue = heavyDmg;
                break;
            case "ultimateAttack":
                CurrentAttackCollider = UltimateAttackObject.gameObject.GetComponent<Collider2D>();
                damageValue = ultimateDmg;
                break;
            case "distanceAttack":
                if(projectileList.Count < maxDistanceAttackObject)
                {
                    GameObject projectile = Instantiate(distanceAttackObject, distanceAttackObjectStartPosition.transform.position, distanceAttackObjectStartPosition.transform.rotation);
                    projectile.GetComponent<Projectile>().Damage = distanceAttackDmg;
                    projectileList.Add(projectile);
                }
                else
                {
                    foreach(GameObject projectile in projectileList)
                    {
                        if (!projectile.activeSelf)
                        {
                            projectile.transform.position = distanceAttackObjectStartPosition.transform.position;
                            projectile.transform.rotation = distanceAttackObjectStartPosition.transform.rotation;
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
