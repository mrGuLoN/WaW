using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpAndArmor : MonoBehaviour
{
    public float hp = 100;
    public float armor = 100;
    public float dmg = 0;
    public bool haveDmg;
    public float getExp;
    public float getMoney;
    // Start is called before the first frame update
    void Start()
    {
        haveDmg = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (haveDmg == true)
        {
            StartCoroutine(Damage());
        }

        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.01f);
        if (armor<=0)
        {
            hp = hp - dmg;
        }
        else 
        {
            armor = armor - 0.7f * dmg;
            hp = hp - 0.3f * dmg;
        }
        haveDmg = false;
    }
}
