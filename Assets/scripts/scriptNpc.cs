using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptNpc : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel;
    private bool right = true;
    public GameObject front;
    public GameObject back;
    public GameObject topRight;
    public GameObject topLeft;
    public GameObject pc;
    public LayerMask pcMask;
    public LayerMask obstacleMask;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        vel = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // movendo o npc
        if (right)
            transform.Translate(Vector2.right * vel * Time.deltaTime);
        else
            transform.Translate(Vector2.left * vel * Time.deltaTime);

        RaycastHit2D hitObstacle;
        hitObstacle = Physics2D.Raycast(front.transform.position, Vector2.right, 0.1f, obstacleMask);

        if (hitObstacle.collider) 
        {
            transform.Rotate(new Vector2(0,180));
            right = !false;
        } 

        RaycastHit2D hitTopRight;
        hitTopRight = Physics2D.Raycast(topRight.transform.position, Vector2.up, 0.1f, pcMask);
        RaycastHit2D hitTopLeft;
        hitTopLeft = Physics2D.Raycast(topLeft.transform.position, Vector2.up, 0.1f, pcMask);

        if (hitTopRight.collider || hitTopLeft.collider) 
        {
            Destroy(gameObject);
        } 

        RaycastHit2D hitFront;
        hitFront = Physics2D.Raycast(front.transform.position, Vector2.right, 0.1f, pcMask);
        RaycastHit2D hitBack;
        hitBack = Physics2D.Raycast(back.transform.position, Vector2.left, 0.1f, pcMask);

        if (hitFront.collider || hitBack.collider) 
        {
            // Debug.Log("e morreu");
            Destroy(pc.gameObject);
            SceneManager.LoadSceneAsync(2);
        } 
    }

}
