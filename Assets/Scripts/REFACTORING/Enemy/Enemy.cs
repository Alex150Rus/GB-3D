// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.AI;
//
// using EnemyStates;
//
// public class Enemy : MonoBehaviour
// {
//     [SerializeField] private Transform _enemy;
//     [SerializeField] private int _enemyDistance = 23;
//     [SerializeField] private float _closeAttackDistance = 1;
//     [SerializeField] private UnityEvent onTargetIsVisible;
//     [SerializeField] private UnityEvent onTargetIsInvisible;
//     [SerializeField] private NavMeshAgent _navMeshAgent;
//     [SerializeField] private Stick _stickWeapon;
//
//
//     private State _state;
//     private State _animatorState;
//     private Animator _animator;
//     private static readonly int _speed = Animator.StringToHash("speed");
//     private static readonly int _fire = Animator.StringToHash("fire");
//     private static readonly int _idle = Animator.StringToHash("idle");
//     private static readonly int _clAttack = Animator.StringToHash("closeAttack");
//     private bool _stickWeaponExists = false;
//
//
//     private void Awake()
//     {
//         _animator = GetComponent<Animator>();
//         _navMeshAgent = GetComponent<NavMeshAgent>();
//         _state = State.DontSeeEnemy;
//         _animatorState = State.Idle;
//         _stickWeaponExists = _stickWeapon ? true : false;
//     }
//
//
//     private void Update()
//     {
//         FindEnemy();
//         Animate();
//     }
//
//
//     private void FindEnemy()
//     {
//         RaycastHit hit;
//
//         Vector3 direction = _enemy.transform.position - transform.position;
//
//         if (Physics.Raycast(transform.position, direction, out hit, _enemyDistance) && hit.collider.CompareTag(_enemy.tag))
//         {
//             if (_state == State.DontSeeEnemy || _state == State.StopSeeingEnemy)
//             {
//                 _state = State.SeeEnemyFirstTime;
//                 //таким образом отправим событие единожды
//                 onTargetIsVisible?.Invoke();
//             }
//             else if (_state == State.SeeEnemyFirstTime) _state = State.SeeingEnemy;
//
//             transform.LookAt(_enemy.position);
//
//         } else
//         {
//             if (_state == State.SeeEnemyFirstTime || _state == State.SeeingEnemy)
//             {
//                 _state = State.StopSeeingEnemy;
//                 //таким образом отправим событие единожды
//                 onTargetIsInvisible?.Invoke();
//             }
//             else if (_state == State.StopSeeingEnemy) _state = State.DontSeeEnemy;
//         }
//     }
//
//     /// <summary>
//     /// We are coming here from ChaseScript events: StartChase (To start Chase Animation, depending on chase speed), 
//     /// StopChase (To Start Patrol Animation, depending on patrol starting speed)
//     /// 
//     /// And WayPointPatrol: Patrol - to startPatrolAnimation (depending on starting Patrol speed)
//     /// Checking NavMeshSpeed if it is greater than 2.49 - the enemy should run
//     /// if less than 2.49 - walk
//     /// </summary>
//     public void SetWalkOrRunState() {
//         if (_navMeshAgent.speed > 2.49) _animatorState = State.Run;
//         else _animatorState = State.Walk;
//     }
//
//     /// <summary>
//     /// We are coming here from chase Script event ChaseCompleted (to set nimation to Idle)
//     /// </summary>
//     public void SetIdleState()
//     {
//         _animator.SetFloat(_speed, 0f);
//         _animatorState = State.Idle;
//     }
//
//     public void SetFiringState()
//     {
//         _animatorState = State.Firing;
//     }
//
//     public void SetCloseAttackState()
//     {
//         _animatorState = State.CloseAttack;
//     }
//
//     private void Animate()
//     {
//         switch (_animatorState)
//         {
//             case State.Idle:
//                 _animator.SetTrigger(_idle);
//                 break;
//             case State.Walk:
//                 _animator.SetFloat(_speed, _navMeshAgent.speed);
//                 break;
//             case State.Run:
//                 _animator.SetFloat(_speed, _navMeshAgent.speed);
//                 break;
//             case State.Firing:
//                 _animator.SetTrigger(_fire);
//                 break;
//             case State.CloseAttack:
//                 _animator.SetTrigger(_clAttack);
//                 break;
//             default:
//                 break;
//         }
//     }
//
// }
