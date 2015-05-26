using UnityEngine;
using System.Collections;
using UnityEditor;

public class BuildAB : MonoBehaviour {

	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
		BuildPipeline.BuildAssetBundles ("Assets/ExportedAssets/AssetBundles");
	}
/*
6) AssetPostProcessor.OnPostprocessAssetbundleNameChanged 
*/

	[MenuItem ("Assets/GetAllAssetBundleNames")]
	static void GetAllAssetBundleNames()
	{
		//AssetDatabase.GetAllAssetBundleNames (); 
	}

	[MenuItem ("Assets/GetAssetPathsFromAssetBundle")]
	static void GetAssetPathsFromAssetBundle()
	{
		//AssetDatabase.GetAssetPathsFromAssetBundle (); 
	}

	[MenuItem ("Assets/RemoveAssetBundleName")]
	static void RemoveAssetBundleName()
	{
		//AssetDatabase.RemoveAssetBundleName (); 
	}

	[MenuItem ("Assets/GetUnusedAssetBundleNames")]
	static void GetUnusedAssetBundleNames()
	{
		//AssetDatabase.GetUnusedAssetBundleNames (); 
	}

	[MenuItem ("Assets/RemoveUnusedAssetBundleNames")]
	static void RemoveUnusedAssetBundleNames()
	{
		//AssetDatabase.RemoveUnusedAssetBundleNames (); 
	}
}
