﻿using System.Text.Json;

namespace TestProjectAPI.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? ExceptionMessage { get; set; }
        public LobitekException? LobitekException { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
