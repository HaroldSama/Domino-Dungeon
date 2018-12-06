using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smog : MonoBehaviour
{

	public ParticleSystem ParticleLauncher;
	public ContactPoint contact;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		//ContactPoint contact = collision.contact.point;
		Instantiate(Resources.Load<GameObject>("Particle/SmogEmitSmall"), collision.contacts[0].point, new Quaternion(0,0,0,0));
		GetComponent<AudioSource>().Play();
	}
	
}

