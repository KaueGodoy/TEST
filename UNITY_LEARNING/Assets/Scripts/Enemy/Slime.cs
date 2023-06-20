using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }
    public bool IsDead { get; private set; }
    public bool IsAlive { get; private set; }
    public bool IsDamaged { get; private set; }

    /// <summary>
    /// In summary, the code demonstrates various ways
    /// to create instances of the Slime class, 
    /// assign values to its properties, 
    /// and log the property values to the console using Debug.Log().
    /// </summary>
    private void Awake()
    {
        ID = 1;

        // local variable
        int slimeId = ID;

        Debug.Log(slimeId + "Slime id variable");
        Debug.Log(ID);

        MaxHealth = 100f;
        Debug.Log(MaxHealth);

        CurrentHealth = MaxHealth;
        Debug.Log(CurrentHealth);

        // Rest of the code...

        // Fixing monobehavior warning message (cant create new Class it being a monobehavior)

        // The error message occurs because you are trying to create a new instance of a MonoBehaviour-derived class (Slime) using the new keyword,
        // which is not allowed in Unity. MonoBehaviour scripts should not be instantiated using the new keyword
        // because Unity manages their lifecycle and instantiation when they are attached to GameObjects.

        // To resolve this issue, you can remove the line Slime slime = new Slime(); from your Start() method,
        // as you don't need to explicitly create a new instance of the Slime class within that method.
        // Since the Start() method is within the Slime script, you can directly access and modify the properties
        // of the script without creating a new instance.

        // By accessing the properties directly without creating a new instance,
        // you can assign values to the properties and log them without triggering the error message.

    }


    private void Start()
    {
        // way 01

        /* The code creates an instance of the Slime class using the default constructor: Slime slime = new Slime();
         * assign values to its properties
         */

        Slime slime = new Slime();
        slime.ID = 1;

        // local variable
        int slimeId = slime.ID;

        /*
         * A local variable is a variable that is declared within a method, constructor, or block of code and is only accessible within that scope. 
         * It exists only for the duration of the method or block in which it is declared. 
         * In this case, slimeId is declared and assigned the value of slime.ID within the Start() method.
         */

        Debug.Log(slimeId + "Slime id variable");
        Debug.Log(slime.ID);

        slime.MaxHealth = 100f;
        Debug.Log(slime.MaxHealth);

        slime.CurrentHealth = slime.MaxHealth;
        Debug.Log(slime.CurrentHealth);

        // way 02

        /* The code directly assigns values to the properties of the Slime class without creating an instance explicitly. 
         * This is possible because the Start() method is within the same class that implements the properties.
         */

        ID = 0;
        Name = "Slime";
        MaxHealth = 200f;
        CurrentHealth = MaxHealth;

        Debug.Log(ID + Name + MaxHealth + CurrentHealth);

        // way 03

        /*
         * The code creates an instance of the Slime class using the constructor that accepts parameters: Slime slime2 = new Slime(1, "Slime2", 300);
         * The constructor assigns the provided values to the corresponding properties: ID = iD;, Name = name;, MaxHealth = maxHealth;, CurrentHealth = maxHealth;.
        */

        Slime slime2 = new Slime(1, "Slime2", 300);

        Debug.Log(slime2.ID + slime2.Name + slime2.MaxHealth + slime2.CurrentHealth);

    }

    Slime()
    {

    }

    Slime(int iD, string name, float maxHealth)
    {
        ID = iD;
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void DealDamage(float amount)
    {

    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
    }
}
