using System;
using UnityEngine;

public class Potion : Ingredient<PotionType>
{
    public Potion(PotionType type) : base(type) { }
}