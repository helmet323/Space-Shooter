using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject ShipOne;
    public GameObject ShipTwo;
    public GameObject ShipTwoAmmo;

    public int ShipOneBool;
    public int ShipTwoBool;
    // Start is called before the first frame update
    void Start()
    {
        ShipOneBool = PlayerPrefs.GetInt ("ShipOneBool", ShipOneBool);
        ShipTwoBool = PlayerPrefs.GetInt ("ShipTwoBool", ShipTwoBool);

        if (ShipOneBool == 1)
        {
            ShipOne.SetActive(true);
            
        }
        else if(ShipTwoBool == 1)
        {
            ShipTwo.SetActive(true);
            ShipTwoAmmo.SetActive(true);
        }

        if (ShipOneBool == 0 && ShipTwoBool == 0)
        {
            ShipOne.SetActive(true);
        }

    }

}
