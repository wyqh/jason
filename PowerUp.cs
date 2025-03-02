using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Attack,
        Defense,
        Speed,
        Energy
    }
    
    public PowerUpType type;
    public float duration = 10f;
    public float boost = 1.5f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank player = other.GetComponent<PlayerTank>();
            if (player != null)
            {
                ApplyPowerUp(player);
                Destroy(gameObject);
            }
        }
    }
    
    void ApplyPowerUp(PlayerTank player)
    {
        switch (type)
        {
            case PowerUpType.Attack:
                // 增加攻击力
                break;
            case PowerUpType.Defense:
                // 增加防御力
                player.health += 20;
                break;
            case PowerUpType.Speed:
                // 增加速度
                player.moveSpeed *= boost;
                StartCoroutine(ResetSpeed(player));
                break;
            case PowerUpType.Energy:
                // 增加能量
                break;
        }
    }
    
    IEnumerator ResetSpeed(PlayerTank player)
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed /= boost;
    }
} 