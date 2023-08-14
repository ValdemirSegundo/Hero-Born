using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{

    Character hero = new Character();
    Character hero2 = new Character();
    Character heroine = new Character("Agatha");
    
    Character.Weapon huntingBow = new Character.Weapon("Hunting Bow", 105);
    public Weapon Axe = new Weapon("Axe", 50);

    
    

    // Start is called before the first frame update
    void Start()
    {

        //Paladin Knight = new Paladin("Sir Arthur", huntingBow);

        //Knight.PrintStatsInfo();

        //Paladin Knight = new Paladin("Sir Arthur", Axe);
        //Knight.weapon.PrintWeaponStats();
        //Axe.name = "Sword";
        //Paladin Warrior = new Paladin("Sir William", Axe);
        //Warrior.weapon.PrintWeaponStats();
        //Knight.weapon.PrintWeaponStats();

        //Knight.PrintStatsInfo();
        //Warrior.PrintStatsInfo();


        //Paladin Knight = new Paladin("Sir Arthur", huntingBow);
        //Knight.weapon.PrintWeaponStats();
        //huntingBow.name = "ADIM";
        //Paladin Warrior = new Paladin("Sir William", huntingBow);
        //Warrior.weapon.PrintWeaponStats();
        //Knight.weapon.PrintWeaponStats();

        //Knight.PrintStatsInfo();
        //Warrior.PrintStatsInfo();

        hero2 = hero;
        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();
        hero2.name = "ADIM";
        hero2.exp = 25;
        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();

        //ComputeAge();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GenerateCharacter(string name, int level)
    {
        return level + 5;
    }


    ///<summary>
    ///Computes a modifier age integer
    ///</summary>
    void ComputeAge()
    {
        //Debug.Log($"A string can have variables like {firstName} inserted directly");
        //Debug.LogFormat("Text goes here, add {0} and {1} as variables", currentAge, addedAge);
    }
}
