using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider HPSliderB;
    public Slider HPSliderS; 
    public Slider XPSlider;

    public Pokemon squirtle;
    public Pokemon bulbasaur;
    public BattleManager XP;

    void Start()
    {
        squirtle.GetComponent<Pokemon>();
        bulbasaur.GetComponent<Pokemon>();
        XP.GetComponent<BattleManager>();
    }
     public void updateHPSliderB()
    {
        HPSliderB.value = bulbasaur.HP;
        if (HPSliderB.value < 75 && HPSliderB.value > 25)
        {
            HPSliderB.image.color = Color.yellow;
        }
        if (HPSliderB.value < 25)
        {
            HPSliderB.image.color = Color.red;
        }
    }
    public void updateHPSliderS()
    {
        HPSliderS.value = squirtle.HP;
        if(HPSliderS.value < 75 && HPSliderS.value > 25)
        {
            HPSliderS.image.color = Color.yellow;
        }
        if(HPSliderS.value < 25)
        {
            HPSliderS.image.color = Color.red;
        }
    }
    public void updateXPSlider()
    {
        XPSlider.value = XP.XP;
    }
}
