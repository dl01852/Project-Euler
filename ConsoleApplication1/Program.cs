using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;


namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Stopwatch Timer = Stopwatch.StartNew();
			//primeNumbers(20000000);
			PowerDigitSum(2,1000);
			Timer.Stop();
			HowFast(Timer);
			Console.ReadLine();	
			//fibonacciNumbers(12,1,1);	
			//nthDigitFibonacci(1,1,1000);
		
		}

		static void HowFast(Stopwatch time)
		{
			TimeSpan TS = time.Elapsed;
			Console.WriteLine(" min:  {1:00}  sec:  {2:00}  ms: {3}", TS.Hours, TS.Minutes, TS.Seconds, TS.Milliseconds);
		}
		public static void nthDigitFibonacci(BigInteger firstVal, BigInteger secondVal, int totalDigits)
		{
			int count = 2;
			bool stop = false;
			BigInteger digits = new BigInteger();
			digits = BigInteger.Pow(10,(totalDigits - 1));
			while (!stop)
			{
				firstVal += secondVal;
				secondVal += firstVal;
				count += 2;
				if(firstVal >= digits)
				{
					Console.WriteLine("First  term with with 1000 digits is at index: {0:D} ", (count - 1));
					stop = true;
				}else if(secondVal >= digits)
				{
					Console.WriteLine("First term with 1000 digits is at index {0:D}", count);
					stop = true;
				}
			}
		}
		public static void fibonacciNumbers(int start, int firstVal, int secondVal)
		{
			int count = 2;
			Console.Write(firstVal + " ");
			Console.Write(secondVal + " ");
			while(count < start)
			{
				
				firstVal += secondVal;
				secondVal += firstVal;
				Console.Write(firstVal + " " + secondVal + " ");
				count+=2;
			}
		}
		public static void primeFactorization(int value)
		{
//			function primeFactorization(value)
			//{
	
			//	var copy = value;
			//	for(var i  = 2; i < copy; i++)
			//	{
			//	if(copy % i === 0)
			//  {
			//  copy /= i;
			//  store.push(i);
			//  }
			//  }
			//	store.push(i);
			//	return i; 
			//}

		}
		public static bool isPrime(int value)
		{
			int sqrt = (int)Math.Sqrt(value);
				if(value == 0)
					return false;
				else if(value == 1)
					return false;
				else if( value == 2)
					return true;
			for(int i = 2; i <= sqrt; i++)
			{
				 if( value % i == 0)
					return false;
			}
			return true;
		}
		public static void primeNumbers(int totalNumOfPrime)
		{
			int count = 1;
			long sum = 0;
			bool prime = false;
			for(int i = 3; i < totalNumOfPrime; i+=2)
			{			
				prime = isPrime(i);
				if(prime)
				{	// if value was prime... display that number.
					//Console.Out.Write(i + " ");
					sum+= i;
					count++; 
				}
			}
			Console.WriteLine("Total prime numbers displayed is: {0:D}",count);
			Console.WriteLine("The sum of all {0:D} primes below {1:0,0} is {2:0,0}",count,totalNumOfPrime, sum);
		
	}

		public static void smallestMultiple(int value)
		{
		
			bool foundValue = false;
			int answer;
			
			for(int i = value; ; i+=value) // no clue where this should stop so infinite loop till i say otherwise
			{
					for(int counter = 1; counter < value; counter++)
				{
					if(i % counter == 0) // check from 1 to value to see if divisible.
					{
						
						foundValue = true; // if it is then cool.
					}
					else
					{
						foundValue = false; // if we find one value that's not divisible break out of loop
						break;
					}
				}
				if(foundValue) // if we found the value, lets grab that value and break out of our infinite loop.
				{
					answer = i;
					break;
					
				}
			}
			Console.WriteLine("Smallest divisible value from 1 to {0:D} is {1:D}", value, answer);

		}

		static void PowerDigitSum(int num, int raisedTo)
		{
			BigInteger total = BigInteger.Pow(num,raisedTo);
			int sum = 0;
			string numbers = total.ToString();
			//char[] stringToChar = new char[numbers.Length];
			//stringToChar = numbers.ToCharArray();

			Console.WriteLine(num + "\u2077");
			foreach(char c in numbers)
			{
				
				sum+= (int)char.GetNumericValue(c);
			}

			Console.Write(" The sum of each digit from {0:0}^{1:0,0} is {2:0,0}\n",num,raisedTo,sum);
		}
	}
}
