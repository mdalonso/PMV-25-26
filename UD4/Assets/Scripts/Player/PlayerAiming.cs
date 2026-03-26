using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    GatherInput _input;//Gestor de la entrada del usuario

    [SerializeField] Transform _aim;//Referencia al objeto Aim.
    Vector2 _facingDirection;

    [SerializeField] SpriteRenderer _renderer;

    public Vector2 FacingDirection { get => _facingDirection;}


    // Update is called once per frame

    private void Awake()
    {
        _input=GetComponent<GatherInput>();
    }
    void Update()
    {
        Aiming();
    }

    void Aiming()
    {
        //Cálculo del vector de dirección del disparo en base a la ubicación de la mira.
        _facingDirection = Camera.main.ScreenToWorldPoint((Vector3)_input.MousePosition) - transform.position;
        //Modificamos la posición del objeto Aim para ubicarlo a una unidad de distancia del Player en la dirección hacia la posición del ratón.
        _aim.position = transform.position + (Vector3)_facingDirection.normalized;

        if (_aim.position.x - transform.position.x < 0) 
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }

    }

}