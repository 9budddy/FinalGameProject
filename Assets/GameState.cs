using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameState", menuName = "Assets/GameState")]
public class GameState : ScriptableObject
{
    public int score { get; set; }
}
