using Unity.Jobs;
using UnityEngine;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using System.Linq;
using System.Collections;
/*
*
* JobTest scene runs very slow because of the repeated dummy math operation below. Implement the for loop below, using parallelized Unity jobs and Burst compiler to gain performance
* If the 'count' is too large for your machine to handle, you can decrease it.
* 
*/
/// <summary>
/// I did first time job system might be not your answer but i liked it. 
/// Used  for answer :
/// https://www.raywenderlich.com/7880445-unity-job-system-and-burst-compiler-getting-started#toc-anchor-016
/// https://www.youtube.com/watch?v=3QT3JHlZ3Cg
/// </summary>
public class JobTest : MonoBehaviour
{

	[SerializeField]
	private bool useJob = false;


	private int count = 10000;

	private NativeArray<float> values;
	Job job;
	JobHandle jobHandle;

	void Start()
	{
		
		values = new NativeArray<float>(count,Allocator.Persistent);
	}


	void Update()
	{
		if (useJob)
		{
				Job job = new Job()
				{
					jobValues = values
				};
				jobHandle = IJobParallelForExtensions.Schedule(job, values.Length, 50);
		}
		else
		{

			for (int i = 0; i < values.Length; i++)
			{
				values[i] = Mathf.Sqrt(Mathf.Pow(values[i] + 1.75f, 2.5f + i)) * 5 + 2f;
			}

		}

	}
    private void LateUpdate()
    {
		jobHandle.Complete();
		
	}

    private void OnDestroy()
    {
		
    }

    [BurstCompile(CompileSynchronously = true)]
    private struct Job : IJobParallelFor
    {
		public NativeArray<float> jobValues;
        public void Execute(int index)
        {
			
		    jobValues[index] = Mathf.Sqrt(Mathf.Pow(jobValues[index] + 1.75f, 2.5f + index)) * 5 + 2f;
			Debug.Log("Look");
		}
    }

}