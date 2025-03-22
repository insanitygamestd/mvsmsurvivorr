using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public UpgradeManager upgradeManager;
    public static LevelSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GainExperience(int amount)
    {
        experience += amount;

        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        experience = 0;
        experienceToNextLevel += 50; // Zorluk artsın

        upgradeManager.ShowUpgradeOptions(); // Kart seçim ekranını aç
    }
}
