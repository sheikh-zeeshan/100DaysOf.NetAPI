namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

        int number = 127;
        int result = MultiplyDigits(number);
        Console.WriteLine(result);  

    }

    int MultiplyDigits(int num)
    {
        if (num < 10)
        {
            return num;   
        }

        int product = 1;

        while (num > 0)
        {
            int digit = num % 10;   
            product *= digit;       
            num /= 10;             
        }

        return MultiplyDigits(product);
    }
}