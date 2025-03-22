using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{//eski so ile işlem yapıldı silinebilir
    public List<AbilityCardSO> availableCards = new(); // Mevcut seçilebilir kartlar
    public Transform uiParent; // Kartları UI'de göstermek için
    public GameObject cardUIPrefab; // Kart UI prefabı
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void ShowUpgradeOptions()
    {
        List<AbilityCardSO> selectedCards = new();

        // 3 rastgele kart seç
        while (selectedCards.Count < 3 && availableCards.Count > 0)
        {
            AbilityCardSO randomCard = availableCards[Random.Range(0, availableCards.Count)];

            if (!selectedCards.Contains(randomCard)) 
                selectedCards.Add(randomCard);
        }

        // UI'de göster
        foreach (AbilityCardSO card in selectedCards)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, uiParent);
            cardUI.GetComponent<CardUI>().Setup(card, this);
        }
    }

    public void SelectCard(AbilityCardSO selectedCard)
    {
        selectedCard.ApplyUpgrade(playerStats);

        // Yeni kart seçeneklerini güncelle (önceki kartın linkedCards listesini dahil et)
        availableCards.Clear();
        availableCards.AddRange(selectedCard.upgrades);

        // UI'yi temizle ve yeni kartları göster
        foreach (Transform child in uiParent) 
        {
            Destroy(child.gameObject);
        }

        ShowUpgradeOptions();
    }
}
