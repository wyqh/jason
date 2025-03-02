using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float fireRate = 1f;
    public int health = 100;
    
    private float nextFireTime = 0f;

    void Update()
    {
        // 移动控制
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        // 前后移动
        transform.Translate(Vector3.forward * moveVertical * moveSpeed * Time.deltaTime);
        
        // 左右旋转
        transform.Rotate(Vector3.up * moveHorizontal * rotationSpeed * Time.deltaTime);
        
        // 射击控制
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    void Fire()
    {
        // 这里需要预制件引用
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        GameManager.Instance.isGameOver = true;
        // 处理游戏结束逻辑
    }
} 