using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveFile", menuName = "ScriptableResources/SaveFile", order = 1)]
public class SaveFileResource : ScriptableObject
{
    public int totalCoins;
    public bool unlockedGreatFireball;
    public bool unlockedLaserBeam;
    public bool unlockedMagicCombo;
    public bool unlockedMeteor;
    public bool unlockedStormArea;
    public bool unlockedStunBall;
    public bool unlockedThunderCaster;
}
