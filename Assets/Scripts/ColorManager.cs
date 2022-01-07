using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager
{
    //色の計算を扱うクラス
    public static Color MixtureColor(Color c1, Color c2)
    {
        Color resultColor;
        resultColor = c1 + c2;
        if (resultColor.r > 1f) resultColor.r = 1f;
        if (resultColor.g > 1f) resultColor.g = 1f;
        if (resultColor.b > 1f) resultColor.b = 1f;
        return resultColor;
    }

    public static bool IsSameColor(Color c1, Color c2)
    {
        if (Mathf.Abs(c1.r - c2.r) >= 0.5f) return false;
        if (Mathf.Abs(c1.g - c2.g) >= 0.5f) return false;
        if (Mathf.Abs(c1.b - c2.b) >= 0.5f) return false;
        return true;
    }
}
