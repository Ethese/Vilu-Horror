using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace vida {
    public class Daño : MonoBehaviour {

        public int attackDamage = 10;               // The amount of health taken away per attack.
        public GameObject player;                   // Reference to the player GameObject.
        VidaJugador vidaJugador;             // Reference to the player's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        public float timeBetweenAttacks = 2f;     // The time in seconds between each attack.
        float timer;

        void Awake()
        {
            // Setting up the references.
            vidaJugador = player.GetComponent<VidaJugador>();
        }

        void Update()
        {
            timer += Time.deltaTime; 
            if (timer >= timeBetweenAttacks && playerInRange)
            {
                Attack();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
                //Debug.Log("En rango!");
                Debug.Log(vidaJugador.currentHealth);
            }
        }


        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }

        void Attack()
        {
            timer = 0f;
            // If the player has health to lose...
            if (vidaJugador.currentHealth >= 0)
            {
                //Debug.Log("ataco");
                // ... damage the player.
                vidaJugador.TakeDamage(attackDamage);
            }
        }
    }
}
