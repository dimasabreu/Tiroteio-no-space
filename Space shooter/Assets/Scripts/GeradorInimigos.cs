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
    [SerializeField] public int level = 1;

    // tanto para lvl up
    [SerializeField] private float levelUp = 100;

    // quantidade de inimigos
    [SerializeField] private int qtdInimigo = 0;

    private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 5f;

    // criando o bg
    [SerializeField] private GameObject[] fundo;
    private int qtdFundo = 0;

    //criando o boss
    [SerializeField] private GameObject bossAnimation;
    private bool animacaoBoss = false;
    private GameObject animBoss;
    
    // acessando os inimigos
    public Inimigo01Controller Inimigo01script;
    public Inimigo02controller Inimigo02script;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level < 10)
        {
            GeraInimigos();
        }
        else
        {
            criaBoss();
        }
        geraFundo();
        
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos;
        if(this.pontos >= levelUp)
        {
            level++;
            levelUp = (levelUp * level) / 1.5f;
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
                    Inimigo01script.vida = 1;
                    Inimigo01script.pontos = 10;
                    if (level == 2)
                    {
                        Inimigo01script.vida = 2;
                        Inimigo01script.pontos = 15;
                    }
                    if (level >= 3)
                    {
                        Inimigo01script.vida = 3;
                        Inimigo01script.pontos = 20;
                    }
                }
                else
                {
                    inimigoCriado = inimigos[1];
                    Inimigo02script.vida = 1;
                    Inimigo02script.pontos = 15;
                    if (level == 3)
                    {
                        Inimigo02script.vida = 2;
                        Inimigo02script.pontos = 20;
                    }
                    if (level >= 4)
                    {
                        Inimigo02script.vida = 3;
                        Inimigo02script.pontos = 25;
                    }
                }

                // posiccao do inimigo
                Vector3 posicao = new Vector3(Random.Range(-8.4f, 8.40f), Random.Range(6f, 17f), 0f);
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

    private void criaBoss()
    {
        if ( qtdInimigo <= 0 && tempoEspera > 0)
        {
            tempoEspera -= Time.deltaTime;
        }

        
        if(!animacaoBoss && tempoEspera <= 0)
        {
            animBoss = Instantiate(bossAnimation, Vector3.zero, transform.rotation);
            animacaoBoss = true;
            Destroy(animBoss, 5.31f);
        }
        
    }

}
