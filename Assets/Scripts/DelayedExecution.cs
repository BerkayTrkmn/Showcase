
using System.Collections;
using UnityEngine;


public class DelayedExecution : MonoBehaviour
{


	/*
	 * 
	 * 
	 * Implement the function 'Do' below so that it can be called from any context.
	 * You want to pass it a function and a float 'delay'. After 'delay' seconds, the function is to be executed.
	 * You can create as many additional functions as you need.
	 * Assume that this class needs to be a 'MonoBehaviour', so don't change that.
	 * 
	 * 
	 */

	 public static IEnumerator DoWithDelay(float delay)
    {
		yield return new WaitForSeconds(delay);
		Do();
    }

	public static void Do()
    {

    }
}

