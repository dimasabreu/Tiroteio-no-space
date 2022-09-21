using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    // pegando os inimigos que vão ser criados
    [SerializeField] private GameObject[] inimigos;

    // pegando os pontos q os inimigos dao
    private int pontos = 0;
    [SerializeField] private int level = 1;

    private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
    }

    private void GeraInimigos()
    {
        // diminuindo o tempo de espera
        if (esperaInimigo > 0)
        {
            esperaInimigo -= Time.deltaTime;
        }
        // checando o tempo de espera
        if (esperaInimigo <= 0f)
        {
            int quantidade = level * 4;
            int qtdInimigo = 0;
            // criando varios inimigos
            while(qtdInimigo < quantidade)
            {
                GameObject inimigoCriado;
                // dicidindo qual inimigo criar
                float chance = Random.Range(0f, level);
                if (chance < 2f)
                {
                    inimigoCriado = inimigos[0];
                }
                else
                {
                    inimigoCriado = inimigos[1];
                }

                // posiccao do inimigo
                Vector3 posicao = new Vector3(Random.Range(-10f, 9f), Random.Range(6f, 17f), 0f);
                // criando o inimigo
                Instantiate(inimigoCriado, posicao, transform.rotation);
                qtdInimigo++;

                // reiniciando a espera
                esperaInimigo = tempoEspera;
            }
        }
    }
}
