namespace Dependency_Injection
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
            Console.WriteLine($"MyDependency.WriteMessage Message1: {message}");
        }
    }
}
