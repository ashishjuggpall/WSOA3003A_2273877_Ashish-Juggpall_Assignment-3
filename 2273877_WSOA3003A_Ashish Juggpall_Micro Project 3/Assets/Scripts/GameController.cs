using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject Player;

    public int PlayerHealth = 20;
    public int PlayerHealthItem = 3;

    public int SpecialPower = 3;
    public GameObject SpecialPowerUI;

    public Text SpecialPowerDisplay;

    public GameObject PlayerHealUI;
    public Text PlayerHealthDisplay;
    public Text PlayerHealthItemDisplay;

    private bool IsPlayersTurn = true;

    private bool IsPlayerBlockActive = false;

    private bool BattleWon = false;
    private bool BattleLost = false;

    public GameObject PlayerBattleUI;
    public GameObject PlayerHealthUI;

    public GameObject BattleWonUI;
    public GameObject BattleLostUI;

    public PlayerShake playershake;

    public GameObject PlayerHealthEffect;

    public GameObject DamageEffect;
    public GameObject EnemyDamageEffect;
    public GameObject SpecialDamageEffect;
    public GameObject PlayerDamageEffect;

    public GameObject PlayerBlockEffect;

    public GameObject Enemy;

    public int EnemyHealth = 30;
    public int EnemyHealthItem = 1;
    public Text EnemyHealthDisplay;

    public float EnemyTimeRemaining = 3;
    private bool EnemyTimeRunning = false;

    private bool IsEnemyTurn = false;

    private bool IsEnemyBlockActive = false;

    public GameObject EnemyHealthUI;

    public EnemyShaker enemyShaker;

    public GameObject EnemyHealthEffect;

    public GameObject Villain;

    public int VillainHealth = 15;
    public int VillainHealthItem = 1;
    public Text VillainHealthDisplay;

    public float VillainTimeRemaining = 3;
    public bool VillainTimeRunning = false;

    private bool IsVillainTurn = false;

    private bool IsVillainBlockActive = false;

    public GameObject VillainHealthUI;

    public VillainShaker villainShaker;

    public GameObject VillainHealthEffect;
    public void Start()
    {
        playershake = GameObject.FindGameObjectWithTag("PlayerShake").GetComponent<PlayerShake>();
        enemyShaker = GameObject.FindGameObjectWithTag("EnemyShake").GetComponent<EnemyShaker>();
        villainShaker = GameObject.FindGameObjectWithTag("VillainShake").GetComponent<VillainShaker>();

        Villain.SetActive(false);

        BattleWonUI.SetActive(false);
        BattleLostUI.SetActive(false);

        Player.SetActive(true);
        IsPlayersTurn = true;

        BattleWon = false;
        BattleLost = false;

    }

    public void Update()
    {
        VillainHealthDisplay.text = VillainHealth.ToString();
        EnemyHealthDisplay.text = EnemyHealth.ToString();
        PlayerHealthDisplay.text = PlayerHealth.ToString();
        PlayerHealthItemDisplay.text = PlayerHealthItem.ToString();
        SpecialPowerDisplay.text = SpecialPower.ToString();

        if (Enemy.activeSelf)
        {
            if ((PlayerHealth > 0) && (EnemyHealth > 0))
            {
                if (IsEnemyTurn == true)
                {
                    EnemyTimeRunning = true;
                    PlayerBattleUI.SetActive(false);
                    if (EnemyHealth <= 10)
                    {
                        if (EnemyHealth < 5)
                        {
                            if (IsPlayerBlockActive == true)
                            {
                                if (EnemyTimeRunning)
                                {
                                    if (EnemyTimeRemaining > 0)
                                    {
                                        EnemyTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        EnemyAttack();
                                        EnemyTimeRemaining = 3;
                                        EnemyTimeRunning = false;
                                        IsPlayerBlockActive = false;
                                        IsEnemyTurn = false;
                                        PlayerBattleUI.SetActive(true);
                                        IsPlayersTurn = true;
                                    }

                                }
                            }

                            else
                            {

                                if (EnemyTimeRunning)
                                {
                                    if (EnemyTimeRemaining > 0)
                                    {
                                        EnemyTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        EnemyTimeRemaining = 3;
                                        EnemyTimeRunning = false;
                                        EnemyPowerAttack();
                                    }
                                }
                            }
                        }

                        if (EnemyHealthItem > 0)
                        {
                            if (EnemyTimeRunning)
                            {
                                if (EnemyTimeRemaining > 0)
                                {
                                    EnemyTimeRemaining -= Time.deltaTime;
                                }

                                else
                                {
                                    EnemyTimeRemaining = 3;
                                    EnemyTimeRunning = false;
                                    EnemyHeal();
                                }
                            }

                        }

                        else
                        {
                            if (IsPlayerBlockActive == true)
                            {
                                if (EnemyTimeRunning)
                                {
                                    if (EnemyTimeRemaining > 0)
                                    {
                                        EnemyTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        EnemyTimeRemaining = 3;
                                        EnemyTimeRunning = false;
                                        IsPlayerBlockActive = false;
                                        IsEnemyTurn = false;
                                        PlayerBattleUI.SetActive(true);
                                        IsPlayersTurn = true;
                                    }

                                }
                            }

                            else
                            {
                                if (EnemyTimeRunning)
                                {
                                    if (EnemyTimeRemaining > 0)
                                    {
                                        EnemyTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        EnemyTimeRemaining = 3;
                                        EnemyTimeRunning = false;
                                        EnemyAttack();
                                    }
                                }

                            }

                        }
                    }

                    else
                    {
                        if (EnemyTimeRunning)
                        {
                            if (EnemyTimeRemaining > 0)
                            {
                                EnemyTimeRemaining -= Time.deltaTime;
                            }

                            else
                            {
                                EnemyTimeRemaining = 3;
                                EnemyTimeRunning = false;
                                EnemyAttack();
                            }
                        }
                    }
                }

                if (IsPlayersTurn == true)
                {
                    PlayerBattleUI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        PlayerAttack();
                    }

                    if (PlayerHealthItem > 0)
                    {
                        PlayerHealUI.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            PlayerHeal();
                        }

                    }

                    else if (PlayerHealthItem <= 0)
                    {
                        PlayerHealUI.SetActive(false);
                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Instantiate(PlayerBlockEffect, transform.position, Quaternion.identity);
                        IsPlayerBlockActive = true;
                        IsPlayersTurn = false;
                        PlayerBattleUI.SetActive(false);
                        IsEnemyTurn = true;
                    }

                    if (SpecialPower > 0)
                    {
                        SpecialPowerUI.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            PowerAttack();
                        }
                    }

                    else if (SpecialPower <= 0)
                    {
                        SpecialPowerUI.SetActive(false);
                    }
                }
            }

            else
            {
                if (PlayerHealth <= 0)
                {
                    LoseGame();
                    Enemy.SetActive(false);
                }

                if (EnemyHealth <= 0)
                {
                    WinGame();
                    Enemy.SetActive(false);
                }
            }
        }

        else if (Villain.activeSelf)
        {

            if ((PlayerHealth > 0) && (VillainHealth > 0))
            {
                if (IsVillainTurn == true)
                {
                    VillainTimeRunning = true;
                    PlayerBattleUI.SetActive(false);
                    if (VillainHealth <= 10)
                    {
                        if (VillainHealth < 5)
                        {
                            if (IsPlayerBlockActive == true)
                            {
                                if (VillainTimeRunning)
                                {
                                    if (VillainTimeRemaining > 0)
                                    {
                                        VillainTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        VillainAttack();
                                        VillainTimeRemaining = 3;
                                        VillainTimeRunning = false;
                                        IsPlayerBlockActive = false;
                                        IsVillainTurn = false;
                                        PlayerBattleUI.SetActive(true);
                                        IsPlayersTurn = true;
                                    }

                                }
                            }

                            else
                            {

                                if (VillainTimeRunning)
                                {
                                    if (VillainTimeRemaining > 0)
                                    {
                                        VillainTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        VillainTimeRemaining = 3;
                                        VillainTimeRunning = false;
                                        VillainPowerAttack();
                                    }
                                }
                            }
                        }

                        if (VillainHealthItem > 0)
                        {
                            if (VillainTimeRunning)
                            {
                                if (VillainTimeRemaining > 0)
                                {
                                    VillainTimeRemaining -= Time.deltaTime;
                                }

                                else
                                {
                                    VillainTimeRemaining = 3;
                                    VillainTimeRunning = false;
                                    VillainHeal();
                                }
                            }

                        }

                        else
                        {
                            if (IsPlayerBlockActive == true)
                            {
                                if (VillainTimeRunning)
                                {
                                    if (VillainTimeRemaining > 0)
                                    {
                                        VillainTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        VillainTimeRemaining = 3;
                                        VillainTimeRunning = false;
                                        IsPlayerBlockActive = false;
                                        IsVillainTurn = false;
                                        PlayerBattleUI.SetActive(true);
                                        IsPlayersTurn = true;
                                    }

                                }
                            }

                            else
                            {
                                if (VillainTimeRunning)
                                {
                                    if (VillainTimeRemaining > 0)
                                    {
                                        VillainTimeRemaining -= Time.deltaTime;
                                    }

                                    else
                                    {
                                        VillainTimeRemaining = 3;
                                        VillainTimeRunning = false;
                                        VillainAttack();
                                    }
                                }

                            }

                        }
                    }

                    else
                    {
                        if (VillainTimeRunning)
                        {
                            if (VillainTimeRemaining > 0)
                            {
                                VillainTimeRemaining -= Time.deltaTime;
                            }

                            else
                            {
                                VillainTimeRemaining = 3;
                                VillainTimeRunning = false;
                                VillainAttack();
                            }
                        }
                    }
                }

                if (IsPlayersTurn == true)
                {
                    PlayerBattleUI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        PlayerAttackVillain();
                    }

                    if (PlayerHealthItem > 0)
                    {
                        PlayerHealUI.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            PlayerHeal();
                        }

                    }

                    else if (PlayerHealthItem <= 0)
                    {
                        PlayerHealUI.SetActive(false);
                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Instantiate(PlayerBlockEffect, transform.position, Quaternion.identity);
                        IsPlayerBlockActive = true;
                        IsPlayersTurn = false;
                        PlayerBattleUI.SetActive(false);
                        IsVillainTurn = true;
                    }

                    if (SpecialPower > 0)
                    {
                        SpecialPowerUI.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            PowerAttack();
                        }
                    }

                    else if (SpecialPower <= 0)
                    {
                        SpecialPowerUI.SetActive(false);
                    }
                }
            }

            else
            {
                if (PlayerHealth <= 0)
                {
                    LoseGame();
                    Villain.SetActive(false);
                }

                if (EnemyHealth <= 0)
                {
                    WinGame();
                    Villain.SetActive(false);
                }
            }
        }
    }



    public void PlayerAttack()
    {
        Instantiate(DamageEffect, new Vector3(5, 2, 0), Quaternion.identity);
        EnemyHealth -= 2;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsEnemyTurn = true;
        enemyShaker.EnemyShake();
    }

    public void PowerAttack()
    {
        Instantiate(SpecialDamageEffect, new Vector3(5, 2, 0), Quaternion.identity);
        EnemyHealth -= 5;
        SpecialPower--;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsEnemyTurn = true;
        enemyShaker.EnemyShake();
    }

    public void PlayerHeal()
    {
        Instantiate(PlayerHealthEffect, transform.position, Quaternion.identity);
        PlayerHealth += 7;
        PlayerHealthItem--;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsEnemyTurn = true;
    }

    public void PlayerAttackVillain()
    {
        Instantiate(DamageEffect, new Vector3(5, 2, 0), Quaternion.identity);
        VillainHealth -= 2;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsVillainTurn = true;
        villainShaker.VillainShake();
    }

    public void PowerAttackVillain()
    {
        Instantiate(SpecialDamageEffect, new Vector3(5, 2, 0), Quaternion.identity);
        VillainHealth -= 5;
        SpecialPower--;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsVillainTurn = true;
        villainShaker.VillainShake();
    }

    public void PlayerHealVillain()
    {
        Instantiate(PlayerHealthEffect, transform.position, Quaternion.identity);
        PlayerHealth += 7;
        PlayerHealthItem--;
        IsPlayersTurn = false;
        PlayerBattleUI.SetActive(false);
        IsVillainTurn = true;
    }

    public void WinGame()
    {
        BattleWon = true;
        PlayerBattleUI.SetActive(false);
        PlayerHealthUI.SetActive(false);
        EnemyHealthUI.SetActive(false);
        VillainHealthUI.SetActive(false);
        IsPlayersTurn = false;
        IsEnemyTurn = false;
        IsVillainTurn = false;
        BattleWonUI.SetActive(true);
    }

    public void LoseGame()
    {
        BattleLost = true;
        PlayerBattleUI.SetActive(false);
        PlayerHealthUI.SetActive(false);
        EnemyHealthUI.SetActive(false);
        VillainHealthUI.SetActive(false);
        IsPlayersTurn = false;
        IsEnemyTurn = false;
        IsVillainTurn = false;
        BattleLostUI.SetActive(true);
    }

    public void EnemyAttack()
    {
        Instantiate(EnemyDamageEffect, transform.position, Quaternion.identity);
        PlayerHealth -=2;
        IsEnemyTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
        playershake.PlayerShaker();
    }

    public void EnemyHeal()
    {
        Instantiate(EnemyHealthEffect, new Vector3(5, 2, 0), Quaternion.identity);
        EnemyHealth += 5;
        EnemyHealthItem--;
        IsEnemyTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
    }

    public void EnemyPowerAttack()
    {
        Instantiate(PlayerDamageEffect, transform.position, Quaternion.identity);
        PlayerHealth -= 7;
        IsEnemyTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
        playershake.PlayerShaker();
    }

    public void VillainAttack()
    {
        Instantiate(EnemyDamageEffect, transform.position, Quaternion.identity);
        PlayerHealth -= 1;
        IsVillainTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
        playershake.PlayerShaker();
    }

    public void VillainHeal()
    {
        Instantiate(EnemyHealthEffect, new Vector3(5, 2, 0), Quaternion.identity);
        VillainHealth += 2;
        EnemyHealthItem--;
        IsVillainTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
    }

    public void VillainPowerAttack()
    {
        Instantiate(PlayerDamageEffect, transform.position, Quaternion.identity);
        PlayerHealth -= 4;
        IsVillainTurn = false;
        PlayerBattleUI.SetActive(true);
        IsPlayersTurn = true;
        playershake.PlayerShaker();
    }

    //for new position instantiate(effect, new vector3 (co-ordinates), Quaternion.identity);
    /// public void RandomGenerator()
    //RandomNumber = Random.Range(1, 4);
}
