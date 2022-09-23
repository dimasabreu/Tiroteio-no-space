using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody2D meuRB;
    private Color minhacor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // pegnado o rb
        meuRB = GetComponent<Rigidbody2D>();
        // colocando a velocidade no rb
        var vel = Random.Range(-1f, 1f);
        meuRB.velocity = new Vector2(vel, vel);
        Trocacor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Trocacor()
    {
        var chance = Random.Range(0f, 1f);
        if(chance <= 1 && chance > 0.7)
        {
            minhacor = GetComponent<Renderer>().material.color = Color.yellow;
        }
        if(chance <= 0.7 && chance > 0.5)
        {
            minhacor = GetComponent<Renderer>().material.color = Color.red;
        }
        if(chance <= 0.5)
        {
            minhacor = GetComponent<Renderer>().material.color = Color.cyan;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        // checando se eu colidi com o player
        if (other.gameObject.CompareTag("Jogador"))
        {
            if (minhacor == Color.yellow)
            {       
                other.gameObject.GetComponent<PlayerController>().Upando(1);
                Destroy(gameObject);
            }
            if (minhacor == Color.red)
            {       
                other.gameObject.GetComponent<PlayerController>().Curando(1);
                Destroy(gameObject);
            }
            if (minhacor == Color.cyan)
            {       
                other.gameObject.GetComponent<PlayerController>().ganhaVelo(1);
                Destroy(gameObject);
            }


        }
    }
}
