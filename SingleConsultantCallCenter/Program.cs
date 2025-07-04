using static SingleConsultantCallCenter.Utilities;
using SingleConsultantCallCenter;

var random = new Random();
var center = new CallCenter();
center.Call(1234);
center.Call(5678);
center.Call(1468);
center.Call(9641);

while (center.AreWaitingCalls())
{
    var call = center.Answer("Dalton")!;
    Log($"Call #{call.Id} from client #{call.ClientId} answered by {call.Consultant}.");
    await Task.Delay(random.Next(1000, 10000));
    center.End(call);
    Log($"Call #{call.Id} from client #{call.ClientId} ended by {call.Consultant}.");
}
