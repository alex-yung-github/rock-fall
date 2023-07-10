using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProgressCheck : MonoBehaviour
{

    [SerializeField] private bool FZIslandBossAcquired;
    [SerializeField] private bool secondBossAcquired;
    // Start is called before the first frame update

    public bool getFZIslandBoss(){
        return FZIslandBossAcquired;
    }
}
