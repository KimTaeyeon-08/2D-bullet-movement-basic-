using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 50;
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
        if (collision.gameObject.CompareTag("Bullet"))
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
        Destroy(collision.gameObject);//Bullet.cs의 참고** 2초 뒤 사라지기 기능 이미 bullet에 있음 
        }
           
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
