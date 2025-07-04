using static PrioritySupportCallCenter.Utilities;
using PrioritySupportCallCenter;

var random = new Random();
var center = new CallCenter();

center.Call(clientId: 1234, isPriority: false);
center.Call(clientId: 5678, isPriority: true);
center.Call(clientId: 1468, isPriority: false);
center.Call(clientId: 9641, isPriority: true);

while (center.AreWaitingCalls())
{
    var call = center.Answer("Dalton")!;

    Log($"Call #{call.Id} from client #{call.ClientId} answered by {call.Consultant}.", call.IsPriority);
    await Task.Delay(random.Next(1000, 10000));
    center.End(call);
    Log($"Call #{call.Id} from client #{call.ClientId} ended by {call.Consultant}.", call.IsPriority);
}
