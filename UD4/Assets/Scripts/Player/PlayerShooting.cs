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
    
    //PROPIEDADES DE ACCESO A CAMPOS PRIVADOS
    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }
    
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

        // Cálculo del ángulo entre el eje x (movimiento del proyectil hacia la derecha) y el vector que marca la dirección
        //hacia donde se apunta la mira. Obtenemos el ángulo en radianes y lo pasamos a grados.
        float angle = Mathf.Atan2(playerAiming.FacingDirection.y, playerAiming.FacingDirection.x) * Mathf.Rad2Deg;
        //conversión del álgulo obtenido en Quateriones.
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Debemos mantener la referencia al proyectil instanciado para poder gestionar si es o no un PowerShot.
        Transform bulletClone = Instantiate(bulletPrefab, transform.position, targetRotation);

        //Recargamos el arma para que pueda volver a ser disparada.
        StartCoroutine(ReloadGun());
      
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
