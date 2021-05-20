using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Pantallas")]
    public GameObject pantallaInicio;
    public GameObject uIChurros;
    public GameObject churroEdit;
    
    // Start is called before the first frame update
    void Start()
    {
        pantallaInicio.SetActive(true);
        uIChurros.SetActive(false);
        churroEdit.SetActive(false);
    }

    public void StartGame()
    {
        pantallaInicio.SetActive(false);
        uIChurros.SetActive(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
