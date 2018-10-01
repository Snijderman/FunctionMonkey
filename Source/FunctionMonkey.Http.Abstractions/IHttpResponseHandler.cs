﻿using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FunctionMonkey.Http.Abstractions
{
    public interface IHttpResponseHandler
    {
        /// <summary>
        /// Invoked when a command generates an exception during its execution.
        /// Return an IActionResult for custom behaviour otherwise return null for the default framework behaviour
        /// </summary>
        /// <typeparam name="TCommand">The type of the command</typeparam>
        /// <param name="command">The command</param>
        /// <param name="ex">The exception that was thrown</param>
        /// <returns>An action result or null for the default Function Monkey behaviour</returns>
        Task<IActionResult> CreateResponse<TCommand>(TCommand command, Exception ex) where TCommand : ICommand;

        /// <summary>
        /// Invoked when a command with an associated result is successfully invoked.
        /// Return an IActionResult for custom behaviour otherwise return null for the default framework behaviour
        /// </summary>
        /// <typeparam name="TCommand">The type of the command</typeparam>
        /// <typeparam name="TResult">The type of the result</typeparam>
        /// <param name="command">The command</param>
        /// <param name="result">The result</param>
        /// <returns>An action result or null for the default Function Monkey behaviour</returns>
        Task<IActionResult> CreateResponse<TCommand, TResult>(TCommand command, TResult result) where TCommand : ICommand<TResult>;

        /// <summary>
        /// Invoked when a command with no associated result is successfully invoked.
        /// Return an IActionResult for custom behaviour otherwise return null for the default framework behaviour.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command</typeparam>
        /// <param name="command">The command</param>
        /// <returns>An action result or null for the default Function Monkey behaviour</returns>
        Task<IActionResult> CreateResponse<TCommand>(TCommand command);
    }
}
