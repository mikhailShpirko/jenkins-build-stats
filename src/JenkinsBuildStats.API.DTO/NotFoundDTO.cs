﻿namespace JenkinsBuildStats.API.DTO
{
    public class NotFoundDTO
    {
        public string Message { get; }
        public NotFoundDTO(string message)
        {
            Message = message;
        }
    }
}
