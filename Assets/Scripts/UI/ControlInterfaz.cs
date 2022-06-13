using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlInterfaz : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private PlayerControl player_GameObject;
    [SerializeField] private GameObject pause;
    [SerializeField] private Text vida;
    [SerializeField] private Image portarit;

    private float vidaActual;


    // Start is called before the first frame update
    void Start()
    {
        portarit.sprite = player.characterDefault.portarit;
        vidaActual = player.characterDefault.vida;
        vida.text = player.characterDefault.vida + " / " + player.characterDefault.vida;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_GameObject.getVida() != vidaActual) 
        {
            vida.text = player_GameObject.getVida() + " / " + player.characterDefault.vida;
            vidaActual = player_GameObject.getVida();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && player_GameObject.getVida() > 0) 
        {
            if (pause.active)
            {
                pause.SetActive(false);
            }
            else 
            {
                pause.SetActive(true);
            }
        }
    }
}
