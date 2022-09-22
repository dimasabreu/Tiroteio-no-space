using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody2D meuRB;
    
    // Start is called before the first frame update
    void Start()
    {
        // pegnado o rb
        meuRB = GetComponent<Rigidbody2D>();
        // colocando a velocidade no rb
        var vel = Random.Range(-2f, 2f);
        meuRB.velocity = new Vector2(vel, vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // checando se eu colidi com o player
        if (other.gameObject.CompareTag("Jogador"))
        {
            other.gameObject.GetComponent<PlayerController>().Upando(1);
            Destroy(gameObject);
        }
    }
}
