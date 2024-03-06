using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = null;
    [SerializeField] Transform enemiesSpawner = null;
    [SerializeField] GameObject enemy;
    [SerializeField] AudioSource music;
    public static GameManager instance;
    private int weaponDamage = 20;

    void Start()
    {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        music.loop = true;
    }

    public void generateEnemy()
    {
        int index = Random.Range(0, enemies.Length);

        enemy = Instantiate(enemies[index], enemiesSpawner);

    }

    public void Click() {
        enemy.GetComponent<EnemyController>().TakeDamage(weaponDamage);
    }

    public void WeaponSelect()
    {
        switch (GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                weaponDamage = 20;
                break;
            case 1:
                weaponDamage = 30;
                break;
            case 2:
                weaponDamage = 40;
                break;
        }
        
    }

    public void ToggleMusic()
    {
        music.mute = !GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
        
    }

    public void SetVolume()
    {
        music.volume = GameObject.Find("Slider").GetComponent<Slider>().value;
    }
}
