using System;
using System.Collections.Generic;
using BepInEx;
using Utilla;
using UnityEngine.XR;

namespace ItsaStation
{
    /// <summary>
    /// Itsa Station's main class.
    /// </summary>

    [ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin("com.dedouwe26.gorillatag.itsa-station", "Itsa_Station", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		public InputDevice left {get; private set;}
		public InputDevice right {get; private set;}

		void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

        [Obsolete]
        void OnEnable()
		{
			List<InputDevice> devices = new List<InputDevice>();
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Right, devices);
			foreach (var device in devices)
			{
				if (device.role == InputDeviceRole.LeftHanded) 
				{
					left = device;
				}
				else if (device.role == InputDeviceRole.RightHanded) 
				{
					right = device;
				}
			}

			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
		}

		void Update()
		{
			/* Code here runs every frame when the mod is enabled */
		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{

			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			/* Deactivate your mod here */
			/* This code will run regardless of if the mod is enabled*/

			inRoom = false;
		}
	}
}
