using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    Slider enemySlider;
    [SerializeField]
    Slider playerSlider;
    [SerializeField]
    Slider ambienceSlider;
    [SerializeField]
    Slider itemsSlider;
    [SerializeField]
    Slider masterSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = AudioManager.musicVolume;
        enemySlider.value = AudioManager.enemiesVolume;
        playerSlider.value = AudioManager.playerVolume;
        ambienceSlider.value = AudioManager.ambienceVolume;
        itemsSlider.value = AudioManager.itemsVolume;
        masterSlider.value = AudioManager.masterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.musicVolume = musicSlider.value;
        AudioManager.enemiesVolume = enemySlider.value;
        AudioManager.playerVolume = playerSlider.value;
        AudioManager.ambienceVolume = ambienceSlider.value;
        AudioManager.itemsVolume = itemsSlider.value;
        AudioManager.masterVolume = masterSlider.value;
    }
}
