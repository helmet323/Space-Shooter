using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSkillSelection : MonoBehaviour
{
    public int Skill1Bool = 0;
    public int Skill2Bool = 0;
    public int Skill3Bool = 0;
    public int Skill4Bool = 0;

    public void PetSkill1()
    {
        PlayerPrefs.SetInt("Skill1Bool", 1);
        PlayerPrefs.SetInt("Skill2Bool", 0);
        PlayerPrefs.SetInt("Skill3Bool", 0);
        PlayerPrefs.SetInt("Skill4Bool", 0);
    }

    public void PetSkill2()
    {
        PlayerPrefs.SetInt("Skill1Bool", 0);
        PlayerPrefs.SetInt("Skill2Bool", 1);
        PlayerPrefs.SetInt("Skill3Bool", 0);
        PlayerPrefs.SetInt("Skill4Bool", 0);
    }
    public void PetSkill3()
    {
        PlayerPrefs.SetInt("Skill1Bool", 0);
        PlayerPrefs.SetInt("Skill2Bool", 0);
        PlayerPrefs.SetInt("Skill3Bool", 1);
        PlayerPrefs.SetInt("Skill4Bool", 0);
    }
    public void PetSkill4()
    {
        PlayerPrefs.SetInt("Skill1Bool", 0);
        PlayerPrefs.SetInt("Skill2Bool", 0);
        PlayerPrefs.SetInt("Skill3Bool", 0);
        PlayerPrefs.SetInt("Skill4Bool", 1);
    }
    

    public void PetSkillReset()
    {
        PlayerPrefs.SetInt("Skill1Bool", 0);
        PlayerPrefs.SetInt("Skill2Bool", 0);
        PlayerPrefs.SetInt("Skill3Bool", 0);
        PlayerPrefs.SetInt("Skill4Bool", 0);
    }
}
