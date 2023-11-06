using System;
using System.Net;

namespace AppCore;

public class AppApiResponse<T>
{
	public HttpStatusCode  StatusCode { get; set; }
	public string StatusMessage { get; set; }
	public T Data { get; set; }

	public AppApiResponse(HttpStatusCode httpStatusCode, string message, T data)
	{
		StatusCode = httpStatusCode;
		StatusMessage = message;
		Data = data;
    }

	public static AppApiResponse<T> Create(HttpStatusCode statusCode, string message, T data)
	{
		return new AppApiResponse<T>(statusCode, message, data);
	}
}

