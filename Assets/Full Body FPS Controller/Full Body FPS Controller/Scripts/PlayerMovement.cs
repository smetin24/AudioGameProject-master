using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasySurvivalScripts
{
    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement playerMovementInstance;
        public PlayerStates playerStates;

        public Canvas eyeBlock;

        [Header("Inputs")]
        public string HorizontalInput = "Horizontal";
        public string VerticalInput = "Vertical";
        public string RunInput = "Run";
        public string JumpInput = "Jump";

        [Header("Player Motor")]
        [Range(1f, 15f)]
        public float walkSpeed;
        [Range(1f, 15f)]
        public float runSpeed;
        [Range(1f, 15f)]
        public float JumpForce;
        public Transform FootLocation;

        [Header("Animator and Parameters")]
        public Animator CharacterAnimator;
        public float HorzAnimation;
        public float VertAnimation;
        public bool JumpAnimation;
        public bool LandAnimation;

        [Header("Sounds")]
        public List<AudioClip> FootstepSounds;
        public List<AudioClip> FootstepSoundsOnCarpet;
        public List<AudioClip> JumpSounds;
        public List<AudioClip> LandSounds;

        CharacterController characterController;

        bool walkingOnCarpet = false;
        bool collidedObject;
        float _footstepDelay;
        AudioSource _audioSource;
        float footstep_et = 0;
        float startWalkSpeed;

        // Use this for initialization
        void Start()
        {
            playerMovementInstance = this;
            eyeBlock.enabled = true;
            startWalkSpeed =walkSpeed;
            characterController = GetComponent<CharacterController>();
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            //handle controller
            HandlePlayerControls();

            //sync animations with controller

            //sync footsteps with controller
            PlayFootstepSounds();
            if (Input.GetButton("Eye Block"))
            {
                Debug.Log("block disable");
                eyeBlock.enabled = false;
            }
            else
            {
                eyeBlock.enabled = true;
            }
        }

        void HandlePlayerControls()
        {
            float hInput = Input.GetAxisRaw(HorizontalInput);
            float vInput = Input.GetAxisRaw(VerticalInput);

            Vector3 fwdMovement = characterController.isGrounded == true ? transform.forward * vInput : Vector3.zero;
            Vector3 rightMovement = characterController.isGrounded == true ? transform.right * hInput : Vector3.zero;

            float _speed = Input.GetButton(RunInput) ? runSpeed : walkSpeed;
            characterController.SimpleMove(Vector3.ClampMagnitude(fwdMovement + rightMovement, 1f) * _speed);


            //Managing Player States
            if (characterController.isGrounded)
            {
                if (hInput == 0 && vInput == 0)
                    playerStates = PlayerStates.Idle;
                else
                {
                    if (_speed == walkSpeed)
                        playerStates = PlayerStates.Walking;
                    else
                        playerStates = PlayerStates.Running;

                    _footstepDelay = (2 / _speed);
                }
            }
            else
                playerStates = PlayerStates.Jumping;
        }

        void PlayFootstepSounds()
        {
            if (playerStates == PlayerStates.Idle || playerStates == PlayerStates.Jumping)
                return;

            if (!walkingOnCarpet)
            {
                if (footstep_et < _footstepDelay)
                    footstep_et += Time.deltaTime;
                else
                {
                    footstep_et = 0;
                    _audioSource.PlayOneShot(FootstepSounds[Random.Range(0, FootstepSounds.Count)]);
                }
            }
            else
            {
                if (footstep_et < _footstepDelay)
                    footstep_et += Time.deltaTime;
                else
                {
                    footstep_et = 0;
                    _audioSource.PlayOneShot(FootstepSoundsOnCarpet[Random.Range(0, FootstepSoundsOnCarpet.Count)]);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Objects"))
            {
                collidedObject = true;
            }
            if (other.gameObject.CompareTag("Carpet"))
            {
                walkingOnCarpet = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Objects"))
            {
                collidedObject = false;
                walkSpeed = startWalkSpeed;
            }
            if (other.gameObject.CompareTag("Carpet"))
            {
                walkingOnCarpet = false;
            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Objects"))
            {
                Debug.Log("I'am colliding with object");
                walkSpeed = 1.5f;
            }
        }

    }
}