using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Slider hpSlider;

    public void Init(PlayerManager playerManager) {

        hpSlider.maxValue = playerManager.maxHp;
        hpSlider.value = playerManager.maxHp;
    }

    public void UpdateHP(int hp) {
        hpSlider.value = hp;
    }
    
}
