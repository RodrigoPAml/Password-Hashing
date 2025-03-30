using System.Diagnostics;

namespace Hashers
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Testing algorithms\n");

            var password = "j&3hc#k$syurh34";

            // Hash passwords for test
            var md5 = Md5.HashPassword(password);
            var sha1 = Sha1.HashPassword(password);
            var sha256 = Sha256.HashPassword(password);
            var sha512 = Sha512.HashPassword(password);
            var pbkdf2 = Pbkdf2.HashPassword(password);
            var bcrypt = BCrypt.HashPassword(password);
            var scrypt = Scrypt.HashPassword(password);
            var argon2 = Argon2.HashPassword(password);

            // Print hashes
            Console.WriteLine($"MD5: {md5}");
            Console.WriteLine($"SHA1: {sha1}");
            Console.WriteLine($"SHA256: {sha256}");
            Console.WriteLine($"SHA512: {sha512}");
            Console.WriteLine($"PBKDF2: {pbkdf2}");
            Console.WriteLine($"BCRYPT: {bcrypt}");
            Console.WriteLine($"SCRYPT: {scrypt}");
            Console.WriteLine($"ARGON2: {argon2}");
            Console.WriteLine("\nVerifiy if its working\n");

            // Verify if its working
            Console.WriteLine($"MD5: {Md5.VerifyPassword(password, md5)}");
            Console.WriteLine($"SHA1: {Sha1.VerifyPassword(password, sha1)}");
            Console.WriteLine($"SHA256: {Sha256.VerifyPassword(password, sha256)}");
            Console.WriteLine($"SHA512: {Sha512.VerifyPassword(password, sha512)}");
            Console.WriteLine($"PBKDF2: {Pbkdf2.VerifyPassword(password, pbkdf2)}");
            Console.WriteLine($"BCRYPT: {BCrypt.VerifyPassword(password, bcrypt)}");
            Console.WriteLine($"SCRYPT: {Scrypt.VerifyPassword(password, scrypt)}");
            Console.WriteLine($"ARGON2: {Argon2.VerifyPassword(password, argon2)}");

            // Benchmark
            Console.WriteLine("\nBenchmarking algorithms");

            PrintBenchmarks(() => Md5.HashPassword(password), "Md5");
            PrintBenchmarks(() => Sha1.HashPassword(password), "Sha1");
            PrintBenchmarks(() => Sha256.HashPassword(password), "Sha256");
            PrintBenchmarks(() => Sha512.HashPassword(password), "Sha512");
            PrintBenchmarks(() => Pbkdf2.HashPassword(password), "Pbkdf2");
            PrintBenchmarks(() => BCrypt.HashPassword(password), "BCrypt");
            PrintBenchmarks(() => Scrypt.HashPassword(password), "Scrypt");
            PrintBenchmarks(() => Argon2.HashPassword(password), "Argon2");
        }

        static void PrintBenchmarks(Action hashMethod, string methodName, int sampleTime = 2_000)
        {
            var hashes = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while(stopwatch.ElapsedMilliseconds < sampleTime)
            {
                hashMethod();
                hashes++;
            }

            double seconds = stopwatch.ElapsedMilliseconds/1000;
            Console.WriteLine($"{methodName}: {hashes / (double)seconds} hashes/seconds");
        }
    }
}