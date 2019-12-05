using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;
    public Sliders sliderManager;

    [Header("Selection")]
    public GameObject selectionMenu;
    public GameObject selectionInfo;
    public Text selectionInfoText;
    public Text fight;
    private string fightT;
    public Text bag;
    private string bagT;
    public Text pokemon;
    private string pokemonT;
    public Text run;
    private string runT;

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    public Text type;
    public Text moveO;
    private string moveOT;
    public Text moveT;
    private string moveTT;
    public Text moveTH;
    private string moveTHT;
    public Text moveF;
    private string moveFT;
    public int PP1 = 35;
    public int PP2 = 40;
    public int PP3 = 25;
    public int PP4 = 20;

    [Header("VFX")]
    public GameObject vineWhipFX;
    public GameObject stateUpB;
    public GameObject stateUpS;
    public GameObject stateDownB;
    public GameObject stateDownS;
    public GameObject growlFX;
    public GameObject withdrawFX;
    public GameObject tailWhipFX;
    public GameObject waterGunFX;
    public GameObject tackleB;
    public GameObject tackleS;

    [Header("SFX")]
    public AudioClip tackleSFX;
    public AudioClip waterGunSFX;
    public AudioClip vineWhipSFX;
    public AudioClip growlSFX;
    public AudioClip growthSFX;
    public AudioClip tailWhipSFX;
    public AudioClip withdrawSFX;
    public AudioClip music;
    public AudioClip victory;
    public AudioClip faint;
    public AudioClip statusUp;
    public AudioClip statusDown;
    public AudioClip hit;
    public AudioClip superEffective;
    public AudioClip notEffective;
    public AudioClip levelUp;
    public AudioSource background;
    public AudioSource attacks;

    [Header("Info")]
    public GameObject infoMenu;
    public Text infoText;

    [Header("Misc")]
    public int currentSelection;
    public GameObject attackPositionB;
    public GameObject battlePositionB;
    public GameObject faintPositionB;
    public GameObject attackPositionS;
    public GameObject battlePositionS;
    public GameObject faintPositionS;
    public GameObject playerPokemon;
    public GameObject enemyPokemon;
    public SpriteRenderer sRender;
    public SpriteRenderer bRender;

    [Header("Pokemon Menu")]
    public int XP = 10;
    public Text level;
    public Text health;

    [Header("Health")]
    public Pokemon squirtle;
    public Pokemon bulbasaur;
    private int HPLeft;

    [Header("Pokemon Stats")]
    public float bulbasaurAtt;
    public float bulbasaurDef;
    public float bulbasaurSpDef;
    public float squirtleAtt;
    public float squirtleSpAtt;
    public float squirtleDef;

    private System.Action[] squirtleMoves;

    void Move1()
    {
        StartCoroutine("EnemyTackle");
    }

    void Move2()
    {
        StartCoroutine("TailWhip");
    }

    void Move3()
    {
        StartCoroutine("WaterGun");
    }

    void Move4()
    {
        StartCoroutine("Withdraw");
    }

    void Awake()
    {
        sliderManager = FindObjectOfType<Sliders>();
    }

    void Start()
    {
        level.text = "LV 5";
        XP = 0;
        squirtleMoves = new System.Action[]
        {
            Move1,
            Move2,
            Move3,
            Move4,
        };

        fightT = fight.text;
        bagT = bag.text;
        pokemonT = pokemon.text;
        runT = run.text;
        moveOT = moveO.text;
        moveTT = moveT.text;
        moveTHT = moveTH.text;
        moveFT = moveF.text;

        squirtle.GetComponent<Pokemon>();
        bulbasaur.GetComponent<Pokemon>();

    }

    void Update()
    {
     bulbasaurAtt = bulbasaur.AttackStat;
     bulbasaurDef = bulbasaur.DefenseStat;
     bulbasaurSpDef = bulbasaur.SpDefenseStat;
     squirtleAtt = squirtle.AttackStat;
     squirtleDef = squirtle.DefenseStat;
     squirtleSpAtt = squirtle.SpAttackStat;
        HPLeft = (int)bulbasaur.HP;
        health.text = HPLeft + "/150";

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentSelection < 4)
            {
                currentSelection++;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSelection > 0)
            {
                currentSelection--;
            }
        }
        if (currentSelection == 0)
        {
            currentSelection = 1;
        }

        switch (currentMenu)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        moveO.text = "> " + moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = moveFT;
                        PP.text = PP1 + "/35";
                        type.text = "TYPE/NORMAL";
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            PP1 = PP1 - 1;
                            if(PP1 <= 0)
                            {
                                PP1 = 0;
                            }
                            if (PP1 > 0)
                            {
                                StartCoroutine("Tackle");
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            ChangeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 2:
                        moveO.text = moveOT;
                        moveT.text = "> " + moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = moveFT;
                        PP.text = PP2 + "/40";
                        type.text = "TYPE/NORMAL";
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            PP2 = PP2 - 1;
                            if (PP2 <= 0)
                            {
                                PP2 = 0;
                            }
                            if (PP2 > 0)
                            {
                                StartCoroutine("Growl");
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            ChangeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 3:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = "> " + moveTHT;
                        moveF.text = moveFT;
                        PP.text = PP3 + "/25";
                        type.text = "TYPE/GRASS";
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            PP3 = PP3 - 1;
                            if (PP3 <= 0)
                            {
                                PP3 = 0;
                            }
                            if(PP3 > 0)
                            {
                                StartCoroutine("VineWhip");
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            ChangeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 4:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = "> " + moveFT;
                        PP.text = PP4 + "/20";
                        type.text = "TYPE/NORMAL";
                        if (Input.GetKeyDown(KeyCode.Space))
                            {
                                PP4 = PP4 - 1;
                                if (PP4 <= 0)
                                {
                                    PP4 = 0;
                                }
                            if (PP4 > 0)
                            {
                                StartCoroutine("Growth");
                            }
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                ChangeMenu(BattleMenu.Selection);
                            }
                        break;
                }
                break;
            case BattleMenu.Selection:
                switch (currentSelection)
                {
                    case 1:
                        fight.text = " > " + fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            ChangeMenu(BattleMenu.Fight);
                        }
                        break;
                    case 2:
                        fight.text = fightT;
                        bag.text = " > " + bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine("Bag");
                        }
                        break;
                    case 3:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = " > " + pokemonT;
                        run.text = runT;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine("Party");
                        }
                        break;
                    case 4:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = " > " + runT;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine("Run");
                        }
                        break;
                }
                break;
        }
    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        currentSelection = 1;
        switch (m)
        {
            case BattleMenu.Selection:
                selectionMenu.SetActive(true);
                selectionInfo.SetActive(true);
                movesMenu.SetActive(false);
                movesDetails.SetActive(false);
                infoMenu.SetActive(false);
                break;
            case BattleMenu.Fight:
                selectionMenu.SetActive(false);
                selectionInfo.SetActive(false);
                movesMenu.SetActive(true);
                movesDetails.SetActive(true);
                infoMenu.SetActive(false);
                break;
            case BattleMenu.Info:
                selectionMenu.SetActive(false);
                selectionInfo.SetActive(false);
                movesMenu.SetActive(false);
                movesDetails.SetActive(false);
                infoMenu.SetActive(true);
                break;
        }
    }
    IEnumerator Bag()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "YOUR BAG IS EMPTY.";
        yield return new WaitForSeconds(2);
        ChangeMenu(BattleMenu.Selection);
    }
    IEnumerator Party()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "YOU HAVE NO OTHER POKEMON.";
        yield return new WaitForSeconds(2);
        ChangeMenu(BattleMenu.Selection);
    }
    IEnumerator Run()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "YOU CAN'T RUN FROM A TRAINER BATTLE.";
        yield return new WaitForSeconds(2);
        ChangeMenu(BattleMenu.Selection);
    }

    IEnumerator EnemyFlash()
    {
        sRender.enabled = false;
        yield return new WaitForSeconds(.2f);
        sRender.enabled = true;
        yield return new WaitForSeconds(.2f);
        sRender.enabled = false;
        yield return new WaitForSeconds(.2f);
        sRender.enabled =true;
    }

    IEnumerator PlayerFlash()
    {
        bRender.enabled = false;
        yield return new WaitForSeconds(.2f);
        bRender.enabled = true;
        yield return new WaitForSeconds(.2f);
        bRender.enabled = false;
        yield return new WaitForSeconds(.2f);
        bRender.enabled = true;
    }

    IEnumerator Tackle()
    {
        float TackleDamage = 40 * (bulbasaurAtt/squirtleDef);
        ChangeMenu(BattleMenu.Info);
        infoText.text = "BULBASAUR used TACKLE!";
        yield return new WaitForSeconds(1);
        playerPokemon.transform.position = attackPositionB.transform.position;
        tackleS.SetActive(true);
        attacks.clip = tackleSFX;
        attacks.Play();
        yield return new WaitForSeconds(0.7f);
        tackleS.SetActive(false);
        playerPokemon.transform.position = battlePositionB.transform.position;
        yield return new WaitForSeconds(1);
        attacks.clip = hit;
        attacks.Play();
        StartCoroutine("EnemyFlash");
        squirtle.damagePokemon (TackleDamage);
        yield return new WaitForSeconds(2);
        if (squirtle.HP <= 0)
        {
            enemyPokemon.transform.position = faintPositionS.transform.position;
            ChangeMenu(BattleMenu.Info);
            infoText.text = "Foe SQUIRTLE fainted.";
            attacks.clip = faint;
            attacks.Play();
            background.clip = victory;
            background.Play();
            StartCoroutine("LevelUp");
        }
        else
        {
            yield return new WaitForSeconds(2);
            StartCoroutine("EnemyTurn");
        }
    }
    IEnumerator Growl()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "BULBASAUR used GROWL!";
        yield return new WaitForSeconds(1);
        growlFX.SetActive(true);
        squirtle.changeAttack(false);
        attacks.clip = growlSFX;
        attacks.Play();
        yield return new WaitForSeconds(1);
        growlFX.SetActive(false);
        attacks.clip = statusDown;
        attacks.Play();
        stateDownS.SetActive(true);
        infoText.text = "Foe SQUIRTLE'S attack fell!";
        yield return new WaitForSeconds(1);
        stateDownS.SetActive(false);
        yield return new WaitForSeconds(3);
        StartCoroutine("EnemyTurn");
    }
    IEnumerator VineWhip()
    {
        float VineWhipDamage = 45 * (bulbasaurAtt / squirtleDef);
        ChangeMenu(BattleMenu.Info);
        infoText.text = "BULBASAUR used VINE WHIP!";
        yield return new WaitForSeconds(1);
        playerPokemon.transform.position = attackPositionB.transform.position;
        vineWhipFX.SetActive(true);
        attacks.clip = vineWhipSFX;
        attacks.Play();
        yield return new WaitForSeconds(1);
        playerPokemon.transform.position = battlePositionB.transform.position;
        vineWhipFX.SetActive(false);
        if (squirtle.type == Pokemon.PokemonType.Water)
        {
            VineWhipDamage *= 2;
            attacks.clip = superEffective;
            attacks.Play();
        }
        StartCoroutine("EnemyFlash");
        squirtle.damagePokemon(VineWhipDamage);
        yield return new WaitForSeconds(1);
        infoText.text = "It's super effective!";
        yield return new WaitForSeconds(2);
        if (squirtle.HP <= 0)
        {
            enemyPokemon.transform.position = faintPositionS.transform.position;
            ChangeMenu(BattleMenu.Info);
            infoText.text = "Foe SQUIRTLE fainted.";
            attacks.clip = faint;
            attacks.Play();
            background.clip = victory;
            background.Play();
            StartCoroutine("LevelUp");
        }
        else
        {
            yield return new WaitForSeconds(2);
            StartCoroutine("EnemyTurn");
        }
    }
    IEnumerator Growth()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "BULBASAUR used GROWTH!";
        yield return new WaitForSeconds(1);
        bulbasaur.changeAttack(true);
        attacks.clip = growthSFX;
        attacks.Play();
        playerPokemon.transform.localScale = battlePositionB.transform.localScale;
        yield return new WaitForSeconds(1);
        playerPokemon.transform.localScale = attackPositionB.transform.localScale;
        attacks.clip = statusUp;
        attacks.Play();
        stateUpB.SetActive(true);
        yield return new WaitForSeconds(1);
        stateUpB.SetActive(false);
        infoText.text = "BULBASAUR'S attack rose!";
        yield return new WaitForSeconds(3);
        StartCoroutine("EnemyTurn");
    }

    IEnumerator LevelUp()
    {
        XP = 50;
        sliderManager.updateXPSlider();
        yield return new WaitForSeconds(1);
        XP = 25;
        sliderManager.updateXPSlider();
        ChangeMenu(BattleMenu.Info);
        infoText.text = "BULBASAUR gained 75 XP!";
        yield return new WaitForSeconds(2);
        attacks.clip = levelUp;
        attacks.Play();
        infoText.text = "BULBASAUR grew to level 6!";
        level.text = "LV 6";
    }

    IEnumerator EnemyTackle()
    {
        float TackleDamage = 40 * (squirtleAtt / bulbasaurDef);
        ChangeMenu(BattleMenu.Info);
        infoText.text = "Foe SQUIRTLE used TACKLE!";
        yield return new WaitForSeconds(1);
        enemyPokemon.transform.position = attackPositionS.transform.position;
        attacks.clip = tackleSFX;
        attacks.Play();
        tackleB.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        tackleB.SetActive(false);
        enemyPokemon.transform.position = battlePositionS.transform.position;
        yield return new WaitForSeconds(1);
        attacks.clip = hit;
        attacks.Play();
        StartCoroutine("PlayerFlash");
        bulbasaur.damagePokemon(TackleDamage);
        if (bulbasaur.HP <= 0)
        {
            yield return new WaitForSeconds(2);
            playerPokemon.transform.position = faintPositionB.transform.position;
            ChangeMenu(BattleMenu.Info);
            infoText.text = "BULBASAUR fainted.";
            attacks.clip = faint;
            attacks.Play();
        }
    }
    IEnumerator TailWhip()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "Foe SQUIRTLE used TAIL WHIP!";
        yield return new WaitForSeconds(1);
        bulbasaur.changeDefense(false);
        attacks.clip = tailWhipSFX;
        attacks.Play();
        tailWhipFX.SetActive(true);
        enemyPokemon.SetActive(false);
        yield return new WaitForSeconds(1);
        tailWhipFX.SetActive(false);
        enemyPokemon.SetActive(true);
        attacks.clip = statusDown;
        attacks.Play();
        stateDownB.SetActive(true);
        yield return new WaitForSeconds(1);
        stateDownB.SetActive(false);
        infoText.text = "BULBASAUR'S defense fell!";
    }
    IEnumerator WaterGun()
    {
        float WaterGunDamage = 40 * (squirtleSpAtt / bulbasaurSpDef);
        ChangeMenu(BattleMenu.Info);
        infoText.text = "Foe SQUIRTLE used WATER GUN!";
        yield return new WaitForSeconds(1);
        enemyPokemon.transform.position = attackPositionS.transform.position;
        attacks.clip = waterGunSFX;
        attacks.Play();
        waterGunFX.SetActive(true);
        yield return new WaitForSeconds(1);
        enemyPokemon.transform.position = battlePositionS.transform.position;
        waterGunFX.SetActive(false);
        if (bulbasaur.type == Pokemon.PokemonType.Grass)
        {
            WaterGunDamage /= 2;
            attacks.clip = notEffective;
            attacks.Play();
        }
        StartCoroutine("PlayerFlash");
        bulbasaur.damagePokemon(WaterGunDamage);
        yield return new WaitForSeconds(1);
        infoText.text = "It's not very effective...";
        if (bulbasaur.HP <= 0)
        {
            yield return new WaitForSeconds(2);
            playerPokemon.transform.position = faintPositionB.transform.position;
            ChangeMenu(BattleMenu.Info);
            infoText.text = "BULBASAUR fainted.";
            attacks.clip = faint;
            attacks.Play();
        }
    }
    IEnumerator Withdraw()
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = "Foe SQUIRTLE used WITHDRAW!";
        yield return new WaitForSeconds(1);
        squirtle.changeDefense(true);
        attacks.clip = withdrawSFX;
        attacks.Play();
        withdrawFX.SetActive(true);
        yield return new WaitForSeconds(1);
        withdrawFX.SetActive(false);
        attacks.clip = statusUp;
        attacks.Play();
        stateUpS.SetActive(true);
        yield return new WaitForSeconds(1);
        stateUpS.SetActive(false);
        infoText.text = "Foe SQUIRTLE'S defense rose!";
    }
    IEnumerator EnemyTurn()
    {
        int moveIndex = Random.Range(0, squirtleMoves.Length);
        if (squirtleMoves[moveIndex] != null)
        {
            squirtleMoves[moveIndex]();
        }
        yield return new WaitForSeconds(4);
        ChangeMenu(BattleMenu.Selection);
    }
}
public enum BattleMenu
{
    Selection, 
    Fight,
    Bag,
    Pokemon,
    Info
}
