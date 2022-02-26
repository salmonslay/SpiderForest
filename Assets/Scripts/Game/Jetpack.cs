using System;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [Tooltip("The jetpack's force")]
    [SerializeField] private Vector2 _jetpackForce = new Vector2(0f, 25f);
    
    [Tooltip("The maximum jetpack fuel. When it reaches 0, the jetpack is disabled. One unit is equal to one second.")]
    [SerializeField] private float _maximumFuel = 3f;
    
    [Tooltip("The current jetpack fuel.")]
    private float _currentFuel = 0f;

    [Tooltip("Maximum velocity the player can reach when the jetpack is enabled")]
    [SerializeField] private float _maximumVelocity = 5f;
    
    [Tooltip("True if the jetpack is enabled")]
    [HideInInspector] public bool IsJetpackEnabled = false;
    
    [Tooltip("The maximum camera FOV with a jetpack enabled")]
    [SerializeField] private float _maximumCameraFOV = 70f;

    [Tooltip("The default FOV to return to when jetpack is not in use")]
    private float _defaultCameraFOV;
		
    private Rigidbody2D _body;
    private ParticleSystem _particles;
    private ParticleSystem.MainModule _particlesMain;
    public AudioSource JetpackSound;
    private Camera _camera;



    public bool IsUnlocked = false;


    private void Awake()
    {
        _camera = Camera.main;
        _defaultCameraFOV = _camera.fieldOfView;
        _body = GetComponent<Rigidbody2D>();
        _currentFuel = _maximumFuel;
        _particles = GetComponentInChildren<ParticleSystem>();
        _particlesMain = _particles.main;
		
        _particles.Stop();
        _particles.Clear();
    }

    private void Update()
    {
        UIManager.Instance.JetpackFuel.enabled = IsUnlocked;
        UIManager.Instance.JetpackFuel.fillAmount = _currentFuel / _maximumFuel;
    }

    /// <summary>
    /// Tries to use the jetpack if it is available and has enough fuel.
    /// </summary>
    public void Use()
    {
        if (_currentFuel > 0)
        {
            _currentFuel -= Time.deltaTime;
            if (_body.velocity.y < _maximumVelocity)
                _body.velocity += _jetpackForce * Time.deltaTime;
            else
                _body.velocity = new Vector2(0f, _maximumVelocity);

            _particlesMain.loop = true;
            _particles.Play();
            
            if(_camera.fieldOfView < _maximumCameraFOV)
                _camera.fieldOfView += Time.deltaTime * 3;
        }
        else
        {
            _particlesMain.loop = false;
            JetpackSound.Stop();
        }
    }

    /// <summary>
    /// Refills the jetpack's fuel when it's not in use.
    /// </summary>
    public void Refuel()
    {
        if (_currentFuel < _maximumFuel)
        {
            _currentFuel += Time.deltaTime * 0.5f;
        }
        _particlesMain.loop = false;
		
        if (_camera.fieldOfView > _defaultCameraFOV)
            _camera.fieldOfView -= Time.deltaTime;
    }

    /// <summary>
    /// Completely fuel this jetpack
    /// </summary>
    public void ResetFuel()
    {
        _currentFuel = _maximumFuel;
    }
}