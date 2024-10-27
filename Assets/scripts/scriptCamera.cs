using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject pc;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pc.transform.position.x, pc.transform.position.y + offset, transform.position.z);
    }
}
