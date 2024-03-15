using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movimentox;
    public float movimentoy;
    public float moveUnitsperSecond = 1f;
    Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentox = Input.GetAxisRaw("Horizontal");
        movimentoy = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveUnitsperSecond * Time.fixedDeltaTime);
    }
}
