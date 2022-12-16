using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        //public Animator animator;
        
        public void LoadLevel(string sceneName)
        {
            if(playerHealth.value <= 0)
            {
                SceneManager.LoadScene(sceneName);
            }
            if (enemyHealth.value <= 0)
            {
                SceneManager.LoadScene(sceneName);
            }
            
        }

        private void Attack(GameObject target, float damage, float block)
        {
            if (target == enemy)
            {
                enemyHealth.value -= damage;
                //animator.SetBool("Attack01", true);
            }
            else
            {
                playerHealth.value -= damage;
                //animator.SetBool("Attack02", true);
            }
           // animator.SetBool("IdleNormal", true);
            //animator.SetBool("IdleNormal1", true);
            ChangeTurn();
        }

        private void Heal(GameObject target, float amount)
        {
            if(target == enemy)
            {
                enemyHealth.value += amount;
               // animator.SetBool("Taunt1", true);
            }
            else
            {
                playerHealth.value += amount;
               // animator.SetBool("Taunt", true);
            }
           // animator.SetBool("IdleNormal", true);
           //animator.SetBool("IdleNormal1", true);
            ChangeTurn();
        }

        private void Defend(GameObject target, float block)
        {

            if(target == enemy)
            {
                enemyHealth.value += block;
                //animator.SetBool("GetHit", true);
            }
            else
            {
                playerHealth.value += block;
                //animator.SetBool("Defend", true);
            }
           // animator.SetBool("IdleNormal", true);
            //animator.SetBool("IdleNormal1", true);

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
                //animator.SetBool("GetHit", false);
                //animator.SetBool("Defend", false);
               // animator.SetBool("Taunt1", false);
               // animator.SetBool("Taunt", false);
               // animator.SetBool("Attack01", false);
               // animator.SetBool("Attack02", false);
               // animator.SetBool("IdleNormal", true);
               // animator.SetBool("IdleNormal01", true);
                attackButton.interactable = false;
                healButton.interactable = false;
                defendButton.interactable = false;

                StartCoroutine(enemyTurn());
            }
            else
            {
               // animator.SetBool("GetHit", false);
                //animator.SetBool("Defend", false);
                //animator.SetBool("Taunt1", false);
                //animator.SetBool("Taunt", false);
                //animator.SetBool("Attack01", false);
               // animator.SetBool("Attack02", false);
               /// animator.SetBool("IdleNormal", true);
               // animator.SetBool("IdleNormal01", true);
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


