using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smog : MonoBehaviour
{

	public ParticleSystem ParticleLauncher;
	public ContactPoint contact;
	private bool firstStrike;
	

	void OnCollisionEnter(Collision collision)
	{
		//ContactPoint contact = collision.contact.point;
		Instantiate(Resources.Load<GameObject>("Particle/SmogEmitSmall"), collision.contacts[0].point, new Quaternion(0,0,0,0));
		
		if (firstStrike == false)
		{
			GetComponent<AudioSource>().Play();
			firstStrike = true;
		}
		
		print(collision.relativeVelocity.magnitude);
		if (collision.relativeVelocity.magnitude > 1.5)
		{
			GetComponent<AudioSource>().Play();		
		}

	}
	
}

