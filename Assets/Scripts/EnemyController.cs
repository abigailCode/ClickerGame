using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    GameObject HPBar;

    private void Start()
    {
        HPBar = GameObject.Find("Fill");
    }
    void Update() 
    {
        HPBar.GetComponent<Image>().fillAmount = health / maxHealth;
    }

    private void OnDestroy()
    {
        GameManager.instance.generateEnemy();
    }

    public void TakeDamage(int weaponDamage)
    {
        if (health > 0)
        {
            health -= weaponDamage;
        }
        else Destroy(gameObject);
    }

   
}
