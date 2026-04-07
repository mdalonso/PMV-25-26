using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineCamera vCam;//Referencia a la cámara virtual (se inicializan por código en el Awake)
    CinemachineBasicMultiChannelPerlin noise;//Referencia al parámetro NOISE de la cámara Virtual.(se inicializan en el Awake)

    private void Awake()
    {
        //Inicialización de las referencias
        //La referencia a la cámara podría realizarse desde el inspector pero por uniformidad con las referencias relacionada
        //con el mismo objetivo, ambas se inicializan desde código.
        vCam = GetComponent<CinemachineCamera>();
        noise = vCam.GetComponent<CinemachineBasicMultiChannelPerlin>();

    }

    //SHAKE--> método que sacude la cámara aplicándole unos parámetros de ruido
    public void Shake(float duration = 0.1f, float amplitude = 1.5f, float frequency = 20)
    {
        //Detenemos la corrutina de aplicar ruido para que, en el caso de que el player reciba
        //daño de forma muy seguida, el temblor se detenga antes de aplicar uno nuevo.
        StopAllCoroutines();
        StartCoroutine(ApplyNoiseRoutine(duration, amplitude, frequency));
    }
    //Aplicamos unos parámetros de ruido a la cámara virtual
    IEnumerator ApplyNoiseRoutine(float duration, float amplitude, float frequency)
    {
        //aplicamos unos parámetros de ruido...
        //noise.m_AmplitudeGain = amplitude;
        noise.AmplitudeGain = amplitude;
        //noise.m_FrequencyGain = frequency;
        noise.FrequencyGain = frequency;
        //...durante un tiempo específico...
        yield return new WaitForSeconds(duration);
        //...y después quitamos de nuevo el ruido de la cámara.
        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
    }
}
