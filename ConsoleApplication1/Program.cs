using System;
using System.Numerics;
using System.Diagnostics;


namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var Timer = Stopwatch.StartNew();
			collatzSequence();
			Timer.Stop();
			HowFast(Timer);

			Timer.Restart();
			var answer = calculate(1000000);
			Console.WriteLine("The answer is {0:0,0}",answer);
			Timer.Stop();
			HowFast(Timer);
			
			
			Console.ReadLine();	
		}

		static void HowFast(Stopwatch time)
		{
			var TS = time.Elapsed;
			Console.WriteLine(" min:  {1:00}  sec:  {2:00}  ms: {3}", TS.Hours, TS.Minutes, TS.Seconds, TS.Milliseconds);
		}
		public static void nthDigitFibonacci(BigInteger firstVal, BigInteger secondVal, int totalDigits)
		{
			var count = 2;
			var stop = false;
			var digits = new BigInteger();
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
			var count = 2;
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
			var sqrt = (int)Math.Sqrt(value);
				if(value == 0)
					return false;
				else if(value == 1)
					return false;
				else if( value == 2)
					return true;
			for(var i = 2; i <= sqrt; i++)
			{
				 if( value % i == 0)
					return false;
			}
			return true;
		}
		public static void primeNumbers(int totalNumOfPrime)
		{
			var count = 1;
			long sum = 0;
			var prime = false;
			for(var i = 3; i < totalNumOfPrime; i+=2)
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
		public static void smallestMultiple(int fromOneToParam)
		{
		// find the smallest positive number that is Evenly divisible by all of the numbers from 1 to 'value'(for example 20)
		// outer loop is infinite and will increment i by 20 every iteration. the inner loop will go from 1 to 20 seeing if 'i' is 
		// divisible by that number. if we find one number from 1 to 20 that's i is not divisble by. Break out of inner loop 
		// and go to the next value. 		
			
			
			
			var foundValue = false;
			int answer;
			
			for(var i = fromOneToParam; ; i+=fromOneToParam) // no clue where this should stop so infinite loop till i say otherwise
			{
					for(var counter = 1; counter < fromOneToParam; counter++)
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
			Console.WriteLine("Smallest divisible value from 1 to {0:D} is {1:D}", fromOneToParam, answer);

		}
		static void powerDigitSum(int num, int raisedTo)
		{
			var total = BigInteger.Pow(num,raisedTo);
			var sum = 0;
			var numbers = total.ToString();
			//char[] stringToChar = new char[numbers.Length];
			//stringToChar = numbers.ToCharArray();

			foreach(var c in numbers)
			{
				
				sum+= (int)char.GetNumericValue(c);
			}

			Console.Write(" The sum of each digit from {0:0}^{1:0,0} is {2:0,0}\n",num,raisedTo,sum);
		}
		static bool isOdd(int num)
		{
			if (num%2 != 0)
				return true;
			else 
				return false;
		}
		static bool isEven(BigInteger num)
		{
			if (num%2 == 0)
				return true;
			else
				return false;
		}
		static int calculate(int limit)
		{
			var sequence = new int[limit];
			sequence[1] = 1;
			var max = 0;
			var maxIndex = 1;

			for (var i = 2; i < limit; i++)
			{
				long index = i;
				var chain = 0;
				while (true)
				{
					if (index < i)
					{
						chain += sequence[index];
						break;
					}

					//Optimization for: index = index % 2 == 0 ? index / 2 : 3 * index + 1
					index = (index & 1) == 0 ? index >> 1 : index + (index << 1) + 1;

					chain++;
				}
				sequence[i] = chain;

				if (chain > max)
				{
					max = chain;
					maxIndex = i;
				}
			}

			return maxIndex;
		}

		static void collatzSequence()
		{
			int chain = 0;
			int max = 0;
			int maxValue = 0;
			long icopy = 0;

			for (int i = 3; i < 1000000; i++)
			{
			    icopy = i;
				chain = 1;
				while (icopy > 1)
				{

				icopy = (icopy%2 == 0) ?  icopy /2 : icopy * 3 + 1;
				chain++;
				}
				if (chain > max)
				{
					max = chain;
					maxValue = i;
				}
			}

			Console.WriteLine("The value with the longest chain under 1m is {0:0,0} and it's chain was {1:0,0}", maxValue, max);
		}
	}
}
