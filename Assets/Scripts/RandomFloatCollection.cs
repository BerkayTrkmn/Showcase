﻿

using UnityEditor;
using UnityEngine;

/*
 * 
 * A persistent type of asset, not living in any scene, is needed for a system.
 * It needs to be created inside the editor in the right-click context menu ("Create/Random/FloatCollection").
 * Item's inspector should show an array of floats, just like a regular behaviour's inspector.
 * There should be a button in the inspector that says "Generate" and it should populate the array shown, with random values between 0 and 1.
 * The generated values should persist between editor sessions, scene loads, etc. So make sure of that.
 * 
 * 
 * Code from UnityEditor namespace is not allowed in the build, but RandomFloatCollection class should make it to the build. 
 * Use preprocessor definitions to handle that. What would you do if for some reason you weren't allowed to use preprocessor definitions? 
 * 
 * 
 * 
 * Continue implementing the class however you wish.
 * 
 * 
 */

//ANSWER: I dont know other way but  if editor gives error i can delete it because doesn't need for build


[CreateAssetMenu(fileName ="NewFloatCollection",menuName ="Random/FloatCollection")]
public class RandomFloatCollection :ScriptableObject
{
   public float[] floatArray;

    public void Generate()
    {
      int randomLength =  Random.Range(5, 15);
        floatArray = new float[randomLength];

        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = Random.Range(0f, 1f);
        }

    }


}

#if UNITY_EDITOR


[CustomEditor(typeof(RandomFloatCollection))]
    public class RandomFloatCollectionEditor :Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RandomFloatCollection script = (RandomFloatCollection)target;

        if (GUILayout.Button("GENERATE"))
        {
            script.Generate();
        }
    }
}
#endif
