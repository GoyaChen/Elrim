using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    public float attackSpeed;
    public GameObject bullet;
    public float scale;
    public float damage;
    public bool ismagic;
    public bool isEnemy;
    public float shootForce;

    private GameObject new_bullet;
    private Rigidbody new_bullet_rb;
    private BulletAttacker new_bulletAttacker;
    private bool inRange;
   
    float m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        m_Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= attackSpeed)
            {
                Shoot();
                m_Timer = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            inRange = false;
        }
    }

    void Shoot()
    {
        new_bullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
            gameObject.transform.rotation, gameObject.transform);
        new_bullet_rb = new_bullet.GetComponent<Rigidbody>();
        new_bulletAttacker = new_bullet.GetComponent<BulletAttacker>();
        new_bulletAttacker.scale = scale;
        new_bulletAttacker.damage = damage;
        new_bulletAttacker.ismagic = ismagic;
        new_bulletAttacker.isEnemy = isEnemy;
        new_bullet_rb.AddForce(gameObject.transform.forward * shootForce);
    }
}
