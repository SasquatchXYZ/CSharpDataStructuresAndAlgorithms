using System.Collections.Concurrent;

namespace ManyConsultantCallCenter;

public class CallCenter
{
    public CallCenter()
    {
        Calls = new ConcurrentQueue<IncomingCall>();
    }

    private int _counter = 0;
    public ConcurrentQueue<IncomingCall> Calls { get; private set; }

    public IncomingCall Call(int clientId)
    {
        var call = new IncomingCall
        {
            Id = ++_counter,
            ClientId = clientId,
            CallTime = DateTime.Now,
        };

        Calls.Enqueue(call);
        return call;
    }

    public IncomingCall? Answer(string consultant)
    {
        if (!Calls.IsEmpty && Calls.TryDequeue(out var call))
        {
            call.Consultant = consultant;
            call.AnswerTime = DateTime.Now;
            return call;
        }

        return null;
    }

    public void End(IncomingCall call) =>
        call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => !Calls.IsEmpty;
}
