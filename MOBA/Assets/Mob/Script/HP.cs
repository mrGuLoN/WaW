using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{  
    public float dmg = 0;
    public bool haveDmg = false;
    public float factor;
    public HpAndArmor hpArmor;
    public float getExp;
    public float getMoney;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        dmg = 0;
        getExp = hpArmor.getExp;
        getMoney = hpArmor.getMoney;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hp = hpArmor.hp;
        if (haveDmg == true && dmg !=0)
        {
            hpArmor.dmg = dmg*factor;
            hpArmor.haveDmg = true;
            haveDmg = false;
            Debug.Log("DMG IN!!!");
        }
    }  

}
