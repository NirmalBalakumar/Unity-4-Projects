﻿using UnityEngine;
using System.Collections;

public class ShredderScript : MonoBehaviour
{	void OnTriggerEnter2D(Collider2D trigger) 
	{ 	Destroy(trigger.gameObject);
	}
}