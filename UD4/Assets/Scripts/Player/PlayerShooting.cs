using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private InputManager inputActions;
    private PlayerAiming playerAiming;//Componente que gestiona la dirección de la mira

    [SerializeField] private Transform bulletPrefab;

    [SerializeField] private float _fireRate = 1f;
    private bool gunLoaded = true;
    
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

    void OnShoot(InputAction.CallbackContext context)
    {
        if (gunLoaded)
        {
            ShootBullet();

        }
    }
    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / _fireRate);
        gunLoaded = true;
    }
}
