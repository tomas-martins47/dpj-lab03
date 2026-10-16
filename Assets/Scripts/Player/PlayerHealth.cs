using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{   
    [SerializeField] private PlayerStats playerStats;
    private PlayerAnimations playerAnimations;

    public void TakeDamage(float amount)
    {
        playerStats.health -= amount;
        if (playerStats.health <= 0)
        {
            PlayerDead();
            Debug.Log("Jogador Derrotado");
        }
    }

    private void PlayerDead() { playerAnimations.SetDeadAnimation(); }

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update() 
    {   
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }
}
