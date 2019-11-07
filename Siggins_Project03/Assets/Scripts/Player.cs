using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gm;
    public GameObject pokemon;

    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();

    void Start()
    {



    }

    void Update()
    {


    }
   
}

[System.Serializable]

    public class OwnedPokemon
    {
        public string NickName;
        public Pokemon pokemon;
        public int level;
        public List<PokemonMoves> moves = new List<PokemonMoves>();
}
