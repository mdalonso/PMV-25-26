using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Editor;

public class GatherInput : MonoBehaviour
{
    //InputManager es el tipo definido por la clase generada a partir del objeto Input Action
    private InputManager inputActions;
    //valor que debemos obtener. Lo serializamos para poder verlo en el inspector y comprobar que efectivamente estamos leyendo correctamente la entrada
    [SerializeField] private Vector2 _movimiento;
    //Reto 2*********************
    private Vector2 _mousePosition;
    private bool _primaryPressed;
    private bool _secondaryPressed;
    private Vector2 _scrollValue;

    //Necesitamos acceder publicamente al los campos privados
    public Vector2 Movimiento { get => _movimiento;}
    public Vector2 MousePosition { get => _mousePosition;}
    public bool PrimaryPressed { get => _primaryPressed;}

    private void Awake()
    {
        //Inicialización del objeto InputManager
        inputActions = new InputManager();
    }

    private void OnEnable()
    {
        //Al activar el objeto debemos suscribir los métodos creados para gestionar el movimiento
        //Lectura de la entrada de teclado.
        inputActions.Player.Move.performed += StartMove;//Método que inicia el movimiento
        inputActions.Player.Move.canceled += EndMove;//Método que termina el movimiento (Acción cancelada) para que deje de moverse al soltar la tecla

        //Lectura de la entrada del ratón
        inputActions.Player.MousePosition.performed += OnMouseMove;
        inputActions.Player.PrimaryClick.performed += OnPrymaryPress;
        inputActions.Player.SecondaryClick.performed += OnSecondaryPress;
        inputActions.Player.Scroll.performed += OnScroll;


        inputActions.Player.Enable();//Se activa el Action Map que necesitamos


    }
    private void OnDisable()
    {
        //Al desactivar el objeto cancelamos la suscripción
        inputActions.Player.Move.performed -= StartMove;
        inputActions.Player.Move.canceled -= EndMove;

        inputActions.Player.MousePosition.performed -= OnMouseMove;
        inputActions.Player.PrimaryClick.performed -= OnPrymaryPress;
        inputActions.Player.Scroll.performed -= OnScroll;
        


        inputActions.Player.Disable();//Deshabilitamos el Action Map
    }

    void StartMove(InputAction.CallbackContext context)
    {
        //Recuperación del valor Vector2 que necesitamos para el movimiento
        _movimiento=context.ReadValue<Vector2>();
    }

    void EndMove(InputAction.CallbackContext context) 
    {
        //Para que deje de moverse, el vector debe ser Zero
        _movimiento=Vector2.zero;
    }

    private void OnMouseMove(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }

    private void OnPrymaryPress(InputAction.CallbackContext context)
    {
        _primaryPressed = true;
       // Debug.Log("Se ha pulsado el botón izquierdo del ratón");
    }
    

    private void OnSecondaryPress(InputAction.CallbackContext context)
    {
        _secondaryPressed = true;
        Debug.Log("Se ha pulsado el botón derecho del ratón");
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        _scrollValue = context.ReadValue<Vector2>();
        Debug.Log($"Desplazamiento de Scroll: {_scrollValue}");
    }
}
