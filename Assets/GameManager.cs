using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Dictionary<string, GameObject> MenuUI = new Dictionary<string, GameObject>();
    public GameObject blindPanel;
    public GameObject ScreenPanel;

    //Çö±Ý
    private int money;
    public int Money
    {
        get { return money; }
        set { money = value;  m_View.text = "" + money; }
    }
    //ÀÜ±Ý
    private int banlance;
    public int Banlance
    {
        get { return banlance; }
        set { banlance = value; b_View.text = "" + banlance; }
    }

    public TextMeshProUGUI m_View;
    public TextMeshProUGUI b_View;

    public TMP_InputField inputIF;
    public TMP_InputField outputIF;
    

    public void Awake()
    {
        Init();
    }

    public void InputCash(int value)
    {
        if (Money >= value)
        { Money -= value; Banlance += value;  }
        else 
        {
            ScreenPanel.SetActive(true);
        }
    }

    public void OutputCash(int value)
    {
        if (Banlance >= value)
        { Banlance -= value; Money += value; }
        else
        {
            ScreenPanel.SetActive(true);
        }
    }

    public void IFInputButton()
    {
        InputCash(int.Parse(inputIF.text));
    }

    public void IFOutputButton()
    {
        OutputCash(int.Parse(outputIF.text));
    }

    
    public void OpenMenuUI(string name)
    {
        foreach (var item in MenuUI)
        {
            if (item.Key == name)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    public void ScreenOut()
    {
        ScreenPanel.SetActive(false);
    }

    public void Init()
    {
        blindPanel = GameObject.Find("BlindPanel");
        MenuUI.Add("basic", GameObject.Find("BasicBox"));
        MenuUI.Add("input", GameObject.Find("InputBox"));
        MenuUI.Add("output", GameObject.Find("OutputBox"));

        OpenMenuUI("basic");
        blindPanel.SetActive(false);
        //Debug.Log(MenuUI["basic"].gameObject.name);
        //Infomation
        Money += 100000;
        Banlance += 50000;

    }
}
