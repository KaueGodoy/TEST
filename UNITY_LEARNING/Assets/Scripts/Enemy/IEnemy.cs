public interface IEnemy
{
    public int ID { get; } // Unique identifier for the enemy
    public string Name { get; } // Name of the enemy
    public float CurrentHealth { get; } // Current health of the enemy
    public float MaxHealth { get; } // Maximum health of the enemy
    public bool IsDead { get; } // Indicates if the enemy is dead
    public bool IsAlive { get; } // Indicates if the enemy is alive
    public bool IsDamaged { get; } // Indicates if the enemy has taken damage recently

    public void TakeDamage(float amount); // Apply damage to the enemy
    public void DealDamage(float amount); // Deal damage to the player
}

