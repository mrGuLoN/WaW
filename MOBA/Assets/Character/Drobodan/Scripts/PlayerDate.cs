using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour
{
    public float exp;
    public int money;
    private int lvl;
    public int lvlPoint;
    public float reloadSkill;
    public float reloadSkillArmor;
    
    // Start is called before the first frame update
    void Start()
    {
        exp = 0;
        money = 0;
        lvlPoint = 1;
        reloadSkillArmor = 100;
        reloadSkill = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= 50 * (exp+1) && lvl < 20)
        {
            lvl++;
            lvlPoint++;
        }       
       
    }    

}
