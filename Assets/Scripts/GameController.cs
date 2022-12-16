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
        [SerializeField] private Button defendButton = null;


        private bool playerTurn = true;
        private void Attack(GameObject target, float damage, float block)
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

        private void Defend(GameObject target, float block)
        {

            if(target == enemy)
            {
                enemyHealth.value += block;

            }
            else
            {
                playerHealth.value += block;
            }

            ChangeTurn();

        }
        public void buttonAttack()
        {
            Attack(enemy, 15, 0);
        }

        public void buttonHeal()
        {
            Heal(player, 7);
        }
    
        public void buttonDefend()
        {
            Defend(player, 7);
        }
        private void ChangeTurn()
        {
            playerTurn = !playerTurn;

            if(!playerTurn)
            {
                attackButton.interactable = false;
                healButton.interactable = false;
                defendButton.interactable = false;

                StartCoroutine(enemyTurn());
            }
            else
            {
                attackButton.interactable = true;
                healButton.interactable = true;
                defendButton.interactable = true;
            }
        }

        private IEnumerator enemyTurn()
        {
            yield return new WaitForSeconds(4);

            int random = 0;
            random = Random.Range(1, 100);

            if(random > 0 && random <= 55)
            {

                Attack(player, 15 , 0);
                
            }
            else if(random > 55 && random <= 75)
            {
                Heal(enemy, 7);
            }
            else
            {
                Defend(enemy, 10);
            }
        }
     }

 
}


