using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

/*
 * Sam Ferstein
 * PressHandler.cs
 * Source: https://github.com/BlackthornProd/Hyperlink-project
 * From this video: https://www.youtube.com/watch?v=qqOqLNqAdDo&ab_channel=Blackthornprod
 * This is code that helps let the Feeding America button go to the link in a new window in the WebGL build.
 */

public class PressHandler : MonoBehaviour, IPointerDownHandler
{
	[Serializable]
	public class ButtonPressEvent : UnityEvent { } 

	public ButtonPressEvent OnPress = new ButtonPressEvent();

	public void OnPointerDown(PointerEventData eventData)
	{
		OnPress.Invoke();
	}
}