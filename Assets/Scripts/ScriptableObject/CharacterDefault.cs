using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefault", menuName = "ScriptableObjects/CharacterDefault", order = 2)]
public class CharacterDefault : ScriptableObject
{
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
