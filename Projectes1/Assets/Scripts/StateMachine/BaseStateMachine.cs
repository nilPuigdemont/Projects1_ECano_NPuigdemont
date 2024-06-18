using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseStateMachine : MonoBehaviour
{
    public EnemyStats enemyStats;
    [SerializeField] private BaseState _initialState;

    public Animator animator;
    public float speed => enemyStats.speed;

    private Dictionary<Type, Component> _cachedComponents;
    
    
   
    // Start is called before the first frame update
    private void Awake()
    {
        _cachedComponents = new Dictionary<Type, Component>();
    }

    private BaseState _currentState = null;
    // Update is called once per frame

    public BaseState CurrentState 
    { 
        
        get { return _currentState; }

        set
        {
            _currentState?.OnExit(this);
            _currentState = value;
            _currentState?.OnEnter(this);
        }
    }
    private void Start()
    {
        CurrentState = _initialState;
    }

    private void Update()
    {
        CurrentState.Execute(this);

       
    }

    public new T GetComponent<T>() where T : Component
    {
        if (_cachedComponents.ContainsKey(typeof(T)))
            return _cachedComponents[typeof(T)] as T;

        var component = base.GetComponent<T>();
        if (component != null)
        {
            _cachedComponents.Add(typeof(T), component);
        }
        return component;
    }


   

    
}
