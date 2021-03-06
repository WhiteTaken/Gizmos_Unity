using UnityEngine;
using UnityEngine.UI;

// This script shows you how you can check tos ee which part of the screen a finger is on, and work accordingly
public class SimpleSplitScreen : MonoBehaviour
{
	[Tooltip("The transform for the left GameObject")]
	public Transform LeftObject;
	
	[Tooltip("The transform for the right GameObject")]
	public Transform RightObject;
	
	protected virtual void OnEnable()
	{
		// Hook the OnFingerSet event
		Lean.LeanTouch.OnFingerSet += OnFingerSet;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook from the OnFingerSet event
		Lean.LeanTouch.OnFingerSet -= OnFingerSet;
	}
	
	public void OnFingerSet(Lean.LeanFinger finger)
	{
		// Right side of the screen?
		if (finger.ScreenPosition.x > Screen.width / 2)
		{
			// Does the right object exist?
			if (RightObject != null)
			{
				// Position it in front of the finger
				RightObject.position = finger.GetWorldPosition(10.0f);
			}
		}
		// Left side?
		else
		{
			// Does the left object exist?
			if (LeftObject != null)
			{
				// Position it in front of the finger
				LeftObject.position = finger.GetWorldPosition(10.0f);
			}
		}
		
		// NOTE: If you want to prevent fingers from crossing sides then you can check finger.StartScreenPosition first
	}
}