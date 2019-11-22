using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;

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

    [Header("Info")]
    public GameObject infoMenu;
    public Text infoText;

    [Header("Misc")]
    public int currentSelection;

    void Start()
    {
        fightT = fight.text;
        bagT = bag.text;
        pokemonT = pokemon.text;
        runT = run.text;
        moveOT = moveO.text;
        moveTT = moveT.text;
        moveTHT = moveTH.text;
        moveFT = moveF.text;
    }

    void Update()
    {
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
                        break;
                    case 2:
                        moveO.text = moveOT;
                        moveT.text = "> " + moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = moveFT;
                        break;
                    case 3:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = "> " + moveTHT;
                        moveF.text = moveFT;
                        break;
                    case 4:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = "> " + moveFT;
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
                        break;
                    case 2:
                        fight.text = fightT;
                        bag.text = " > " + bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        break;
                    case 3:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = " > " + pokemonT;
                        run.text = runT;
                        break;
                    case 4:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = " > " + runT;
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
}
public enum BattleMenu
{
    Selection, 
    Fight,
    Bag,
    Pokemon,
    Info
}
