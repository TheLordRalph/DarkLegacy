using Assets.Scripts.Monobehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private AnimatorOverride animatorOverride;

    // Start is called before the first frame update
    void Start()
    {
        changeAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeAnimation() 
    {
        switch (this.name)
        {
            case "Body":
                if (!player.characterDefault.body.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.body_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Pelo":
                if (!player.characterDefault.hair.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.pelo_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case "Cabeza":
                if (!player.characterDefault.cabeza.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.cabeza_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Pecho":
                if (!player.characterDefault.pecho.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.pecho_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Hombreras":
                if (!player.characterDefault.hombreras.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.hombreras_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Guantes":
                if (!player.characterDefault.guantes.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.guantes_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Piernas":
                if (!player.characterDefault.piernas.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.piernas_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Botas":
                if (!player.characterDefault.botas.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.botas_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "AccesorioPiernas":
                if (!player.characterDefault.accesorioPiernas.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.accesorioPiernas_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "AccesorioPecho1":
                if (!player.characterDefault.accesorioPecho1.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.accesorioPecho1_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "AccesorioPecho2":
                if (!player.characterDefault.accesorioPecho2.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.accesorioPecho2_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Arma":
                if (!player.characterDefault.arma.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.arma_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case "Escudo":
                if (!player.characterDefault.escudo.Equals("Null"))
                {
                    this.gameObject.SetActive(true);
                    animatorOverride.SetAnimations(player.characterDefault.escudo_controler);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
}
