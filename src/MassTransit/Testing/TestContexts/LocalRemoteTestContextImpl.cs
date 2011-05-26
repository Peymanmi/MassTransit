﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Testing.TestContexts
{
	using Transports;

	public class LocalRemoteTestContextImpl :
		EndpointTestContextImpl,
		LocalRemoteTestContext
	{
		bool _disposed;

		public LocalRemoteTestContextImpl(IEndpointFactory endpointFactory)
			: base(endpointFactory)
		{
		}

		public IServiceBus LocalBus { get; set; }
		public IServiceBus RemoteBus { get; set; }

		protected override void Dispose(bool disposing)
		{
			if (_disposed) return;
			if (disposing)
			{
				if (RemoteBus != null)
					RemoteBus.Dispose();

				if (LocalBus != null)
					LocalBus.Dispose();

				base.Dispose(true);
			}

			_disposed = true;
		}

		~LocalRemoteTestContextImpl()
		{
			Dispose(false);
		}
	}
}