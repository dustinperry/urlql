﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace urlql.asp.core
{
    public static class QueryResolverExtensions
    {
        /// <summary>
        /// Returns QueryResolver.GetResult() as a QueryResultViewModel
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static QueryResultViewModel GetQueryResultViewModel(this QueryResolver resolver)
        {
            return resolver.GetResults().AsViewModel();
        }

        /// <summary>
        /// Returns QueryResolver.GetResultAsync() as a QueryResultViewModel
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public async static Task<QueryResultViewModel> GetQueryResultViewModelAsync(this QueryResolver resolver)
        {
            return (await resolver.GetResultsAsync()).AsViewModel();
        }

        /// <summary>
        /// Returns QueryResolver.GetResult() as a QueryResultViewModel within an IActionResult
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns>IActionResult of OkObjectResult containing the a QueryResultViewModel
        /// or IActionResult of BadRequestObjectResult containing an error message
        /// </returns>
        public static IActionResult GetIActionResult(this QueryResolver resolver)
        {
            try
            {
                return new OkObjectResult(resolver.GetResults().AsViewModel());
            }
            catch (QueryException qEx)
            {
                return new BadRequestObjectResult(qEx.Message);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Returns QueryResolver.GetResultAsync() as a QueryResultViewModel within an IActionResult
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns>IActionResult of OkObjectResult containing the a QueryResultViewModel
        /// or IActionResult of BadRequestObjectResult containing an error message
        /// </returns>
        public async static Task<IActionResult> GetIActionResultAsync(this QueryResolver resolver)
        {
            try
            {
                return new OkObjectResult((await resolver.GetResultsAsync()).AsViewModel());
            }
            catch (QueryException qEx)
            {
                return new BadRequestObjectResult(qEx.Message);
            }
            catch
            {
                throw;
            }
        }
    }
}
