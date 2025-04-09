using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noé_Particles_Animation : MonoBehaviour
{
    public ParticleSystem fuegoNoé;
    bool fuegoActivo;
    public ParticleSystem golpeNoé;
    public ParticleSystem portalNoé;
    bool portalActivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PulsarBoton();
    }

    void PulsarBoton()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (fuegoActivo == false)
            {
                fuegoNoé.gameObject.SetActive(true);
                fuegoActivo = true;
            }
            else
            {
                fuegoNoé.gameObject.SetActive(false);
                fuegoActivo = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Golpear());
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (portalActivo == false)
            {
                portalNoé.gameObject.SetActive(true);
                portalActivo = true;
            }
            else
            {
                portalNoé.gameObject.SetActive(false);
                portalActivo = false;
            }
        }
    }

    private IEnumerator Golpear()
    {
        golpeNoé.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        golpeNoé.gameObject.SetActive(false);
        yield return null;
    }
}
