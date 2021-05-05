
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
/*
* 
* 
* Complete the functions below.  
* For sure, they don't belong in the same class. This is just for the test so ignore that.
* 
* 
*/



public static class Utility
{


	public static GameObject[] GetObjectsWithName(string name)
	{
		/*
		 * 
		 *	Return all objects in the scene with the specified name. Don't think about performance, do it in as few lines as you can. 
		 * 
		 */
		//Linq
		return Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == name).ToArray();
	}


	public static bool CheckCollision(Ray ray, float maxDistance, int layer)
	{
		/*
		 * 
		 *	Perform a raycast using the ray provided, only to objects of the specified 'layer' within 'maxDistance' and return if something is hit. 
		 * 
		 */
		// RaycastHit can be get hit object 
		return Physics.Raycast(ray, maxDistance, layer);
	}





	public static Vector2[] GeneratePoints(int size)
	{


		/*
		 * Generate 'size' number of random points, making sure they are distributed as evenly as possible (Trying to achieve maximum distance between every neighbor).
		 * Boundary corners are (0, 0) and (1, 1). (Point (1.2, 0.45) is not valid because it's outside the boundaries. )
		 * Is there a known algorithm that achieves this?
		 */

		//This proble too hard for me(I tried but failed). I found a algoritm. Poisson disc sampling and related to algorithm found video (Link: https://www.youtube.com/watch?v=7WcmyxyFO7o). But this one i didn't do it. :(
		//Maybealton sequence?
		float radius = 1;
		Vector2 sampleRegionSize = new Vector2(1, 1);

		float cellSize = radius / Mathf.Sqrt(2);

		int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x / cellSize), Mathf.CeilToInt(sampleRegionSize.y / cellSize)];
		List<Vector2> points = new List<Vector2>();
		List<Vector2> spawnPoints = new List<Vector2>();

		spawnPoints.Add(sampleRegionSize / 2);
		while (spawnPoints.Count > 0)
		{
			int spawnIndex = Random.Range(0, spawnPoints.Count);
			Vector2 spawnCentre = spawnPoints[spawnIndex];
			bool candidateAccepted = false;

			for (int i = 0; i < size; i++)
			{
				float angle = Random.value * Mathf.PI * 2;
				Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
				Vector2 candidate = spawnCentre + dir * Random.Range(radius, 2 * radius);
				
			}
			if (!candidateAccepted)
			{
				spawnPoints.RemoveAt(spawnIndex);
			}

		}

		return points.ToArray();
	}


	public static Texture2D GenerateTexture(int width, int height, Color color)
	{

		/*
		 * Create a Texture2D object of specified 'width' and 'height', fill it with 'color' and return it. Do it as performant as possible.
		 */
		Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);

		//not best performance but I know only this way(SetPixels might be better)
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
				texture.SetPixel(width, height, color);
            }
        }

		return texture;
	}




}