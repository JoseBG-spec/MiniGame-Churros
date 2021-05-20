using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Churro : MonoBehaviour
{
    [SerializeField]
    private int id;
    private int fractionNumerator;
    private int fractionDenominator;
    private string relleno;
    public Churro(){
    }
    public void setID(int id)
    {
        this.id = id;
    }
    public int getID()
    {
        return id;
    }
    public void setFractionNumerator(int fractionNumerator)
    {
        this.fractionNumerator = fractionNumerator;
    }
    public int getFractionNumerator()
    {
        return fractionNumerator;
    }
    public void setFractionDenominator(int fractionDenominator)
    {
        this.fractionDenominator = fractionDenominator;
    }
    public int getFractionDenominator()
    {
        return fractionDenominator;
    }
    public void setRelleno(string relleno)
    {
        this.relleno = relleno;
    }
    public string getRelleno()
    {
        return relleno;
    }

}
