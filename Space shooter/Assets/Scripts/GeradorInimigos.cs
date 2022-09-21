using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    // pegando os inimigos que vão ser criados
    [SerializeField] private GameObject[] inimigos;

    // pegando os pontos q os inimigos dao
    [SerializeField] private int pontos = 0;

    // level
    [SerializeField] private int level = 1;

    // tanto para lvl up
    [SerializeField] private int levelUp = 100;

    // quantidade de inimigos
    [SerializeField] private int qtdInimigo = 0;

    private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 5f;

    // criando o bg
    [SerializeField] private GameObject[] fundo;
    private int qtdFundo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
        geraFundo();
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos;
        if(this.pontos >= levelUp)
        {
            level++;
            levelUp = levelUp * level;
        }
    }

    // checando a quantidade de inimigos
    public void DiminuiQuantidade()
    {
        qtdInimigo--;
    }

    private void GeraInimigos()
    {
        // diminuindo o tempo de espera
        if (esperaInimigo > 0)
        {
            esperaInimigo -= Time.deltaTime;
        }
        // checando o tempo de espera
        if (esperaInimigo <= 0f && qtdInimigo <= 0)
        {
            int quantidade = level * 4;
            
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

    private void geraFundo()
    {
        if(level == 1)
        {
            qtdFundo++;
            if ( qtdFundo == 1)
            {
                Vector3 posicaoFundo = new Vector3(0f, 6f, 0f);
                Instantiate(fundo[0], posicaoFundo, transform.rotation);
                
            }
        }
    }
}
