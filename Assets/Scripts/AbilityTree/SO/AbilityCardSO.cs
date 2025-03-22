using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Card", menuName = "Ability System/Ability Card")]
public class AbilityCardSO : ScriptableObject
{
    public string cardName;          // Kartın Adı
    public string description;       // Açıklama
    public Sprite icon;              // Kart İkonu
    public int minLevel;             // Açılabileceği minimum seviye
    public int maxLevel;             // Açılabileceği maksimum seviye (opsiyonel)
    public AbilityCardSO[] upgrades;   // Bu kartın geliştirme seçenekleri

    public void ApplyUpgrade(PlayerStats playerStats)
    {
        // Örnek: Eğer kart bir saldırı artırımı sağlıyorsa
        if (cardName == "Attack Boost")
        {
            playerStats.IncreaseAttackPower(5);
        }
        else if (cardName == "Speed Boost")
        {
            playerStats.IncreaseMoveSpeed(1.5f);
        }
        // Buraya diğer kart etkilerini ekleyebilirsin
    }
    public void ApplyUpgrade()
    {
        
    }
}
