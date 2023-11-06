using System;
namespace AppCore;

public class AppExtention : Exception
{
	public AppExtention()
	{
	}
    public AppExtention(string message)
        :base(message)
    {
    }

    public AppExtention(string message, Exception innerexception)
       : base(message, innerexception)
    {
    }

}

