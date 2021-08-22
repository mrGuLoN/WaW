using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    public int firstExp;
    public int secondExp;
    public int thirdExp;
    private bool thirdBool;
    private PlayerDate pd;
    [SerializeField] private GameObject thirdSkill;
    [SerializeField] private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        firstExp = 0;
        secondExp = 0;
        thirdExp = 0;
        pd = GetComponent<PlayerDate>();
        thirdSkill.SetActive(false);
        thirdBool = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (pd.lvlPoint > 0)
       {
            LvlUp();
       }

       if (firstExp > 0)
       {
            FirstSkill();
       }

       if (secondExp > 0)
       {
            SecondSkill();
       }

       if (thirdExp > 0)
       {
            ThirdSkill();
       }

    }
    void LvlUp()
    {
      
            if (Input.GetKeyDown(KeyCode.F1))
            {
                firstExp++;
                pd.lvlPoint--;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                secondExp++;
                pd.lvlPoint--;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                thirdExp++;
                pd.lvlPoint--;
            }
        
    }

    void FirstSkill()
    {

    }
    void SecondSkill()
    {

    }
    void ThirdSkill()
    {
        thirdSkill.SetActive(true);
        thirdSkill.GetComponent<HP>().factor = thirdSkill.GetComponent<HP>().factor - 0.1f * (thirdExp - 1);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            thirdBool = !thirdBool;
            ani.SetBool("OnOff",thirdBool);
        }
    }
}
