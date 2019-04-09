using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace vida
{
    public class Heal : MonoBehaviour
    {

        public int healAmount = 10;               // The amount of health taken away per attack.
        public GameObject player;                   // Reference to the player GameObject.
        VidaJugador vidaJugador;             // Reference to the player's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.

        void Awake()
        {
            // Setting up the references.
            vidaJugador = player.GetComponent<VidaJugador>();
        }

        void Update()
        {
            if (playerInRange)
            {
                MakeHeal();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
                Debug.Log("En rango de heal!");
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

        void MakeHeal()
        {
            // If the player has health to lose...
            if (vidaJugador.currentHealth > 0)
            {
                Debug.Log("heleo");
                // ... damage the player.
                vidaJugador.TakeHeal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
