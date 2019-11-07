using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public GameObject gm;
    

    public string Name;
    public Sprite image;
    public PokemonType type;
    public Stats HPStat;
    public Stats AttackStat;
    public Stats DefenseStat;
    public Stats SpeedStat;
    public float Speed;

    public PokemonStats pokemonStats;


    public enum PokemonType
    {
        Fire, 
        Water,
        Grass,
        Flying,
        Electric,
        Normal,
        Fighting,
        Psychic,
        Ground,
        Rock,
        Steel,
        Fairy,
        Dark,
        Ghost,
        Dragon,
        Ice
    }

    [System.Serializable]
    public class PokemonStats
    {
        public int SpeedStat;
        public int AttackStat;
        public int DefenseStat;
        public int SpAttackStat;
        public int SpDefenseStat;
        public int EvasionStat;
    }

}
