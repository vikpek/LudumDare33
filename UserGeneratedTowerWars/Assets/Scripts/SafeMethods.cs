﻿using UnityEngine;

public static class SafeMethods  {
	public static T GetSafeComponent<T>(this GameObject obj) where T : MonoBehaviour
	{
		T component = obj.GetComponent<T>();
		
		if(component == null)
		{
			Debug.LogError("Expected to find component of type " 
			               + typeof(T) + " but found none", obj);
		}
		
		return component;
	}
}
