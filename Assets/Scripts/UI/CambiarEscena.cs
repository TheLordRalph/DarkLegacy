using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{

    private int tiempo = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void esperarTiempo(AudioSource tiempo)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(tiempo.time);
    }
    public void cambioEscena(int numeroEscena)
    { 
        SceneManager.LoadScene(numeroEscena);
    }

}
