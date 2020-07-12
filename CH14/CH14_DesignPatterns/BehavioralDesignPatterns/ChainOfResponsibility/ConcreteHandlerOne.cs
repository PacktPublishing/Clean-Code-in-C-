using System;

namespace CH14_DesignPatterns.BehavioralDesignPatterns.ChainOfResponsibility
{
    public class ConcreteHandlerOne : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "PrintGreeting")
                Console.WriteLine($"ConcreteHandlerOne handled the {request} request.");
            else
                successor?.HandleRequest(request);
        }
    }
}
