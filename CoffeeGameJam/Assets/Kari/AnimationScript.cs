using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public enum CharacterStates
    {
        Idle,
        Walking,
        Attack,
        Attack2,
        Attack3,
        Block,
        Eat,
        Drink,
        Hitstun,
        Death,
        Count
    }

    public enum EnemyStates
    {
        Idle,
        Walking,
        LungeAttack,
        BasicAttack,
        Hitstun,
        Death,
        Count
    }
    public class AnimationScript : MonoBehaviour
    {
        Vector3 originalScale;
        Animator thisAnimator;

        [SerializeField] PlayerEntitySecond player;
        // Start is called before the first frame update
        void Start()
        {
            thisAnimator = GetComponent<Animator>();
            originalScale = transform.localScale;
           
        }

        Vector3 prevPos = new Vector3();

        [SerializeField] int attackNumber;
        [SerializeField] CharacterStates state = CharacterStates.Count;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                StartAttack();
            if (Input.GetKeyDown(KeyCode.S))
                Neutral();

            CharacterStates newState = FindState();

            if (newState >= CharacterStates.Attack && newState <= CharacterStates.Attack3)
            {
                float finalTime = (Time.time - player.startTime) / player.attackFrames;
                thisAnimator.Play((state = newState).ToString(), 0, finalTime);

                Debug.Log(finalTime);

                return;
            }
            thisAnimator.Play((state = newState).ToString(), 0);


        }

        CharacterStates FindState()
        {
            if (!player.isAttacking &&
               (state >= CharacterStates.Attack && state <= CharacterStates.Attack3))
                state = CharacterStates.Count;


            if (state == CharacterStates.Hitstun || state == CharacterStates.Death || 
                (state >= CharacterStates.Attack && state <= CharacterStates.Attack3))
                return state;

            if (player.isAttacking)
            {
                StartAttack();
                return state;
            }


            CharacterStates newState = CharacterStates.Idle;


            if (prevPos != transform.position)
            {
                if (transform.position.x > prevPos.x)
                    transform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
                else if (transform.position.x < prevPos.x)
                    transform.localScale = originalScale;

                newState = CharacterStates.Walking;
                prevPos = transform.position;
            }

            return newState;
        }

        void StartAttack()
        {
            state = CharacterStates.Attack + (attackNumber < 3 ? attackNumber : attackNumber = 0);
            attackNumber++;
        }

        void Hurtstun() => state = CharacterStates.Hitstun;

        void Death() => state = CharacterStates.Death;

        void Neutral() => state = CharacterStates.Idle;

    }


}
