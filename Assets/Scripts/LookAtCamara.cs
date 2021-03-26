using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamara : MonoBehaviour
{
    

    // EnemyUIをカメラに向け続ける
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
