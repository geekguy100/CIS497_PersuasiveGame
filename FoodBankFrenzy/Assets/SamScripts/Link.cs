using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

/*
 * Sam Ferstein
 * Link.cs
 * Source: https://github.com/BlackthornProd/Hyperlink-project
 * From this video: https://www.youtube.com/watch?v=qqOqLNqAdDo&ab_channel=Blackthornprod
 * This is the code that lets the Feeding America button go to the link in a new window in the WebGL build.
 */

public class Link : MonoBehaviour 
{

	public void OpenWebsiteLink()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.feedingamerica.org/");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}