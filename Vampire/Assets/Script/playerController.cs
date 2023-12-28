using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static playerController instance;    // 인스턴스화
    public float movespeed;         //이동속도  
    public float rotationspeed;        // 회전속도

    public Animator anim;
    private void Awake()
    {
        instance = this;               // 시작하자마자 인스턴스
    }
    // Start is called before the first frame update
    void Start()
    {
        //movespeed=PlayerStatCotroller.instance.movespeed[0].value;        //TODO : 나중에 코딩
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveinput = new Vector3(0f, 0f, 0f);
        moveinput.x = Input.GetAxisRaw("Horizontal");
        moveinput.z = Input.GetAxisRaw("Vertical");

        moveinput.Normalize();

        if(moveinput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveinput);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
        }

        transform.position += moveinput * movespeed * Time.deltaTime;
        if(moveinput!=Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
