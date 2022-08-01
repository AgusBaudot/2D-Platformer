using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
