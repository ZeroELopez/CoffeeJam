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
        Animator thisAnimator;
        // Start is called before the first frame update
        void Start()
        {
            thisAnimator = GetComponent<Animator>();
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

            thisAnimator.Play((state = newState).ToString(), 0);
        }

        CharacterStates FindState()
        {
            if (state == CharacterStates.Hitstun || state == CharacterStates.Death || 
                (state >= CharacterStates.Attack && state <= CharacterStates.Attack3))
                return state;

            CharacterStates newState = CharacterStates.Idle;

            if (prevPos != transform.position)
            {
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
