while (true)
{
    Console.Write("Введите Число экспертов: ");
    int experts = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    Console.Write("Введите число целей: ");
    int aims = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    double[,] matrix = new double[experts, aims];
    for (int i = 0; i < experts; i++)
    {
        for (int j = 0; j < aims; j++)
        {
            Console.Write("Введите значение " + (i + 1).ToString() + " " + (j + 1).ToString() + ":");
            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
        }
    }
    Console.Clear();

    for (int i = 0; i < experts; i++)
    {
        for (int j = 0; j < aims; j++)
        {
            matrix[i, j] = Convert.ToDouble(Convert.ToDouble(aims) - matrix[i,j]);
        }
    }

    double[,] sums = new double[2,aims];
    for(int i = 0; i < aims; i++)
    {
        for(int j = 0; j < experts; j++)
        {
            sums[0,i] = sums[0,i] + matrix[j, i];
        }
        sums[1, i] = i + 1;
    }
    double sum = 0;
    for(int i = 0; i < aims; i++)
    {
        sum = sum + sums[0,i];
    }

    for(int i = 0; i < aims; i++)
    {
        sums[0, i] = sums[0, i] / sum;
    }

    for (int i = 0; i < aims; i++)
    {
        for (int j = 0; j < aims - 1; j++)
        {
            if (sums[0, j] < sums[0, j + 1])
            {
                double t = sums[0, j + 1];
                sums[0, j + 1] = sums[0, j];
                sums[0, j] = t;
                t = sums[1, j + 1];
                sums[1, j + 1] = sums[1, j];
                sums[1, j] = t;
            }
        }
    }
    Console.WriteLine("Наиболее выгодная цель: " + sums[1, 0]);
    Console.WriteLine("Завершить работу? +/-");
    string ans = Console.ReadLine();
    if (ans == "-")
    {
        Console.Clear();
    }
    else { break; }
}
