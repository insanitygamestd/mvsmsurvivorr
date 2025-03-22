using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int attackPower = 10;
    public float moveSpeed = 5f;
    public int maxHealth = 100;

    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power Increased: " + attackPower);
    }

    public void IncreaseMoveSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log("Move Speed Increased: " + moveSpeed);
    }
}
