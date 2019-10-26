﻿using AC;
using Naninovel.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Naninovel.AC
{
    /// <summary>
    /// Enables Adventure Creator and (optionally) resets Naninovel engine.
    /// </summary>
    public class TurnOnAC : Command
    {
        /// <summary>
        /// Whether to reset the state and stop all the Naninovel engine services.
        /// </summary>
        [CommandParameter(optional: true)]
        public bool Reset { get => GetDynamicParameter(true); set => SetDynamicParameter(value); }
        /// <summary>
        /// Whether to disable Naninovel's camera and enable Adventure Creator's main camera.
        /// </summary>
        [CommandParameter(optional: true)]
        public bool SwapCameras { get => GetDynamicParameter(true); set => SetDynamicParameter(value); }

        public override async Task ExecuteAsync (CancellationToken cancellationToken = default)
        {
            if (Reset) await Engine.GetService<StateManager>().ResetStateAsync();

            KickStarter.TurnOnAC();

            if (SwapCameras)
            {
                KickStarter.mainCamera.enabled = true;
                Engine.GetService<CameraManager>().Camera.enabled = false;
            }
        }
    }
}