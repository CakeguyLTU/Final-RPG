using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LP.TurnBasedGame
{

    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;
        [SerializeField] private GameObject enemy = null;
        [SerializeField] private Slider playerHealth = null;
        [SerializeField] private Slider enemyHealth = null;
        [SerializeField] private Button attackButton = null;
        [SerializeField] private Button healButton = null;

        private bool playerTurn = true;

        private void Attack(GameObject target, float damage)
        {
            if (target == enemy)
            {
                enemyHealth.value -= damage;
            }
            else
            {
                playerHealth.value -= damage;
            }

            ChangeTurn();
        }

        private void Heal(GameObject target, float amount)
        {
            if(target == enemy)
            {
                enemyHealth.value += amount;
            }
            else
            {
                playerHealth.value += amount;
            }

            ChangeTurn();
        }

        public void buttonAttack()
        {
            Attack(enemy, 10);
        }

        public void buttonHeal()
        {
            Heal(player, 7);
        }
    
        private void ChangeTurn()
        {
            playerTurn = !playerTurn;

            if(!playerTurn)
            {
                attackButton.interactable = false;
                healButton.interactable = false;

                StartCoroutine(enemyTurn());
            }
            else
            {
                attackButton.interactable = true;
                healButton.interactable = true;
            }
        }

        private IEnumerator enemyTurn()
        {
            yield return new WaitForSeconds(4);

            int random = 0;
            random = Random.Range(1, 3);

            if(random == 1)
            {
                Attack(player, 15);
            }
            else
            {
                Heal(enemy, 5);
            }
        }
     }

 
}


