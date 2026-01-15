using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }
}

