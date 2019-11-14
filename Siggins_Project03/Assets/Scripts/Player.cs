using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gm;
    public Pokemon pokemon;

    public List<Pokemon> ownedPokemon = new List<Pokemon>();

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
        public List<GameManager.PokemonMoves> moves = new List<GameManager.PokemonMoves>();
}
