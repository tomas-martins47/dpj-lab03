using UnityEngine;

public interface IDamageable
{
    // A interface IDamageable define o método TakeDamage, que será implementado pela classe PlayerHealth, tornando-o acessível através dessa classe
    void TakeDamage(float amount);
}
