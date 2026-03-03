using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    //Referencias
    private InputManager inputActions;
    private PlayerAiming playerAiming;//Componente que gestiona la dirección de la mira

    [SerializeField] private Transform bulletPrefab;//Referencia al prefab del proyectil que se instanciará al disparar

    [SerializeField] private float _fireRate = 1f;//Valor que establece el número de balas que se pueden disparar por segundo.
    private bool gunLoaded = true;//flag que determina si nuestra arma está cargada y disponible para disparar
    private float bulletTime = 3f;

    //_powerShotEnabled determinará si el proyectil instanciado es un powerShot o no .Inicialmente se instanciarán proyectiles normales.
    //Esta variable se establece a true cuando el Player colisiona con un PowerUp de tipo PowerShot.
    private bool _powerShotEnabled = false;//Por defecto no tenemos powerShot

    //PROPIEDADES DE ACCESO A CAMPOS PRIVADOS
    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }

    public bool PowerShotEnabled { get => _powerShotEnabled; set => _powerShotEnabled = value; }

    private void Awake()
    {
        inputActions=new InputManager();
        playerAiming = GetComponent<PlayerAiming>();
    }

    private void OnEnable()
    {
        inputActions.Player.PrimaryClick.performed += OnShoot;
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.PrimaryClick.performed -= OnShoot;
        inputActions.Player.Disable();
    }


    private void ShootBullet()
    {
       
        //Cuando disparamos, imposibilitamos un nuevo disparo hasta que el arma vuelva a recargarse
        //para que el player pueda emitir disparos según la cadencia de tiro configurada.
        gunLoaded = false;
        //Si utilizamos el pool esto ya no hace falta---------------------
        // Cálculo del ángulo entre el eje x (movimiento del proyectil hacia la derecha) y el vector que marca la dirección
        //hacia donde se apunta la mira. Obtenemos el ángulo en radianes y lo pasamos a grados.
        float angle = Mathf.Atan2(playerAiming.FacingDirection.y, playerAiming.FacingDirection.x) * Mathf.Rad2Deg;
        //conversión del álgulo obtenido en Quateriones.
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Disparo instanciando un proyectil directamente
        //Debemos mantener la referencia al proyectil instanciado para poder gestionar si es o no un PowerShot.
        //Transform bulletClone = Instantiate(bulletPrefab, transform.position, targetRotation);
        //--------------------------------------------------------

        //Disparo utilizando un pool de proyectiles
        ObjectPoolBehaviour bulletClone=PoolManager.Instance.GetFromPool(PoolObjectType.Bullet);
        bulletClone.transform.position = transform.position;
        bulletClone.transform.rotation=targetRotation;

        if (PowerShotEnabled)
        {
            bulletClone.GetComponent<Bullet>().PowerShot = true;
            _powerShotEnabled = false;//Sólo se dispara un powerShot.
        }

        //Recargamos el arma para que pueda volver a ser disparada.
        StartCoroutine(ReloadGun());
        StartCoroutine(DestroyBullet(bulletClone));//Gestión de proyectiles mediante un pool
      
    }
    //Esta corutina devuelve el proyectil al pool transcurridos unos segundos
    //Es necesaria si se gestionan los proyectiles mediante un pool
    IEnumerator DestroyBullet(ObjectPoolBehaviour bulletClone)
    {
        yield return new WaitForSeconds(bulletTime);
        PoolManager.Instance.ReturnToPool(bulletClone);
    }

    //Método que se ejecuta al hacer click con el ratón y que requiere suscripción al performed de la acción correspondiente.
    void OnShoot(InputAction.CallbackContext context)
    {
        if (gunLoaded)//Sólo disparamos si el arma está cargada
        {
            ShootBullet();
        }
    }
    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / _fireRate);//Esperamos un tiempo determinado por la ratio de disparo antes de volver a cargar el arma
        gunLoaded = true;
    }
}
