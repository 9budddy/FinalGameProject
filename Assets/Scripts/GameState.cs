using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameState", menuName = "Assets/GameState")]
public class GameState : ScriptableObject
{
    public bool changeWeapon { get; set; }
    public bool sword { get; set; }
    public bool bow { get; set; }
}
