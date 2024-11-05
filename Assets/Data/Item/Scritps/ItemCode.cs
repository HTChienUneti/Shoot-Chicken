using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCode
{ 
    NoCode =0,
    X2 = 1,
    Add_1 =2,
    Bullet_Red = 3,
    Bullet_Blue = 4,
    Bullet_Green = 5,
    Bullet_Purple = 6,
    ChickenWing = 7
}
public static class Parse
{
    public static ItemCode StringToItemCode(string str)
    {
        return System.Enum.Parse<ItemCode>(str);
    }   
}

