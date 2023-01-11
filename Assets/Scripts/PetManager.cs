using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject pet;
    public int PetBool;
    // Start is called before the first frame update
    void Start()
    {
        PetBool = PlayerPrefs.GetInt("PetBool", PetBool);

        if (PetBool == 1)
        {
            pet.SetActive(true);
            
        }
    }


}
