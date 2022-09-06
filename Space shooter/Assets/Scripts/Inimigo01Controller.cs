using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{   // pegando o rb
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;
    // meu tiro
    [SerializeField] private GameObject meuTiro;
    // Start is called before the first frame update
    void Start()
    {
        // pegnado o rb
        meuRB = GetComponent<Rigidbody2D>();
        // colocando a velocidade no rb
        meuRB.velocity = new Vector2(0f, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        // Instanciando o tiro
        Instantiate(meuTiro, transform.position, transform.rotation);
    }
}
