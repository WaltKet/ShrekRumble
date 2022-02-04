using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool IsForPlayer
    {
        get
        {
            return isForPlayer;
        }
        set
        {
            isForPlayer = value;
        }
    }
    public bool ShootsLaser
    {
        get
        {
            return shootsLaser;
        }
        set
        {
            shootsLaser = value;
        }
    }
    public string FireButton
    {
        get
        {
            return fireButton;
        }
        set
        {
            fireButton = value;
        }
    }
    public string ReloadButton
    {
        get
        {
            return reloadButton;
        }
        set
        {
            reloadButton = value;
        }
    }
    public int AmmoCapacity
    {
        get
        {
            return ammoCapacity;
        }
        set
        {
            ammoCapacity = value;
        }
    }
    public int ReserveAmmoCapacity
    {
        get
        {
            return reserveAmmoCapacity;
        }
        set
        {
            reserveAmmoCapacity = value;
        }
    }
    public int MaxAmmoCapacity
    {
        get
        {
            return maxAmmoCapacity;
        }
        set
        {
            maxAmmoCapacity = value;
        }
    }
    public float FireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }
    public bool Reloads
    {
        get
        {
            return reloads;
        }
        set
        {
            reloads = value;
        }
    }
    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
        set
        {
            reloadTime = value;
        }
    }
    public int ProjectilesPerShoot
    {
        get
        {
            return projectilesPerShoot;
        }
        set
        {
            projectilesPerShoot = value;
        }
    }
    public float AngleBetweenProjectiles
    {
        get
        {
            return angleBetweenProjectiles;
        }
        set
        {
            angleBetweenProjectiles = value;
        }
    }
    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
        set
        {
            audioSource = value;
        }
    }
    public AudioClip ShootSound
    {
        get
        {
            return shootSound;
        }
        set
        {
            shootSound = value;
        }
    }
    public AudioClip ReloadSound
    {
        get
        {
            return reloadSound;
        }
        set
        {
            reloadSound = value;
        }
    }
    public GameObject Projectile
    {
        get
        {
            return projectile;
        }
        set
        {
            projectile = value;
        }
    }
    public List<GameObject> GunBarrels
    {
        get
        {
            return gunBarrels;
        }
        set
        {
            gunBarrels = value;
        }
    }

    ///<summary>
    ///Determina si el arma ser� utilizada por el jugador o por NPCs.
    ///</summary>
    [SerializeField]
    private bool isForPlayer;
    ///<summary>
    ///Determina si el arma dispara l�ser, si el proyectil se alejara del arma despu�s de ser disparado o no, 
    ///si el arma dispara lasers est� solo instancian Projectiles Per Shoot proyectiles por disparo, 
    ///en lugar de seguir instanciando proyectiles mientras se siga disparando el arma.
    ///</summary>
    [SerializeField]
    private bool shootsLaser;
    ///<summary>
    ///Es el nombre del bot�n que har� que el arma dispare.
    ///</summary>
    [SerializeField]
    private string fireButton;
    ///<summary>
    ///Es el nombre del bot�n que har� que el arma recargue.
    ///</summary>
    [SerializeField]
    private string reloadButton;
    ///<summary>
    ///Determina cu�ntos proyectiles puede disparar el arma antes de tener que recargar.
    ///</summary>
    [SerializeField]
    private int ammoCapacity;
    ///<summary>
    ///Determina cu�nta munici�n tiene el arma en reserva, esta es la munici�n que se gasta al recargar.
    ///</summary>
    [SerializeField]
    private int reserveAmmoCapacity;
    ///<summary>
    ///Determina cu�nta munici�n puede tener en total el arma.
    ///</summary>
    [SerializeField]
    private int maxAmmoCapacity;
    ///<summary>
    ///Determina qu� tan r�pido dispara el arma.
    ///</summary>
    [SerializeField]
    private float fireRate;
    ///<summary>
    ///Ddetermina si el arma necesita recargar.
    ///</summary>
    [SerializeField]
    private bool reloads;
    ///<summary>
    ///Determina cu�nto se tarda en recargar el arma.
    ///</summary>
    [SerializeField]
    private float reloadTime;
    ///<summary>
    ///Determina cu�ntos proyectiles son instanciados cada vez que el arma es disparada.
    ///</summary>
    [SerializeField]
    private int projectilesPerShoot;
    ///<summary>
    ///Determina el �ngulo que debe de haber entre cada proyectil disparado por la misma arma, al mismo tiempo, 
    ///esta variable est� pensada para armas que instancian m�s de un proyectil por disparo.
    ///</summary>
    [SerializeField]
    private float angleBetweenProjectiles;
    ///<summary>
    ///El AudioSource del objeto.
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;
    ///<summary>
    ///Este es un AudioClip que es reproducido cada vez que el arma dispara.
    ///</summary>
    [SerializeField]
    private AudioClip shootSound;
    ///<summary>
    ///Este es un AudioClip que es reproducido cada vez que el arma es recargada.
    ///</summary>
    [SerializeField]
    private AudioClip reloadSound;
    ///<summary>
    ///Este es el GameObject que ser� instalado cada vez que el arma dispare.
    ///</summary>
    [SerializeField]
    private GameObject projectile;
    ///<summary>
    ///Esta es una lista de GameObjects los cuales se utilizan para determinar en qu� posici�n se instancian 
    ///los proyectiles del arma y su rotaci�n se utiliza como base de los �ngulos entre proyectiles.
    ///</summary>
    [SerializeField]
    private List<GameObject> gunBarrels = new List<GameObject>();

    ///<summary>
    ///El valor original de ammoCapacity. 
    ///</summary>
    private int startAmmo;
    ///<summary>
    ///Indica si el arma esta siendo recargada.
    ///</summary>
    private bool reloading = false;
    ///<summary>
    ///Indica si se esta disparando el arma.
    ///</summary>
    private bool shooting = false;
    ///<summary>
    ///Indica si el arma esta siendo disparada por un NPC.
    ///</summary>
    private bool npcShooting;
    ///<summary>
    ///Indica si el arma esta siendo recargada por un NPC.
    ///</summary>
    private bool npcReloading;
    ///<summary>
    ///Es la lista de todos los lacers que el arma instancio.
    ///</summary>
    private List<GameObject> lasersObjects = new List<GameObject>();

    ///<summary>
    ///Inisializa variables.
    ///</summary>
    private void Start()
    {
        startAmmo = ammoCapacity;
    }
    ///<summary>
    ///Llama a la funcion que dispara el arma, vacia lasersObjects y Llama la funcion que recarga el arma.
    ///</summary>
    private void Update()
    {
        if (((isForPlayer && Input.GetButton(fireButton)) || (!isForPlayer && npcShooting)) && !reloading && !shooting && ammoCapacity > 0)
        {
            StartCoroutine(Shoot());
        }
        if ((isForPlayer && Input.GetButtonUp(fireButton) || (!isForPlayer && !npcShooting)) )
        {
            lasersObjects.Clear();
        }
        if (reloads && ((isForPlayer && Input.GetButtonDown(reloadButton)) || (!isForPlayer && npcReloading)) && reloads && !reloading)
        {
            StartCoroutine(Reload());
        }
    }
    ///<summary>
    ///Dispara el arma por una cantidad de tiempo dada por npcShootingTime.
    ///</summary>
    ///<param name="npcShootingTime">
    ///El tiempo por el que se disparar el arma.
    ///</param>
    public void NpcShoot(float npcShootingTime)
    {
        if (!npcShooting)
        {
            npcShooting = true;
            StartCoroutine(npcContinousShooting(npcShootingTime));
        }
    }
    ///<summary>
    ///Hace que el arma deje de disparar.
    ///</summary>
    public void StopNpcShooting()
    {
        npcShooting = false;
    }
    ///<summary>
    ///Recarga el arma.
    ///</summary>
    public void NpcReload()
    {
        npcReloading = true;
    }
    ///<summary>
    ///Regresa una variable BOOLEANA que indica si el arma est� disparando o no.
    ///</summary>
    ///<return>
    ///Regresa true si el arma esta disparando.
    ///</return>
    public bool GetShooting()
    {
        return shooting;
    }
    ///<summary>
    ///Regresa una lista de GameObjects de todos los l�ser actuales que el arma instancio.
    ///</summary>
    ///<return>
    ///Regresa una lista de GameObjects de todos los l�ser actuales que el arma instancio.
    ///</return>
    public List<GameObject> GetLaserObjects()
    {
        return lasersObjects;
    }
    ///<summary>
    ///Suma ammo a la munici�n de reserva del arma.
    ///</summary>
    ///<param name="ammo">
    ///La cantidad de municion que se le desea agregar al arma.
    ///</param>
    public void AddToReserveAmmoCapacity(int ammo)
    {
        if(ammoCapacity + ammo > maxAmmoCapacity)
        {
            ammoCapacity = maxAmmoCapacity;
        }
        else
        {
            ammoCapacity += ammo;
        }
    }
    ///<summary>
    ///Dispara el proyectil del arma.
    ///</summary>
    private IEnumerator Shoot()
    {
        shooting = true;
        if (shootSound)
        {
            audioSource.PlayOneShot(shootSound);
        }
        if (reloads)
        {
            ammoCapacity--;
        }
        for (int i = 0; i < gunBarrels.Count; i++)
        {
            float tmpAngle = 0;
            if (!shootsLaser)
            {
                for (int j = 0; j < projectilesPerShoot; j++)
                {
                    tmpAngle += angleBetweenProjectiles;
                    Instantiate(projectile, gunBarrels[i].transform.position, Quaternion.Euler(0, 0, gunBarrels[i].transform.rotation.eulerAngles.z + tmpAngle));
                }
            }
            else if(lasersObjects.Count < gunBarrels.Count)
            {
                tmpAngle += angleBetweenProjectiles;
                GameObject tmpObject = Instantiate(projectile, gunBarrels[i].transform.position, Quaternion.Euler(0, 0, gunBarrels[i].transform.rotation.eulerAngles.z + tmpAngle));
                tmpObject.transform.SetParent(gunBarrels[i].transform);
                lasersObjects.Add(tmpObject);
            }
        }   
        yield return new WaitForSeconds(fireRate);
        shooting = false;
    }
    ///<summary>
    ///Recarga el arma.
    ///</summary>
    private IEnumerator Reload()
    {
        reloading = true;
        if (reloadSound)
        {
            audioSource.PlayOneShot(reloadSound);
        }
        yield return new WaitForSeconds(reloadTime);
        int ammoDiference = startAmmo - ammoCapacity;
        if(ammoDiference <= reserveAmmoCapacity)
        {
            reserveAmmoCapacity -= ammoDiference;
            ammoCapacity += ammoDiference;
        }
        else
        {
            ammoCapacity += reserveAmmoCapacity;
            reserveAmmoCapacity = 0;
        }
        reloading = false;
        npcReloading = false;
    }
    ///<summary>
    ///Hace que el arma pare de disparar despuesde un sierto tiempo si un NPC la disparo. 
    ///</summary>
    private IEnumerator npcContinousShooting(float npcShootingTime)
    {
        yield return new WaitForSeconds(npcShootingTime);
        npcShooting = false;
    }
}
