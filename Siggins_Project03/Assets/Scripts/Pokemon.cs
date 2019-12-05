using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public GameManager gm;
    public Sliders sliderManager;

    public string Name;
    public Sprite image;
    public PokemonType type;
    public float HP;
    private float maxHP;
    public float SpeedStat;
    public float AttackStat;
    public float DefenseStat;
    public float SpAttackStat;
    public float SpDefenseStat;
    public int EvasionStat;

    void Awake()
    {
        sliderManager = FindObjectOfType<Sliders>();
    }

    void Start()
    {
        maxHP = HP;
        sliderManager.updateHPSliderB();
        sliderManager.updateHPSliderS();
    }

    public void damagePokemon(float damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            HP = 0;
        }
        if (HP < 1 && HP > 0)
        {
            HP = 1;
        }
        sliderManager.updateHPSliderB();
        sliderManager.updateHPSliderS();
    }

    public void changeAttack(bool increase)
    {
        if (increase == true)
        {
            AttackStat += 10;
        }
        if (increase == false)
        {
            AttackStat -= 10;
        }
        if (AttackStat <= 15)
        {
            AttackStat = 15;
        }
    }

    public void changeDefense(bool increase)
    {
        if (increase == true)
        {
            DefenseStat += 10;
        }
        if (increase == false)
        {
            DefenseStat -= 10;
        }
        if (DefenseStat <= 15)
        {
            DefenseStat = 15;
        }
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
}
