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

    public Sprite GetSprite(int test)
    {
        return GetRandomSpriteFromSet(_variations_Plus);
    }

    private Sprite GetRandomSpriteFromSet(Sprite[] spriteSet)
    {
        return spriteSet[Random.Range(0, spriteSet.Length - 1)];
    }
}
