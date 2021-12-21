using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Material Black, Blue, Yellow, Orange, Red, Green, Purple, White;
    public enum Color
    {
        Black, Blue, Yellow, Orange, Red, Green, Purple, White
    }
    
    public Material GetMaterial(int color)
    {
        switch (color)
        {
            case (int)Color.Black:
                return Black;
            case (int)Color.Blue:
                return Blue;
            case (int)Color.Green:
                return Green;
            case (int)Color.Purple:
                return Purple;
            case (int)Color.Red:
                return Red;
            case (int)Color.White:
                return White;
            case (int)Color.Yellow:
                return Yellow;
            case (int)Color.Orange:
                return Yellow;
            default:
                return Black;
        }
    }
}
