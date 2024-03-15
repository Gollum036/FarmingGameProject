using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movimentox;
    public float movimentoy;
    public float movSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentox = Input.GetAxis("Horizontal") * movSpeed;
        movimentoy = Input.GetAxis("Vertical") * movSpeed;
        rb.velocity = new Vector2(movimentox, movimentoy);
    }
}
