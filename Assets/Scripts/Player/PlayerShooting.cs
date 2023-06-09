using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float timeBetweenBullets = 0.15f;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem gunParticles;
    [SerializeField] private LineRenderer gunLine;
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private Light gunLight;

    private float timer;
    private Ray shootRay;
	private RaycastHit shootHit;
	private int shootableMask;

	private float effectsDisplayTime = 0.2f;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
	}

	void Update ()
	{
        timer += Time.deltaTime;
		if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
		{
			Shoot();
		}

		if (timer >= timeBetweenBullets * effectsDisplayTime)
		{
            gunLine.enabled = false;
            gunLight.enabled = false;
        }
	}

    /// <summary>Play shooting efects.</summary>
    void Shoot ()
	{
		timer = 0f;
		gunAudio.Play ();
		gunLight.enabled = true;
		gunParticles.Stop ();
		gunParticles.Play ();
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			gunLine.SetPosition (1, shootHit.point);
			shootHit.collider.GetComponent<Enamy>().TeleportRandomly();
        }
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

	}


}
