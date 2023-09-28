namespace imagesharp;

class Program
{
    static void Main(string[] args)
    {
	const uint SIZE = 1024;
	var vec_a = new byte[SIZE];
	var vec_b = new byte[SIZE];
	Random.Shared.NextBytes(vec_a);
	Random.Shared.NextBytes(vec_b);

	//UpFilter.DecodeAvx2(vec_a, vec_b);
	//UpFilter.DecodeAvx512(vec_a, vec_b);
	UpFilter.DecodeScalar(vec_a, vec_b);

	for (int i = 0; i < vec_a.Length; i++) {
	  Console.Write($"{vec_a[i]} ");
	}
        Console.WriteLine("\nHello, World!");
    }
}
