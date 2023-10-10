namespace imagesharp;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Program
{
  [Params(1024, 4096, 16384)]
  public uint SIZE = 1024;
  private byte[] vec_a;
  private byte[] vec_b;

  [GlobalSetup]
  public void Setup()
  {
    vec_a = new byte[SIZE];
    vec_b = new byte[SIZE];
    Random.Shared.NextBytes(vec_a);
    Random.Shared.NextBytes(vec_b);
  }

  [Benchmark]
  public void DecodeAvx()
  {
	UpFilter.DecodeAvx2(vec_a, vec_b);
  }

  [Benchmark]
  public void DecodeAvx512()
  {
	UpFilter.DecodeAvx512(vec_a, vec_b);
  }

  [Benchmark]
  public void DecodeScalar()
  {
	UpFilter.DecodeScalar(vec_a, vec_b);
  }

    
    static void Main(string[] args)
    {

#if false


	//UpFilter.DecodeAvx2(vec_a, vec_b);
	//UpFilter.DecodeAvx512(vec_a, vec_b);
	UpFilter.DecodeScalar(vec_a, vec_b);

	for (int i = 0; i < vec_a.Length; i++) {
	  Console.Write($"{vec_a[i]} ");
	}
        Console.WriteLine("\nHello, World!");
#endif
	BenchmarkRunner.Run<Program>();
    }
}
