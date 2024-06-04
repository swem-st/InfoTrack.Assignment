using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace InfoTrack.Assignment.Core.Exceptions;

[DebuggerNonUserCode]

public class HttpExceptions
{
    #region Exceptions
    /// <summary>
    /// creates an <see cref="HttpResponseException"/> with a response code of 400
    /// and places the reason in the reason header and the body.
    /// </summary>
    /// <param name="reason">Explanation text for the client.</param>
    /// <returns>A new HttpResponseException</returns>
    public static HttpResponseException BadRequest(string reason)
    {
        return CreateHttpResponseException(reason, HttpStatusCode.BadRequest);
    }

    public static HttpResponseException StandardInternalError(string reason)
    {
        var finalReason = $"Well, this is embarrassing. {reason}, our engineering department has been informed and normal service will resume shortly.";

        return CreateHttpResponseException(finalReason, HttpStatusCode.InternalServerError);
    }
    #endregion

    /// <summary>
    /// Creates an <see cref="HttpResponseException"/> to be thrown by the api.
    /// </summary>
    /// <param name="reason">Explanation text, also added to the body.</param>
    /// <param name="code">The HTTP status code.</param>
    /// <returns>A new <see cref="HttpResponseException"/></returns>
    private static HttpResponseException CreateHttpResponseException(string reason, HttpStatusCode code)
    {
        var response = new HttpResponseMessage
        {
            StatusCode = code,
            ReasonPhrase = reason,
            Content = new StringContent(reason)
        };

        throw new HttpResponseException(response);
    }
}