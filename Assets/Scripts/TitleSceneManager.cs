using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ボタンを押したらバトルシーンに移る
public class TitleSceneManager : MonoBehaviour
{
    public void OnStartButton() {

        SceneManager.LoadScene("BattleScene");
    }
}
