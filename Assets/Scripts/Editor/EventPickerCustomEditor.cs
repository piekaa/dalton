using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
[CustomEditor(typeof(EventPicker))]
[CanEditMultipleObjects]
public class EventPickerCustomEditor : Editor 
{

	private string[] dropDownPathValues;
	private string[] dropDownItemValues;
	private int selected = 0;
	public void OnEnable()
	{
		fillDropdownList ();
		findSelected ();
	}


	public override void OnInspectorGUI ()
	{

		EventPicker picker = (EventPicker)target;
 
		EditorGUILayout.LabelField (picker.PickedEvent);
		showDropdown ();
	}



	private void fillDropdownList()
	{
		Type eventIdsType = typeof(EventIDs);

		List<String> fieldNameValues = new List<string> ();

		List<String> fieldValeus = new List<string> ();

		inspectType (fieldNameValues, fieldValeus, "", eventIdsType); 
		dropDownPathValues = fieldNameValues.ToArray (); 
		dropDownItemValues = fieldValeus.ToArray ();
	}


	private void findSelected()
	{
		EventPicker ep = (EventPicker)target;

		if (ep.PickedEventPathValue == null || ep.PickedEventPathValue == "")
		{
			selected = 0;
			return;
		}
 
		for (int i = 0; i < dropDownPathValues.Length; i++)
		{
			if (ep.PickedEventPathValue.Equals (dropDownPathValues [i]))
				selected = i;
		}
	}


	private void selectItem(int index)
	{
		EventPicker ep = (EventPicker)target;
		ep.PickedEventPathValue = dropDownPathValues [index];
		ep.PickedEvent = dropDownItemValues [index];
		selected = index;
	}



	private void inspectType(List<string> stringValues, List<string> itemValues, string prefix, Type type)
	{

		if (prefix.Length > 0)
			prefix += "/"; 

		FieldInfo[] fields = type.GetFields ();

		foreach (FieldInfo field in fields)
		{ 
			stringValues.Add(prefix + field.Name);
			itemValues.Add( (string)field.GetValue (null));
		}

		Type[] nestedTypes = type.GetNestedTypes ();
 
		foreach (Type nestedType in nestedTypes)
		{
			inspectType (stringValues, itemValues, prefix  + nestedType.Name, nestedType);	
		}


	}


	private void showDropdown()
	{  
		int pickedByUser = EditorGUILayout.Popup(selected, dropDownPathValues);

		selectItem (pickedByUser);


	}
}
