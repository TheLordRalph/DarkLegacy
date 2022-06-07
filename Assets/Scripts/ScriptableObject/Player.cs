using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{

    [SerializeField] public CharacterDefault characterDefault;
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


    public void setCharacterDefault(CharacterDefault characterDefault) { this.characterDefault = characterDefault; }
}
