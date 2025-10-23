using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Experience : MonoBehaviour
{
    public int level = 1;
    public int CurrentExp;
    public int XpToNextLevel = 10;
    public GameObject experiencepointPrefab;
    public float ExpGrowMultiplier = 1.2f;
    public TMP_Text CurrentLevelText;
    public Slider  expSlider;
    public UpgradeMenu upgradeMenu;
  


    void start()
    {
        UpdateUI();
       
    }
    
    
    public void ExperiencePoint(int amount)
    {
        CurrentExp += amount;
        if (CurrentExp >= XpToNextLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        Debug.Log("You level up !");
        CurrentExp -=  XpToNextLevel;
        XpToNextLevel = Mathf.RoundToInt(XpToNextLevel * ExpGrowMultiplier);
        upgradeMenu.UpgradeMenuOpen();
    }

    private void OnEnable()
    {
        experiencepoint.OnEnnemiDefeated += ExperiencePoint;
    }
    private void OnDisable()
    {
        experiencepoint.OnEnnemiDefeated -= ExperiencePoint;
    }

    public void UpdateUI()
    {
        expSlider.maxValue = XpToNextLevel;
        expSlider.value = CurrentExp;
		CurrentLevelText.text="Level: " + level;
	}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExperiencePoint(2);
        }
    }

    

    
}
