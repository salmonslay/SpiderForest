using UnityEngine;

public interface IPowerUp
{
    /// <summary>
    /// A name for this power up
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Icon shown in UI and in-game
    /// </summary>
    public Sprite Icon { get; set; }

    /// <summary>
    /// Color for this power ups particles
    /// </summary>
    public Color ParticleColor { get; set; }

    /// <summary>
    /// Activates this power up
    /// </summary>
    public void Activate();
}