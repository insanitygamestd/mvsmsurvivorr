using System.Collections.Generic;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public static CardSelectionManager instance;
    public GameObject cardSelectionUI;
    public Transform cardContainer;
    public GameObject cardPrefab;
    public List<AbilityCardSO> allCards;
    private List<AbilityCardSO> unlockedCards = new List<AbilityCardSO>();
    private int currentLevel;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShowUpgradeOptions(int level)
    {
        cardSelectionUI.SetActive(true);
        currentLevel = level;

        foreach (Transform child in cardContainer)
        {
            Destroy(child.gameObject);
        }

        AbilityCardSO[] selectedCards = GetRandomCards();
        foreach (AbilityCardSO card in selectedCards)
        {
            GameObject newCard = Instantiate(cardPrefab, cardContainer);
            CardUI cardUI = newCard.GetComponent<CardUI>();
            cardUI.SetCard(card);
        }
    }

    public AbilityCardSO[] GetRandomCards()
    {
        List<AbilityCardSO> availableCards = new List<AbilityCardSO>();
        List<AbilityCardSO> upgradeCandidates = new List<AbilityCardSO>();

        foreach (AbilityCardSO card in allCards)
        {
            if (card.minLevel == currentLevel && !unlockedCards.Contains(card))
            {
                availableCards.Add(card);
            }
        }

        foreach (AbilityCardSO selected in unlockedCards)
        {
            foreach (AbilityCardSO upgrade in selected.upgrades)
            {
                if (upgrade.minLevel == currentLevel)
                {
                    upgradeCandidates.Add(upgrade);
                }
            }
        }

        List<AbilityCardSO> finalSelection = new List<AbilityCardSO>();

        for (int i = 0; i < 3; i++)
        {
            if (upgradeCandidates.Count > 0 && Random.value < 0.7f)
            {
                AbilityCardSO chosenUpgrade = upgradeCandidates[Random.Range(0, upgradeCandidates.Count)];
                finalSelection.Add(chosenUpgrade);
                upgradeCandidates.Remove(chosenUpgrade);
            }
            else if (availableCards.Count > 0)
            {
                AbilityCardSO chosenNew = availableCards[Random.Range(0, availableCards.Count)];
                finalSelection.Add(chosenNew);
                availableCards.Remove(chosenNew);
            }
        }

        return finalSelection.ToArray();
    }

    public void SelectCard(AbilityCardSO selectedCard)
    {
        unlockedCards.Add(selectedCard);
        selectedCard.ApplyUpgrade();
        cardSelectionUI.SetActive(false);
    }
}