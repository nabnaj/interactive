﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive.Commands;

namespace Microsoft.DotNet.Interactive.App.Commands
{
    public class Quit : KernelCommandBase
    {
        internal static IDisposable DisposeOnQuit { get; set; }
       
        private static Action _defaultOnQuit = () =>
        {
            Environment.Exit(0);
        };

        public Quit(string targetKernelName = null): base(targetKernelName)
        {
            Handler = (command, context) =>
            {
                context.Complete(context.Command);
                DisposeOnQuit?.Dispose();
                Environment.Exit(0);
                return Task.CompletedTask;
            };
        }
    }
}