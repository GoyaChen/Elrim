using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleProcessor : MonoBehaviour
{
    public float Max_HP;
    public float defense;
    public GameObject unit;
    public float dyingTime;
    public Scrollbar HP_bar;
    public bool isEnemy;

    private GameObject bullet;
    private float bullet_damage;
    private bool bullet_isMagic;
    private float HP;
    private BulletAttacker bulletAttacker;
    private string bulletTag;

    // Start is called before the first frame update
    void Start()
    {
        HP = Max_HP;
        HP_bar.size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        HP_bar.transform.position = player2DPosition + new Vector2(1, 1);
        HP_bar.size = (HP<=0 ? 0 : HP) / Max_HP;
        if(HP <= 0)
        {
            GameObject.Destroy(unit, dyingTime);
            GameObject.Destroy(gameObject, dyingTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isEnemy)
        {
            bulletTag = "CharacterBullet";
        }
        else
        {
            bulletTag = "EnemyBullet";
        }
        if (other.gameObject.CompareTag(bulletTag))
        {
            bulletAttacker = other.GetComponent<BulletAttacker>();
            bullet_damage = bulletAttacker.damage;
            if (!bullet_isMagic)
            {
                HP -= (bullet_damage - defense);
            }
            else
            {
                HP -= bullet_damage;
            }
        }
    }
}
