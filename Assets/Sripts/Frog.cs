using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : EnemyScript 
{
    public BoxCollider2D frogCol;
    public LayerMask Ground;

    private bool facingleft = true;
    public float xPosMaxLeft;
    public float xPosMaxRight;
    public float jumpMoveLength;
    public float jumpForce;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAnim.GetBool("jumping") == false && enemyAnim.GetBool("falling") == false)
        {

        
            if (enemyRb.velocity.y <0.1f)
            {
                enemyAnim.SetBool("jumping", false);
                enemyAnim.SetBool("falling", true);

            }


        }

        if (frogCol.IsTouchingLayers(Ground) && enemyAnim.GetBool("falling") == true)
        {
            enemyAnim.SetBool("falling", false);

        }


    }

    private void FrogMovement()
    {

        if (facingleft== true) 
        {
            if (transform.localScale.x != 1 && frogCol.IsTouchingLayers(Ground)) 
            {
                transform.localScale = new Vector2(1, 1);
            }

            if (transform.position.x > xPosMaxLeft)
            {
                if (frogCol.IsTouchingLayers(Ground))
                {
                    enemyRb.velocity = new Vector2(-jumpMoveLength, jumpForce);
                    enemyAnim.SetBool("jumping", true);
        

                }
            }

            else
            {
                facingleft = false;


            }

        }
        else
        {

            if (transform.localScale.x != -1 && frogCol.IsTouchingLayers(Ground))
            {
                transform.localScale = new Vector2(-1, 1);
            }

            if (transform.position.x < xPosMaxRight)
            {
                if (frogCol.IsTouchingLayers(Ground))
                {
                    enemyRb.velocity = new Vector2(jumpMoveLength, jumpForce);
                    enemyAnim.SetBool("jumping", true);


                }
            }

            else
            {
                facingleft = true;


            }

        }

    }
}
