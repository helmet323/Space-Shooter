using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelection : MonoBehaviour
{

    public int ShipOneBool = 0;
    public int ShipTwoBool = 0;

    public void ShipOne()
    {
        PlayerPrefs.SetInt("ShipOneBool", 1);
        PlayerPrefs.SetInt("ShipTwoBool", 0);
    }

    public void ShipTwo()
    {
        PlayerPrefs.SetInt("ShipTwoBool", 1);
        PlayerPrefs.SetInt("ShipOneBool", 0);

    }

    public void Reset()
    {
        PlayerPrefs.SetInt("ShipOneBool", 0);
        PlayerPrefs.SetInt("ShipTwoBool", 0);
    }

}
