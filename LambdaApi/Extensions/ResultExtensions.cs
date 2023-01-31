using LambdaApi.Application.Dto.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaApi.Extensions
{

    public static class ResultExtensions
    {
        public static async Task<IResult> ToHttpResult<TData>(this Task<TData> resultTask)
        {
            var result = await resultTask;

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        public static async Task<IResult> ToHttpResult(this Task<Result> resultTask)
        {
            var result = await resultTask;

            if (!result.Succeeded)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        public static async Task<IResult> ToHttpResult<TData>(this Task<Result<TData>> resultTask)
        {
            var result = await resultTask;

            if (!result.Succeeded)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }


        public static IResult ToHttpResult<TData>(this TData result)
        {
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        public static IResult ToHttpResult(this Result result)
        {
            if (!result.Succeeded)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        public static IResult ToHttpResult<TData>(this Result<TData> result)
        {
            if (!result.Succeeded)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }
    }
}
