using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour
    
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<playerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 6.0f, target.position.z - 5.0f);
    }
}
