using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para trabalhar com o TextMeshPro


public class PlantioTerreno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject arvorePrefab; // Prefab da �rvore a ser plantada
    public TextMeshProUGUI pontuacaoTexto; // Texto para exibir a pontua��o
    public TextMeshProUGUI sementesTexto; // Texto para exibir o n�mero de sementes
    public AudioSource treePlantingSound; // Refer�ncia ao som de plantio
    public int sementes = 10; // N�mero inicial de sementes
    public int totalArvoresParaVencer = 10; // N�mero necess�rio de �rvores para vencer
    public TextMeshProUGUI textoVitoria; // Texto para exibir a mensagem de vit�ria

    private int pontuacao = 0; // Armazena a pontua��o atual

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && sementes > 0) // Garante que s� acontece no clique do mouse
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject) // Confirma que est� clicando no terreno
            {
                Instantiate(arvorePrefab, mousePos, Quaternion.identity); // Planta a �rvore

                sementes -= 1; //Reduz uma semente
                sementesTexto.text = "Sementes: " + sementes; // Atualiza o texto das sementes

                pontuacao += 1; // Incrementa a pontua��o
                pontuacaoTexto.text = "Pontua��o: " + pontuacao; // Atualiza o texto
                
                treePlantingSound.Play(); // Reproduz o som de plantio
                if (pontuacao >= totalArvoresParaVencer)
                {
                    Vitoria();
                }

            }
        }
    }

    // M�todo para exibir a mensagem de vit�ria
    void Vitoria()
    {
        textoVitoria.text = "Parab�ns! Voc� venceu!";
        Debug.Log("Voc� venceu!"); // Apenas para verificar no console
    }

}
