using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Profile",menuName = "SO/Profile")]
public class Profile : ScriptableObject
{
    public Id id;
    public Sprite sprite;
    public string _name;
    
}
