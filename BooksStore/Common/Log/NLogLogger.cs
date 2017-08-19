using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Common.Log
{
    public class NLogLogger:ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            logger.Debug(exception, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            logger.Fatal(exception, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            logger.Info(exception, message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            logger.Warn(exception, message);
        }
    }
}