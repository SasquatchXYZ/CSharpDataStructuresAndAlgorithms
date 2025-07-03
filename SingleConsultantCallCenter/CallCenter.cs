namespace SingleConsultantCallCenter;

public class CallCenter
{
    public CallCenter()
    {
        Calls = new Queue<IncomingCall>();
    }

    private int _counter = 0;
    public Queue<IncomingCall> Calls { get; private set; }

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
