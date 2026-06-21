class QuanLyTasks
{

    // properties: danh sách công việc (list), số lượng công việc (int)
    public List<Task> TaskList { get; set; } = new List<Task>();

    public QuanLyTasks()
    {

    }

    // methods: thêm công việc, hiển thị công việc, 
    public void ThemCongViec(string taskName)
    {
        Task newTask = new Task(taskName);
        TaskList.Add(newTask);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{taskName} đã được thêm vào danh sách công việc.");
        Console.ResetColor();
    }


    // mark công việc là hoàn thành
    public void HoanThanhCongViec(int indexTask)
    {
        var task = TaskList[indexTask];
        if (task != null)
        {
            task.MarkAsCompleted();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{task} đã được đánh dấu là hoàn thành.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Công việc tại vị trí {indexTask + 1} không tìm thấy.");
        }
    }

    // hiển thị công việc
    public void HienThiCongViec()
    {
        Console.WriteLine("Danh sách công việc:");
        for (int i = 0; i < TaskList.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            TaskList[i].Display();
        }
    }

    // hien thi menu
    public void HienThiMenu()
    {


        int choice; // 

        do
        {
            Console.WriteLine("===== Quản Lý Công Việc =====");
            Console.WriteLine("1. Thêm công việc");
            Console.WriteLine("2. Hiển thị công việc");
            Console.WriteLine("3. Hoàn thành công việc");
            Console.WriteLine("4. Thoát");
            Console.WriteLine("=============================");
            var checkInput = int.TryParse(Console.ReadLine(), out choice);
            if (!checkInput)
            {
                Console.WriteLine("Vui lòng nhập số từ 1 đến 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Nhập tên công việc: ");
                    string? taskName = Console.ReadLine();
                    ThemCongViec(taskName);
                    break;
                case 2:
                    HienThiCongViec();
                    break;
                case 3:
                    Console.Write("Nhập số thứ tự công việc đã hoàn thành: ");
                    if (int.TryParse(Console.ReadLine(), out int indexTask))
                    {
                        HoanThanhCongViec(indexTask - 1);
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập số hợp lệ.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

        } while (choice != 4);
    }

}