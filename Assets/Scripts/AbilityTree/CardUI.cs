using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Text descriptionText;
    public Image iconImage;
    private AbilityCardSO abilityCard;
    private UpgradeManager upgradeManager;

    public void Setup(AbilityCardSO card, UpgradeManager manager)
    {
        abilityCard = card;
        upgradeManager = manager;
        cardNameText.text = card.cardName;
        descriptionText.text = card.description;
        iconImage.sprite = card.icon;
    }

    public void OnCardSelected()
    {
        upgradeManager.SelectCard(abilityCard);
    }

    public void SetCard(AbilityCardSO card)
    {
        abilityCard = card;
        cardNameText.text = card.cardName;
        descriptionText.text = card.description;
        iconImage.sprite = card.icon;
    }

}
