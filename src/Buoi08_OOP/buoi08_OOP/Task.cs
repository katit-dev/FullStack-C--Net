class Task
{
    public string Name { get; set; }
    public bool Status { get; set;  }

    public Task(string name)
    {
        Name = name;
        Status = false; // mặc định là chưa hoàn thành
    }

    public void MarkAsCompleted()
    {
        Status = true;
    }

    public void Display()
    {
        string statusText = Status ? "Completed" : "Pending";
        System.Console.WriteLine($"Name of task: {Name}, Status: {statusText}");
    }

    
}