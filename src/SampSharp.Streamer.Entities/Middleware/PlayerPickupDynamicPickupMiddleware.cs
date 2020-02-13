﻿// SampSharp.Streamer
// Copyright 2020 Tim Potze
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

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    internal class PlayerPickupDynamicPickupMiddleware
    {
        private readonly ArgumentsOverrideEventContext _context = new ArgumentsOverrideEventContext(2);
        private readonly EventDelegate _next;

        public PlayerPickupDynamicPickupMiddleware(EventDelegate next)
        {
            _next = next;
        }

        public object Invoke(EventContext context)
        {
            var inArgs = context.Arguments;

            var playerEntity = SampEntities.GetPlayerId((int)inArgs[0]);
            var pickupEntity = StreamerEntities.GetDynamicPickupId((int)inArgs[1]);

            if (pickupEntity == null)
                return null;

            _context.BaseContext = context;

            var args = _context.Arguments;
            args[0] = playerEntity;
            args[1] = pickupEntity;

            return _next(_context);
        }
    }
}