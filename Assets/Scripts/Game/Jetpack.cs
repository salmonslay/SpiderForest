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
		
	private Rigidbody2D _body;
	private ParticleSystem _particles;
	ParticleSystem.MainModule _particlesMain;

	public bool IsUnlocked = false;


	private void Awake()
	{
		_body = GetComponent<Rigidbody2D>();
		_currentFuel = _maximumFuel;
		_particles = GetComponentInChildren<ParticleSystem>();
		_particlesMain = _particles.main;
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
		}
		else
		{
			_particlesMain.loop = false;
		}
	}

	/// <summary>
	/// Refills the jetpack's fuel when it's not in use.
	/// </summary>
	public void Refuel()
	{
		if (_currentFuel<_maximumFuel)
		{
			_currentFuel += Time.deltaTime;
		}
		_particlesMain.loop = false;
	}
}
