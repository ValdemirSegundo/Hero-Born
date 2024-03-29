using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
    public string name;
    public int exp = 0;


    public struct Weapon
    {
        public string name;
        public int damage;
        
        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public void PrintWeaponStats()
        {
            Debug.LogFormat("Weapon: {0} - {1} DMB", name, damage);
        }
    }

    public Character()
    {
        name = "Not Assigned";
    }
    public Character(string name)
    {
        this.name = name;
    }

    public Character(string name, int exp)
    {
        this.name = name;
        this.exp = exp;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} EPX", name, exp);
    }

    private void Reset()
    {
        this.name = "Not assigned ";
        this.exp = 0;
    }

    

}
