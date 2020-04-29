using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public float shootForce;
    public float attackSpeed;
    public GameObject bullet;
    public GameObject range;
    public float scale;
    public float damage;
    public bool ismagic;
    

    private GameObject new_bullet;
    private Rigidbody new_bullet_rb;
    private BulletController new_BulletController;
    private RangeController rangeController;
    private bool inRange;
   
    float m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            rangeController = range.GetComponent<RangeController>();
            
        }
        inRange = false;
        m_Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            inRange = rangeController.inRange;
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
        else if (gameObject.CompareTag("Character"))
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
        
    }

    void Shoot()
    {
        new_bullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
            gameObject.transform.rotation, gameObject.transform);
        new_bullet_rb = new_bullet.GetComponent<Rigidbody>();
        new_BulletController = new_bullet.GetComponent<BulletController>();
        new_BulletController.scale = scale;
        new_BulletController.damage = damage;
        new_BulletController.ismagic = ismagic;
        new_bullet_rb.AddForce(gameObject.transform.forward * shootForce);
    }
}
