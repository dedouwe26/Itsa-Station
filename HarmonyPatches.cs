﻿using System;
using System.Reflection;
using HarmonyLib;

namespace ItsaStation
{
	/// <summary>
	/// This class handles applying harmony patches to the game.
	/// You should not need to modify this class.
	/// </summary>
	public class HarmonyPatches
	{
		private static Harmony instance;

		public static bool IsPatched { get; private set; }
		public const string InstanceId = "com.dedouwe26.gorillatag.itsa-station";

		internal static void ApplyHarmonyPatches()
		{
			if (!IsPatched)
			{
				if (instance == null)
				{
					instance = new Harmony(InstanceId);
				}

				instance.PatchAll(Assembly.GetExecutingAssembly());
				IsPatched = true;
			}
		}

		internal static void RemoveHarmonyPatches()
		{
			if (instance != null && IsPatched)
			{
				instance.UnpatchSelf();
				IsPatched = false;
			}
		}
	}
}
