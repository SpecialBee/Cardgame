using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalDamage
{
    private static readonly float[,] damageMatrix = new float[,]
    {
        // Fire, Earth, Wind, Water, Holy
        { 1.0f, 1.0f, 2.0f, 0.5f, 1.0f },  // Fire
        { 1.0f, 1.0f, 0.5f, 2.0f, 1.0f },  // Earth
        { 0.5f, 2.0f, 1.0f, 1.0f, 1.0f },  // Wind
        { 2.0f, 0.5f, 1.0f, 1.0f, 1.0f },  // Water
        { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f }   // Holy
    };

    public static float GetDamageMultiplier(Element attacker, Element defender)
    {
        return damageMatrix[(int)attacker, (int)defender];
    }
}
