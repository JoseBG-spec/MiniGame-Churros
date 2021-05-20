using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChurroBehavior : MonoBehaviour
{
    public GameObject uIChurros;
    public GameObject churroEdit;
    

    private int numerador, denominador;
    public GameObject churroParent;
    public GameObject fraccionParent;
    public GameObject churroBasicoParent,fraccionBasicaParent;
    [SerializeField]
    private GameObject churro,churroVariant;
    [SerializeField]
    private GameObject fraccion,fraccion2;

    //public GameObject[] ordenesActuales = new GameObject[10];
    //public GameObject[] fraccionesOrdenesActuales = new GameObject[10];
    //public GameObject[] churrosActuales = new GameObject[10];
    //public GameObject[] fraccionesChurrosActuales = new GameObject[10];
    private int indiceOrdenes;
    private int indiceChurro;
    public int currentChurroSelected;
    private bool actual;
    private int ronda,puntaje;

    private GameObject churroCreadoRelleno, fraccionCreadaRelleno, churroCreado, fraccionCreada;

    public Text FraccionActualText, OrdenActualText;
    public Fraccion fraccion1;

    [Header("Contador Ingredientes")]
    public Text chocolateContador, cajetaContador, quesoContador, fresaContador;
    private int contadorChocolate, contadorCajeta, contadorQueso, contadorFresa;
    //public GameObject LayoutChurrosOrdenEdit;
    [Header("Puntaje y Rondas")]
    public Text puntajeText,RondaText;
    public GameObject correctoText, incorrectoText;



    private void Start()
    {
        indiceOrdenes = 1;
        indiceChurro = 1;
        ronda = 0;
        puntaje = 0;
        actual = true;
        fraccion1 = GetComponent<Fraccion>();
        
        contadorCajeta = 0;
        contadorChocolate = 0;
        contadorFresa = 0;
        contadorQueso = 0;
        RondaText.text = ronda.ToString();
        puntajeText.text = "0/10";
    }
    private void FixedUpdate()
    {
        if (ronda <= 10 && actual == true)
        {
            resetValues();
            generateBasicChurro();
            generateOrder();
            ronda++;
            RondaText.text = ronda.ToString();
            actual = false;
        }

        fraccionCreada.GetComponent<Text>().text = numerador + "/" + denominador;
        if (churroCreadoRelleno != null)
        {
            FraccionActualText.text = churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator()
                + "/" +
                churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator();

            if (GameObject.FindGameObjectsWithTag("Fraccion").Length != 0)
            {
                GameObject.FindGameObjectsWithTag("Fraccion")[0].GetComponent<Text>().text = churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator()
                + "/" +
                churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator();
            }
        }

    }
    private void resetValues()
    {
        contadorCajeta = 0;
        contadorChocolate = 0;
        contadorFresa = 0;
        contadorQueso = 0;
        chocolateContador.text = contadorChocolate.ToString();
        cajetaContador.text = contadorCajeta.ToString();
        quesoContador.text = contadorQueso.ToString();
        fresaContador.text = contadorFresa.ToString();
    }

    public void generateOrder()
    {
        if (indiceOrdenes == 1)
        {
            numerador = Random.Range(1, 10);
            denominador = Random.Range(1, 10);

            Debug.Log(numerador + "/" + denominador);
            int[] fr = fraccion1.lowestDenNum(numerador, denominador);
            numerador = fr[0];
            denominador = fr[1];

            fraccion2.GetComponent<Text>().text = fr[0] + "/" + fr[1];
            churroCreado = Instantiate(churroVariant, churroParent.GetComponent<Transform>());
            fraccionCreada = Instantiate(fraccion2, fraccionParent.GetComponent<Transform>());
            churroCreado.GetComponent<Churro>().setID(indiceOrdenes);
            churroCreado.GetComponent<Churro>().setFractionNumerator(fr[0]);
            churroCreado.GetComponent<Churro>().setFractionDenominator(fr[1]);
            //ordenesActuales[indiceOrdenes] = churroCreado;
            //fraccionesOrdenesActuales[indiceOrdenes] = fraccionCreada;
            indiceOrdenes--;
        }
        else
        {
            indiceOrdenes = 0;
        }

    }
    public void generateBasicChurro()
    {
        if (indiceChurro !=0)
        {
            fraccion.GetComponent<Text>().text = 1 + "/" + 1;
            churroCreadoRelleno = Instantiate(churro, churroBasicoParent.GetComponent<Transform>());
            fraccionCreadaRelleno = Instantiate(fraccion, fraccionBasicaParent.GetComponent<Transform>());
            churroCreadoRelleno.GetComponent<Churro>().setID(indiceChurro);
            churroCreadoRelleno.GetComponent<Churro>().setFractionNumerator(1);
            churroCreadoRelleno.GetComponent<Churro>().setFractionDenominator(1);
            //churrosActuales[indiceChurro] = churroCreado;
            //fraccionesChurrosActuales[indiceChurro] = fraccionCreada;
            indiceChurro--;
            churroCreadoRelleno.GetComponent<Button>().onClick.AddListener(EditChurro);
        }
    }

    public void removeChurro()
    {
        if (indiceChurro == 0)
        {
            Destroy(churroCreadoRelleno);
            Destroy(fraccionCreadaRelleno);
            GoBackOrden();
            indiceChurro++;
        }
    }
    public void removeOrden()
    {
        if (indiceOrdenes == 0)
        {
            Destroy(churroCreado);
            Destroy(fraccionCreada);
            indiceOrdenes++;
        }
    }
    public void AddToChurro(string y)
    {
        string[] fraccion2 = y.Split('/');
        int num2 = int.Parse(fraccion2[0]);
        int den2 = int.Parse(fraccion2[1]); 
        int num1 = churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator();
        int den1 = churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator();

        int[] fr = fraccion1.addFraction(num1, den1, num2, den2);
        churroCreadoRelleno.GetComponent<Churro>().setFractionNumerator(fr[0]);
        churroCreadoRelleno.GetComponent<Churro>().setFractionDenominator(fr[1]);
    }

    public void AddToContador(int cont)
    {
        switch (cont)
        {
            case 1:
                contadorChocolate++;
                chocolateContador.text = contadorChocolate.ToString();
                break;
            case 2:
                contadorCajeta++;
                cajetaContador.text = contadorCajeta.ToString();
                break;
            case 3:
                contadorQueso++;
                quesoContador.text = contadorQueso.ToString();
                break;
            case 4:
                contadorFresa++;
                fresaContador.text = contadorFresa.ToString();
                break;
        }
    }

    public void RemoveToContador(int cont)
    {
        Debug.Log(churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator() + " "+
            churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator());
        if (churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator() > 0
            && churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator() > 0)
        {
            switch (cont)
            {
                case 1:
                    contadorChocolate--;
                    chocolateContador.text = contadorChocolate.ToString();
                    break;
                case 2:
                    contadorCajeta--;
                    cajetaContador.text = contadorCajeta.ToString();
                    break;
                case 3:
                    contadorQueso--;
                    quesoContador.text = contadorQueso.ToString();
                    break;
                case 4:
                    contadorFresa--;
                    fresaContador.text = contadorFresa.ToString();
                    break;
            }
        }
    }

    public void RemoveToChurro(string y)
    {
        if (churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator() > 0
            && churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator() > 0)
        {
            string[] fraccion2 = y.Split('/');
            int num2 = int.Parse(fraccion2[0]);
            int den2 = int.Parse(fraccion2[1]);
            int num1 = churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator();
            int den1 = churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator();

            int[] fr = fraccion1.substractFraction(num1, den1, num2, den2);
            churroCreadoRelleno.GetComponent<Churro>().setFractionNumerator(fr[0]);
            churroCreadoRelleno.GetComponent<Churro>().setFractionDenominator(fr[1]);
        }

    }

    public void EditChurro()
    {
        uIChurros.SetActive(false);
        churroEdit.SetActive(true);
        OrdenActualText.text = numerador + "/" + denominador;
        
    }

    public void GoBackOrden()
    {
        uIChurros.SetActive(true);
        churroEdit.SetActive(false);
        
    }

    public void DeliverChurro()
    {
        if(churroCreadoRelleno.GetComponent<Churro>().getFractionNumerator() == numerador
            && churroCreadoRelleno.GetComponent<Churro>().getFractionDenominator() == denominador)
        {
            incorrectoText.SetActive(false);
            correctoText.SetActive(true);
            puntaje++;
            puntajeText.text = puntaje.ToString() + "/10";
            
        }
        else
        {
            correctoText.SetActive(false);
            incorrectoText.SetActive(true);
        }
        removeChurro();
        removeOrden();
        actual = true;

        GoBackOrden();

    }
}
