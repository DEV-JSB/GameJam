using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static private SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
                return null;
            return instance;
        }
    }

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource effectSource;

    [Header("BGM")]
    [SerializeField] private AudioClip introSound;
    [SerializeField] private AudioClip lobbySound;
    [SerializeField] private AudioClip inGameSound;
    [SerializeField] private AudioClip clearSound;
    [SerializeField] private AudioClip getTowerSound;

    [Header("Effect")]
    [SerializeField] private AudioClip buttonSound;

    [Header("Player")]
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private AudioClip playerGetCoinSound;

    [Header("Enemy")]
    [SerializeField] private AudioClip enemyDeadSound;
    [SerializeField] private AudioClip enemyAttackSound;

    [Header("DefenseUnit")]
    [SerializeField] private AudioClip meleeAttackSound;
    [SerializeField] private AudioClip archerAttackSound;
    [SerializeField] private AudioClip specialAttackSound;


    [Header("Rullet")]
    [SerializeField] private AudioClip rulletRollingSound;
    [SerializeField] private AudioClip rulletCompeleteSound;




}
