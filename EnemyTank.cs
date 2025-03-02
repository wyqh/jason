using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float fireRate = 2f;
    public int health = 50;
    
    private Transform target;
    private Transform baseTarget;
    private float nextFireTime = 0f;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        baseTarget = GameObject.FindGameObjectWithTag("Base").transform;
    }
    
    void Update()
    {
        // 简单的AI逻辑：在玩家和基地之间选择目标
        Transform currentTarget = Random.value > 0.7f ? baseTarget : target;
        
        // 朝向目标移动
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // 旋转面向目标
        transform.rotation = Quaternion.LookRotation(direction);
        
        // 射击逻辑
        if (Time.time >= nextFireTime)
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
            GameManager.Instance.remainingEnemies--;
            Destroy(gameObject);
        }
    }
} 