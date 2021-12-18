using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;//global variable
    public GameObject BulletPrefab;
    public float bulletSpeed = 100f;

    float health = 100;
    public float Health
    {
        get { return health; }
        //set { health = value; } erase it!!! 
    }
    void TakeDamage(int value)
    {
        health -= value;
        // Debug.Log(GetHealth());
    }
    //따로 구성 안해도 괜찮다. 
    //public float GetHealth()
    //{
    //    return health;
    //}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("충돌!");
            //health -= 10;
            TakeDamage(10);//10만큼 감소 위의 TakeDamage함수 
                           //  Debug.Log(health);
            if (health <= 0)
            {
                Die();
            }
            // collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(),gameObject.GetComponent<CircleCollider2D>());
        }
       
    }
    void Die()
    {
        Destroy(gameObject);
    }

    // void Start()
    //{
    //int testInt = 1; //local variable 
        //bool a = true'
        //bool b = false;
        //gameObject.SetActive(a && b);
        //gameObject.SetActive(a || b);
        //transform.position = Vector3.one;
        //Vector2 newPos =transform.position;
        //newPos.x = newPos.x+5;
        //transform.position = newPos;
  //  }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed, 0);
            //권장하지 않음
            //Vector2 newPos = transform.position;
            //newPos.y = newPos.y +1;
            //transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //for(int i=0; i<3; i++)
            //{
            //    GameObject bullet = Instantiate(BulletPrefab);
            //    Vector3 bulletPos = transform.position;
            //    bulletPos.y += 0.3f * i;//bulletPos.y = bulletPos.y + 0.3f *i;와 같음 
            //    bullet.transform.position = bulletPos;
            //    //y direction , speed = 1 
            //    float tempSpeed = bulletSpeed;
            //    tempSpeed += 30 * i;//tempSpeed = tempSpeed+30*i;
            //    bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * tempSpeed);//Vector2(0,bulletSpeed)

            //}

            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            //Debug.Log("pressing..");
            // GameObject Bullet = Instantiate(BulletPrefab);
            // Instantiate(BulletPrefab);
          
        }
    }


}
