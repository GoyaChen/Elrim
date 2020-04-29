using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public float Max_HP;
    public float defense;
    public GameObject unit;
    public float dyingTime;
    public float HP;

    private GameObject bullet;
    private float bullet_damage;
    private bool bullet_isMagic;
    private BulletController BulletController;
    private string bulletTag;

    // Start is called before the first frame update
    void Start()
    {
        HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            GameObject.Destroy(unit, dyingTime);
            GameObject.Destroy(gameObject, dyingTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            bulletTag = "CharacterBullet";
        }
        else if(gameObject.CompareTag("Character"))
        {
            bulletTag = "EnemyBullet";
        }
        print(bulletTag);
        if (other.gameObject.CompareTag(bulletTag))
        {
            print(HP);
            BulletController = other.GetComponent<BulletController>();
            bullet_damage = BulletController.damage;
            bullet_isMagic = BulletController.ismagic;
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
