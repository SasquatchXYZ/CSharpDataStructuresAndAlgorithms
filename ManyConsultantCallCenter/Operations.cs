using static ManyConsultantCallCenter.Utilities;

namespace ManyConsultantCallCenter;

public class Operations
{
    private readonly Random _random = new();

    public void Clients(CallCenter callCenter)
    {
        while (true)
        {
            var clientId = _random.Next(1, 10000);
            var call = callCenter.Call(clientId);
            Log($"Incoming call #{call.Id} from client #{clientId}");
            Log($"Waiting calls in the queue: {callCenter.Calls.Count}");
            Thread.Sleep(_random.Next(500, 2000));
        }
    }

    public void Consultant(CallCenter callCenter, string name, ConsoleColor color)
    {
        while (true)
        {
            Thread.Sleep(_random.Next(500, 1000));
            var call = callCenter.Answer(name);
            if (call is null) continue;

            Log($"Call #{call.Id} from client #{call.ClientId} answered by {call.Consultant}.", color);
            Thread.Sleep(_random.Next(500, 2000));
            callCenter.End(call);
            Log($"Call #{call.Id} from client #{call.ClientId} ended by {call.Consultant}.", color);
        }
    }
}
