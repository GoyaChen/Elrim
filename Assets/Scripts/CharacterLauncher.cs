using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLauncher : MonoBehaviour
{
    public float attackSpeed;
    public GameObject bullet;
    public float scale;
    public float damage;
    public bool ismagic;

    private GameObject new_bullet;
    private Rigidbody new_bullet_rb;
    private BulletAttacker new_bulletAttacker;
    public float shootForce;

    float m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        m_Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= attackSpeed)
            {
                Shoot();
                m_Timer = 0;
            }
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
        new_bullet_rb.AddForce(gameObject.transform.forward * shootForce);
    }
}
