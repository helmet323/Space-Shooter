using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSelection : MonoBehaviour
{
    //pet selection

    public int PetBool = 0;

    public void PetEnable()
    {
        PlayerPrefs.SetInt("PetBool", 1);
    }

    public void PetReset()
    {
        PlayerPrefs.SetInt("PetBool", 0);
    }
}
