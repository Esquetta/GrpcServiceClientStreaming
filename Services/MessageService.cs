using Grpc.Core;
using static GrpcServiceClientStreaming.Message;

namespace GrpcServiceClientStreaming.Services
{
    public class MessageService:MessageBase
    {

        public override async Task<MessageResponse> GetMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        {
            await Task.Run(async () => {

                while (await requestStream.MoveNext())
                {
                    Console.WriteLine($"Mesaj alınmıştır.");
                    Console.WriteLine("Gelen mesaj : ");
                    Console.WriteLine(requestStream.Current.Message);
                }
            
            });

            return new MessageResponse { Message = "İstek alındı ve işlendi..." };
        }
    }
}
