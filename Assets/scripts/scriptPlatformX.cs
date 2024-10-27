using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlatformX : MonoBehaviour
{
    private Vector2 initialPosition;
    public float vel;
    private float counter = 0;
    public int displacementY;
    public int displacementX;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        vel = 1;
        displacementX = 2;
        displacementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(counter) * displacementX;
        float y = Mathf.Cos(counter) * displacementY;

        transform.position = new Vector2(initialPosition.x + x, initialPosition.y + y);

        counter = counter + vel * Time.deltaTime;

        if (counter > 2 * Mathf.PI)
            counter = counter -  2 * Mathf.PI;
    }
}
