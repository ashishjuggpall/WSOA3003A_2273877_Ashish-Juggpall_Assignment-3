using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainShaker : MonoBehaviour
{
    public Animator VillainAnim;

    public void VillainShake()
    {
        VillainAnim.SetTrigger("VillainShake");
    }
}
