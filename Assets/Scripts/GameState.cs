using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameState", menuName = "Assets/GameState")]
public class GameState : ScriptableObject
{
    public Vector3 position { get; set; }
    public int selected { get; set; }
    public bool canAttack { get; set; }
    public bool attack { get; set; }
    public bool haltInput { get; set; }
    public bool changeWeapon { get; set; }
    public bool sword { get; set; }
    public bool bow { get; set; }
    public Dictionary<string, Vector3> flyingbrains { get; set; }
    public Dictionary<string, Vector3> ghosts { get; set; }
    public List<string> flyingbrainsName { get; set; }
    public List<string> ghostNames { get; set; }
    public Dictionary<string, int> hits { get; set; }
    public bool bossInvulnerable { get; set; }
    public bool endGame { get; set; }
}
