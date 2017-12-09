// SampSharp.Streamer
// Copyright 2017 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using SampSharp.GameMode.Controllers;
using SampSharp.Streamer.World;

namespace SampSharp.Streamer.Controllers
{
    public class DynamicCheckpointController : ITypeProvider, IStreamerController
    {
        #region Implementation of IStreamerController

        public void RegisterStreamerEvents(IStreamer streamer)
        {
            streamer.PlayerEnterDynamicCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicCheckpoint;
                checkpoint?.OnEnter(args);
            };
            streamer.PlayerLeaveDynamicCheckpoint += (sender, args) =>
            {
                var checkpoint = sender as DynamicCheckpoint;
                checkpoint?.OnLeave(args);
            };
        }

        #endregion

        #region Implementation of ITypeProvider

        /// <summary>
        ///     Registers types this <see cref="T:SampSharp.GameMode.Controllers.ITypeProvider" /> requires the system to use.
        /// </summary>
        public void RegisterTypes()
        {
            DynamicCheckpoint.Register<DynamicCheckpoint>();
        }

        #endregion
    }
}