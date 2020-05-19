using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegates : MonoBehaviour
{
    public GameObject leftArm_AttackPoint;
    public GameObject leftLeg_AttackPoint;
    public GameObject RightArm_AttackPoint;
    public GameObject RightLeg_AttackPoint;

    public float stand_Up_Timer = 2f;

    private CharacterAnimations animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound, fall_Sound, ground_Hit_Sound, dead_Sound;

    private EnemyMovement enemy_Movement;

    private ShakeCamera shakeCamera;

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimations>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
        }
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }

    void Left_Arm_Attack_On()
    {
        leftArm_AttackPoint.SetActive(true);
    } 
    
    void Right_Arm_Attack_On()
    {
        RightArm_AttackPoint.SetActive(true);
    } 
    
    void Left_Leg_Attack_On()
    {
        leftLeg_AttackPoint.SetActive(true);
    } 
    
    void Right_Leg_Attack_On()
    {
        RightLeg_AttackPoint.SetActive(true);
    } 
    void Right_Arm_Attack_Off()
    {
        if(RightArm_AttackPoint.activeInHierarchy)
            RightArm_AttackPoint.SetActive(false);
    }
    void Left_Arm_Attack_Off()
    {
        if(leftArm_AttackPoint.activeInHierarchy)
            leftArm_AttackPoint.SetActive(false);
    } 
    
    void Left_Leg_Attack_Off()
    {
        if(leftLeg_AttackPoint.activeInHierarchy)
            leftLeg_AttackPoint.SetActive(false);
    } 
    

    void Right_Leg_Attack_Off()
    {
        if(RightLeg_AttackPoint.activeInHierarchy)
            RightLeg_AttackPoint.SetActive(false);
    } 

    void TagLeft_Arm()
    {
        leftArm_AttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UntagLeft_Arm()
    {
        leftArm_AttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeft_Leg()
    {
        leftLeg_AttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    void UntagLeft_Leg()
    {
        leftLeg_AttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }
 
    IEnumerator StandUpAfterTime()
   {     
      yield return new WaitForSeconds(stand_Up_Timer);
         animationScript.StandUp();
   }

    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();

    }

    void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = fall_Sound;
        audioSource.Play();


    }

    void Enemy_KnockedDown()
    {
        audioSource.clip = fall_Sound
            ;
        audioSource.Play();
    }

    void Enemy_HitGround()
    {
        audioSource.clip = ground_Hit_Sound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemy_Movement.enabled = false;
        transform.parent.gameObject.layer = 0;

    } 
    
    void EnableMovement()
    {
        enemy_Movement.enabled = true;
        transform.parent.gameObject.layer = 9;
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void CharacterDied()
    {
        EnemyManager.instance.SpawnEnemy();
        Invoke("DeactivateGameObject", 1.5f);
    }

    void DeactivateGameObject()
    {
        
        Destroy(gameObject);
    }


}
