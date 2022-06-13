using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefault", menuName = "ScriptableObjects/CharacterDefault", order = 2)]
public class CharacterDefault : ScriptableObject
{
    [SerializeField] public string tipoAtaque;
    [SerializeField] public int vida;
    [SerializeField] public int velocidad;
    [SerializeField] public int bonusVelocidadAtaque;
    [SerializeField] public int fuerza;

    [SerializeField] public Sprite portarit;

    public string body;
    public string hair;
    public string cabeza;
    public string pecho;
    public string hombreras;
    public string guantes;
    public string piernas;
    public string botas;
    public string accesorioPiernas;
    public string accesorioPecho1;
    public string accesorioPecho2;
    public string arma;
    public string escudo;

    [SerializeField] public AnimationClip[] Body;
    [SerializeField] public AnimationClip[] Pelo;
    [SerializeField] public AnimationClip[] Cabeza;
    [SerializeField] public AnimationClip[] Pecho;
    [SerializeField] public AnimationClip[] Hombreras;
    [SerializeField] public AnimationClip[] Guantes;
    [SerializeField] public AnimationClip[] Piernas;
    [SerializeField] public AnimationClip[] Botas;
    [SerializeField] public AnimationClip[] AccesorioPiernas;
    [SerializeField] public AnimationClip[] AccesorioPecho1;
    [SerializeField] public AnimationClip[] AccesorioPecho2;
    [SerializeField] public AnimationClip[] Arma;
    [SerializeField] public AnimationClip[] Escudo;


    [SerializeField] public AnimatorOverrideController body_controler;
    [SerializeField] public AnimatorOverrideController pelo_controler;
    [SerializeField] public AnimatorOverrideController cabeza_controler;
    [SerializeField] public AnimatorOverrideController pecho_controler;
    [SerializeField] public AnimatorOverrideController hombreras_controler;
    [SerializeField] public AnimatorOverrideController guantes_controler;
    [SerializeField] public AnimatorOverrideController piernas_controler;
    [SerializeField] public AnimatorOverrideController botas_controler;
    [SerializeField] public AnimatorOverrideController accesorioPiernas_controler;
    [SerializeField] public AnimatorOverrideController accesorioPecho1_controler;
    [SerializeField] public AnimatorOverrideController accesorioPecho2_controler;
    [SerializeField] public AnimatorOverrideController arma_controler;
    [SerializeField] public AnimatorOverrideController escudo_controler;

    public void setBody(string body) { this.body = body; }
    public void setHair(string hair) { this.hair = hair; }
    public void setCabeza(string cabeza) { this.cabeza = cabeza; }
    public void setPecho(string pecho) { this.pecho = pecho; }
    public void setHombreras(string hombreras) { this.hombreras = hombreras; }
    public void setGuantes(string guantes) { this.guantes = guantes; }
    public void setPiernas(string piernas) { this.piernas = piernas; }
    public void setBotas(string botas) { this.botas = botas; }
    public void setAccesorioPiernas(string accesorioPiernas) { this.accesorioPiernas = accesorioPiernas; }
    public void setAccesorioPecho1(string accesorioPecho1) { this.accesorioPecho1 = accesorioPecho1; }
    public void setAccesorioPecho2(string accesorioPecho2) { this.accesorioPecho2 = accesorioPecho2; }
    public void setArma(string arma) { this.arma = arma; }
    public void setEscudo(string escudo) { this.escudo = escudo; }

}
