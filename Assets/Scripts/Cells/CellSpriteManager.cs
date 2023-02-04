using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _variations_Plus;
    [SerializeField] private Sprite[] _variations_L;
    [SerializeField] private Sprite[] _variations_I;
    [SerializeField] private Sprite[] _variations_T;
    [SerializeField] private Sprite[] _variations_Seed;
    [SerializeField] private Sprite[] _variations_Empty;

    public enum Shape { Plus, L, I, T, Seed, Empty };

    public Sprite GetSprite(Shape shape)
    {
        if (shape == Shape.L) return GetRandomSpriteFromSet(_variations_L);
        else if (shape == Shape.I) return GetRandomSpriteFromSet(_variations_I);
        else if (shape == Shape.T) return GetRandomSpriteFromSet(_variations_T);
        else if (shape == Shape.Seed) return GetRandomSpriteFromSet(_variations_Seed);
        else if (shape == Shape.Plus) return GetRandomSpriteFromSet(_variations_Plus);
        else return null;
    }

    private Sprite GetRandomSpriteFromSet(Sprite[] spriteSet)
    {
        if (spriteSet.Length == 0) return null;
        return spriteSet[Random.Range(0, spriteSet.Length - 1)];
    }
}
