using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    GatherInput _input;
    [SerializeField] private Transform bulletPrefab;

    [SerializeField] private float _fireRate = 5f;
    private bool gunLoaded = true;
    private PlayerAiming playerAiming;
    
    
    //PROPIEDADES DE ACCESO A CAMPOS PRIVADOS
    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }
    
    private void Awake()
    {
        _input=GetComponent<GatherInput>();
        playerAiming = GetComponent<PlayerAiming>();
    }

    private void Update()
    {
        //Pulsación del botón izquierdo del ratón y arma cargada
        if (_input.PrimaryPressed && gunLoaded)
        {
            ShootBullet();
        }
       
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

    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / _fireRate);
        gunLoaded = true;
    }
}
