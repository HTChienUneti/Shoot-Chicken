using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Id
{ 
    NoCode =0,
    X2 = 1,
    Add_1 =2,
    Bullet_Red = 3,
    Bullet_Blue = 4,
    Bullet_Green = 5,
    Bullet_Purple = 6,
    Spaceship,
    Bullet_1
}
public static class Parse
{
    public static Id StringToItemCode(string str)
    {
        return System.Enum.Parse<Id>(str);
    }   
}

