using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraccion : MonoBehaviour
{
    int den3, num3;

    public int gcd(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }
        return gcd(b % a, a);
    }

    public int[] addFraction(int num1, int den1, int num2, int den2)
    {

        den3 = gcd(den1, den2);

        den3 = (den1 * den2) / den3;

        num3 = (num1) * (den3 / den1) +
                (num2) * (den3 / den2);
        int[] yes= lowest();

        return yes;
    }

    public int[] substractFraction(int num1, int den1, int num2, int den2)
    {
        den3 = gcd(den1, den2);

        den3 = (den1 * den2) / den3;

        num3 = (num1) * (den3 / den1) -
                (num2) * (den3 / den2);
        int[] yes = lowest();

        return yes;
    }

    public int[] lowest()
    {
        int common_factor = gcd(num3, den3);

        den3 = den3 / common_factor;
        num3 = num3 / common_factor;

        int[] yes = { num3, den3 };
        return yes;
    }
    public int[] lowestDenNum(int num, int den)
    {
        int common_factor = gcd(num, den);

        den = den / common_factor;
        num = num / common_factor;

        int[] yes = { num, den };
        return yes;
    }
}
