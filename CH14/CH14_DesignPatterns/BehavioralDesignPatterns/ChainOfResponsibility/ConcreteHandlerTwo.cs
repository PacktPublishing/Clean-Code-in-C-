using System;

namespace CH14_DesignPatterns.BehavioralDesignPatterns.ChainOfResponsibility
{
    public class ConcreteHandlerTwo : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "PrintDate")
                Console.WriteLine($"ConcreteHandlerTwo handled the {request} request.");
            else
                successor?.HandleRequest(request);
        }
    }
}
