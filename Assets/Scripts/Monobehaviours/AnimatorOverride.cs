using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Monobehaviours
{
    public class AnimatorOverride : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAnimations(AnimatorOverrideController overrideController) 
        {
            animator.runtimeAnimatorController = overrideController;
        }
    }
}