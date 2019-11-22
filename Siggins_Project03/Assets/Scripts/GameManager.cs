using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pokemon pokemon;
    public BattleManager bm;

    public List<Pokemon> allPokemon = new List<Pokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    void Start()
    {
        bm.ChangeMenu(BattleMenu.Selection);
    }

    [System.Serializable]
    public class Stats
    {
        public float statMin;
        public float statMax;
    }

    [System.Serializable]
    public class PokemonMoves
    {
        public string name;
        public Stats moveStat;
        public MoveType category;
        public Pokemon.PokemonType moveType;
        public int PP;
        public float damage;
        public float accuracy;
    }

    public enum MoveType
    {
        physical,
        special,
        status
    }
}
