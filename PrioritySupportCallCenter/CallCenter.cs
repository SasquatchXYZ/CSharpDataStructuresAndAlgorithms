using Priority_Queue;

namespace PrioritySupportCallCenter;

public class CallCenter
{
    public CallCenter()
    {
        Calls = new SimplePriorityQueue<IncomingCall>();
    }

    private int _counter = 0;
    public SimplePriorityQueue<IncomingCall> Calls { get; private set; }

    public IncomingCall Call(int clientId, bool isPriority)
    {
        var call = new IncomingCall
        {
            Id = ++_counter,
            ClientId = clientId,
            CallTime = DateTime.Now,
            IsPriority = isPriority,
        };

        Calls.Enqueue(call, isPriority ? 0 : 1);
        return call;
    }

    public IncomingCall? Answer(string consultant)
    {
        if (!AreWaitingCalls()) return null;

        var call = Calls.Dequeue();
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    public void End(IncomingCall call) =>
        call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => Calls.Count > 0;
}
