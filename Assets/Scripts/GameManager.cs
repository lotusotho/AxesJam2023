using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public List<string> requiredIngredients;

    public int points;

    public ClientBehaviour currentClient;

    public CookingPlate cookingPlate;

    public RecipeDatabase RecipeDatabase;

    public PlayerBehaviour PlayerBehaviour;

    public List<GameObject> completeRecipes;

    public TextMeshProUGUI score;

    public Canvas perderCanvas;

    [SerializeField]
    private GameObject[] clientes;

    private int clientRand;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RecipeDatabase database = new RecipeDatabase();
        
        requiredIngredients = database.recipes[currentClient.NumeroPedido];
        cookingPlate.SetRequiredIngredients(requiredIngredients);
        cookingPlate.SetFinishedRecipe(completeRecipes[currentClient.NumeroPedido-1]);
        score.text = "0";

    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("cliente") == null)
        {
            clientRand = UnityEngine.Random.Range(0, 2);
            currentClient = Instantiate(clientes[clientRand]).GetComponent<ClientBehaviour>();
        }

        if (currentClient.PedidoRelizado)
        {
            clientRand = UnityEngine.Random.Range(0, 2);
            currentClient = Instantiate(clientes[clientRand]).GetComponent<ClientBehaviour>();
            GameObject _destroyclient = GameObject.FindGameObjectWithTag("cliente");
            Destroy(_destroyclient);
            currentClient.PedidoRelizado = false;
        }

        if (GameObject.FindGameObjectsWithTag("cliente").Length > 1)
        {
            foreach(GameObject cliente in GameObject.FindGameObjectsWithTag("cliente"))
            {
                Destroy(cliente);
            }
        }
    }

    public void AddPoints()
    {
        score.text = int.Parse(score.text) + 50 + "" ;
    }

    public void FinishGame()
    {
        perderCanvas.gameObject.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("AleTestProg");
    }

}
