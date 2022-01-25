using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params int[] messageArray)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if(messageArray.Length == 0)
        { 
            logger.Log(LogLevel.Error, message); 
        }
        else
        {
            foreach(var element in messageArray)
            {
               string fullMessage = string.Format(message, element);
               logger.Log(LogLevel.Error, fullMessage);
            }
        }
        
    }
    public static void Warning(this BaseLogger? logger, string message, params int[] messageArray)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (messageArray.Length == 0)
        {
            logger.Log(LogLevel.Warning, message);
        }
        else
        {
            foreach (var element in messageArray)
            {
                string fullMessage = string.Format(message, element);
                logger.Log(LogLevel.Warning, fullMessage);
            }
        }

    }

    public static void Information(this BaseLogger? logger, string message, params int[] messageArray)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (messageArray.Length == 0)
        {
            logger.Log(LogLevel.Information, message);
        }
        else
        {
            foreach (var element in messageArray)
            {
                string fullMessage = string.Format(message, element);
                logger.Log(LogLevel.Information, fullMessage);
            }
        }

    }

    public static void Debug(this BaseLogger? logger, string message, params int[] messageArray)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (messageArray.Length == 0)
        {
            logger.Log(LogLevel.Debug, message);
        }
        else
        {
            foreach (var element in messageArray)
            {
                string fullMessage = string.Format(message, element);
                logger.Log(LogLevel.Debug, fullMessage);
            }
        }

    }

}
