using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    protected Animator enemyAnim;
    protected Rigidbody2D enemyRb;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyAnim= GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void EnemyDeathEffect()
    {
        enemyAnim.SetTrigger("death");
        enemyRb.velocity = Vector2.zero;
        enemyRb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().enabled = false;

    }


    private void EnemyDead()
    {
        Destroy(gameObject);
    }



}
