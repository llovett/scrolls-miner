using System;

using ScrollsModLoader.Interfaces;
using UnityEngine;
using Mono.Cecil;

namespace Template.mod
{
	public class MyMod : BaseMod
	{

		//initialize everything here, Game is loaded at this point
		public MyMod ()
		{
		}


		public static string GetName ()
		{
			return "SimpleButtonMod";
		}

		public static int GetVersion ()
		{
			return 1;
		}

		//only return MethodDefinitions you obtained through the scrollsTypes object
		//safety first! surround with try/catch and return an empty array in case it fails
		public static MethodDefinition[] GetHooks (TypeDefinitionCollection scrollsTypes, int version)
		{
			try {
				return scrollsTypes["MainMenu"].Methods.GetMethod("Update");
			} catch (Exception e) {
				Application.Quit();
			}
			return new MethodDefinition[] {};
		}

		
		public override void BeforeInvoke (InvocationInfo info)
		{
			return;
		}

		public override void AfterInvoke (InvocationInfo info, ref object returnValue)
		{
			try {
				if (Input.GetKey (KeyCode.Space)) {
					Application.Quit ();
				}
			}
			catch {
				Application.OpenURL("http://www.google.com");
			}
		}

		//override only when needed
		/*

		public override void ReplaceMethod (InvocationInfo info, out object returnValue)
		{
			returnValue = null;
		}

		public override bool WantsToReplace (InvocationInfo info)
		{
			return false;
		}

		*/
	}
}

