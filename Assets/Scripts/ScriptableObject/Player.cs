using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{

    [SerializeField] public CharacterDefault characterDefault;


    public void setCharacterDefault(CharacterDefault characterDefault) { this.characterDefault = characterDefault; }
}
