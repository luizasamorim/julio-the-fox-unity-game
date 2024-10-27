using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPc : MonoBehaviour
{
    private Rigidbody2D rbd;
    public GameObject feet;
    public float vel;
    public float jump;
    private bool floor;
    public LayerMask floorMask;
    public LayerMask obstacleMask;
    private bool right = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0.5f;
        rbd = GetComponent<Rigidbody2D>();
        vel = 5;
        jump = 550;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(x * vel, rbd.velocity.y); //movimentar

        //detectando movimento
        if (x == 0)
            animator.SetBool("runing", false); //parado
        else
            animator.SetBool("runing", true); //correndo

        //detectando pulo
        if (Input.GetKeyDown(KeyCode.UpArrow) && floor) //fora do chão e com a seta pra cima pressionada
            rbd.AddForce(new Vector2(0,jump));

        if (rbd.velocity.y > 0) 
        {
            animator.SetBool("jumping", true);
            animator.SetBool("falling", false);
        }
        else if (rbd.velocity.y < 0) 
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);

            if (rbd.velocity.y < -30) //morte
            {
                SceneManager.LoadSceneAsync(2);
            }
        }

        if (floor)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
        //detectando o chao
        RaycastHit2D hit;
        hit = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, floorMask | obstacleMask);

        if (hit.collider == null) 
        {
            floor = false;
            transform.parent = hit.collider.transform;
        }            
        else
        {
            floor = true;
            transform.parent = hit.collider.transform;
        }

        // detectando direcao
        if (x < 0 && right || x > 0 && !right)
        {
            transform.Rotate(new Vector2(0,180));
            right = !right;
        }
    }
}
