using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public GameManager gm;
    

    public string Name;
    public Sprite image;
    public PokemonType type;
    public int HP;
    private int maxHP;
    public GameManager.Stats AttackStat;
    public GameManager.Stats DefenseStat;

    public BasePokemonStats pokemonStats;


    void Start()
    {
        maxHP = HP;
    }

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
    public class BasePokemonStats
    {
        public int SpeedStat;
        public int AttackStat;
        public int DefenseStat;
        public int SpAttackStat;
        public int SpDefenseStat;
        public int EvasionStat;
    }

}
