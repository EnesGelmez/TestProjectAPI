using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RabbitMQ.Client;
using System.Text;
using System;
using Newtonsoft.Json;

namespace TestProjectAPI.Models
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            var error = new Error();
            switch (exceptionContext.Exception)
            {
                case LobitekException:
                    var lobitekException = exceptionContext.Exception as LobitekException;
                    switch (lobitekException.StatusCode)
                    {
                        case 100:
                            error.StatusCode = lobitekException.StatusCode;
                            error.Message = "Lobitek Erros";
                            error.ExceptionMessage = exceptionContext.Exception.Message;
                            error.LobitekException = lobitekException;
                            break;
                        default:
                            var factory = new ConnectionFactory() { HostName = "localhost" };
                            using (IConnection connection = factory.CreateConnection())
                            using (IModel channel = connection.CreateModel())
                            {
                                channel.QueueDeclare(queue: "Borsoft",
                                                     durable: false,
                                                     exclusive: false,
                                                     autoDelete: false,
                                arguments: null);

                                string message = "Test deneme";
                                var body = Encoding.UTF8.GetBytes(message);

                                channel.BasicPublish(exchange: "",
                                                     routingKey: "Borsoft",
                                                     basicProperties: null,
                                                     body: body);
                                Console.WriteLine($"Gönderilen kişi: Enes Gelmez");
                            }

                            Console.WriteLine(" İlgili kişi gönderildi...");
                            Console.ReadLine();
                            error.StatusCode = lobitekException.StatusCode;
                            error.Message = "Lobitek Erros";
                            error.ExceptionMessage = exceptionContext.Exception.Message;
                            break;
                    }
                    //
                    break;
                default:
                    error.StatusCode = 400;
                    error.Message = exceptionContext.Exception.Message;
                    break;
            }

            exceptionContext.Result = new JsonResult(error)
            {
                StatusCode = 1000,
            };
        }
    }
}
