# Password Hashing Methods

 Repository to provide hashing algorithms in C# easily, focused in the context of password hashing.

 It comes with a basic hashing class and benchmark tests.

## Reasons for Using Hashing Algorithms

1. **Data Integrity**: Hashing ensures that data has not been altered or tampered with by generating a unique hash value for the original data. Any modification to the data results in a different hash, allowing verification of integrity.

2. **Efficient Data Retrieval**: Hashing is used in data structures like hash tables to enable fast data lookups. By hashing keys, these structures can quickly retrieve corresponding values.

3. **Password Storage**: Instead of storing passwords in plain text, systems hash passwords before storing them. Even if a database is compromised, the original passwords remain secure due to the difficulty of reversing the hash.

4. **Digital Signatures and Certificates**: Hashing is integral to creating digital signatures, which verify the authenticity and integrity of messages or documents in encryption systems.

5. **Checksum and Error Detection**: Hashes are used in checksums to verify that files or messages have been transmitted without errors. If the computed hash on the receiving end matches the original hash, the data is considered error-free.

6. **Cryptographic Applications**: Cryptographic hashing algorithms are used in blockchain technologies, securing transactions, and creating links between blocks of data.

7. **Data Deduplication**: Hashes are used to identify duplicate data by comparing hash values, helping in reducing storage space by storing only unique data.

8. **Content Addressing**: Hashing is used to generate unique identifiers for pieces of content (like files or documents) in distributed systems, ensuring that each piece of content can be referenced and retrieved accurately.
 
 ## Algorithms
 
- Md5
- Sha1
- Sha256
- Sha512
- Pbkdf2
- BCrypt
- Scrypt
- Argon2
 
 ## MD5 (Message Digest Algorithm 5)
 MD5 is a widely known hashing algorithm but is considered to be weak for password storage. It produces a 128-bit hash value and is susceptible to various vulnerabilities, such as collision attacks and preimage attacks. It is no longer recommended for secure password storage.

## SHA-1 (Secure Hash Algorithm 1)

Like MD5, SHA-1 is also considered weak for password hashing due to its vulnerability to collision attacks. It produces a 160-bit hash value and has been deprecated for most security-sensitive applications.

## BCrypt

BCrypt is a widely used password hashing algorithm that incorporates a cost factor to control the computational complexity of the hashing process. It uses the Blowfish encryption algorithm and is designed to be slow and computationally expensive, making it more resistant to brute-force attacks.

### Arguments

- Cost Factor: In bcrypt, the cost factor refers to the work factor used to control the computational complexity of the hashing process. It determines how expensive the hashing algorithm is in terms of time and resources required to compute a hash. The higher the cost factor, the more secure but slower the bcrypt hashing becomes.
The cost factor in bcrypt is specified as a numerical value called the "logarithmic cost factor" or simply the "cost." It is represented as a power of 2. For example, a cost factor of 10 would mean 2^10 (1024) iterations.

## PBKDF2 (Password-Based Key Derivation Function 2)

PBKDF2 is a key derivation function rather than a dedicated password hashing algorithm. It applies a pseudorandom function (such as HMAC) repeatedly to stretch the password and generate a secure hash. PBKDF2 allows the specification of an iteration count and a salt value, making it more resilient against brute-force attacks.

### Arguments

- Iterations: Iterations determine the number of times the underlying pseudorandom function (PRF) is iteratively applied. The higher the number of iterations, the more secure but slower the PBKDF2 process becomes. It is recommended to use a sufficient number of iterations to provide an acceptable level of security based on the hardware and computational resources available.
- HashSize: HashSize specifies the desired output hash size in bytes. PBKDF2 can generate a hash of arbitrary length, but it is commonly used to derive keys for cryptographic algorithms with specific key sizes. For example, if you want to generate a 256-bit (32-byte) key, you would set the HashSize to 32.

## Scrypt

Scrypt is another key derivation function that utilizes the concept of "memory-hard" functions, making it more resistant to GPU and ASIC-based attacks. It was specifically designed to mitigate the vulnerabilities associated with specialized hardware attacks and requires a significant amount of memory to compute the hash.

### Arguments

- Cost/Iterations: The cost parameter represents the CPU/memory cost parameter (N) in scrypt. It is an integer that determines the computational and memory resources required to perform the scrypt operation. A higher cost value makes the scrypt function more resource-intensive and increases the time required to derive the key.
- BlockSize: The block size parameter (r) determines the size of the memory blocks used in the scrypt algorithm. It is an integer that affects the memory requirements of the algorithm. The blockSize value should be a power of 2.
- Parallel: The parallelization parameter (p) determines the degree of parallelism in the scrypt algorithm. It is an integer that defines the number of parallel operations that can be executed simultaneously. A higher parallel value can speed up the computation on systems with multiple processors or cores.

## Argon2

Argon2 is the winner of the Password Hashing Competition held by the Password Hashing Competition (PHC) forum in 2015. It is a memory-hard, time-hard, and data-independent hashing algorithm. Argon2 is considered to be a strong and secure choice for password hashing, with options for different modes (Argon2d, Argon2i, Argon2id) depending on the specific requirements of the application.

### Arguments

- Parallelism: Parallelism determines the degree of parallelization in the algorithm. It defines the number of independent threads that can be used to compute the hash in parallel. A higher parallelism value can speed up the computation but may also consume more resources. It is typically recommended to set the parallelism parameter to the number of available CPU threads or cores on the system.
- Iterations: Iterations represent the number of iterations performed in the memory-hard function. Increasing the number of iterations makes the algorithm slower, thus increasing the time required to compute the hash. This helps protect against brute-force attacks. The optimal number of iterations depends on the available computational resources and the desired level of security. It is generally recommended to use a sufficiently high value that balances security with acceptable performance.
- Memory Size: Memory size refers to the amount of memory (in kilobytes) used by the algorithm. It determines the memory-hardness of the function and is a crucial factor in making the algorithm resistant to GPU and ASIC attacks. The memory size should be set as high as possible within the constraints of the available resources. A typical recommendation is to use at least a few megabytes (e.g., 8MB) of memory. However, the appropriate value depends on the specific hardware and the desired trade-off between security and performance.

## Example 

```C#
string password = "j&3hc#k$syurh34";

// Hash passwords for test
string hash = Md5.HashPassword(password);
 
// Print hashes
Console.WriteLine($"MD5: {hash}");

// Verify if its working
Console.WriteLine($"MD5: {Md5.VerifyPassword(password, hash)}");
```

## Performance and tests results

Benchmark sampled each in two seconds. 

Check the code to see parameters used for each method because result may change drastically

See output:

```
Testing algorithms

MD5: ixY45I9nEPDc1i5XRmLsUA==
SHA1: JJuvWtb7vnMsLZpr/T5iRv7+SmY=
SHA256: 8DcHnEseyAPhMgHGELM/EnodarYXDy+VOKZ73fLfSOs=
SHA512: Fk9323H3sRMeOVML+2vGgt8hrm4+5I47YvaGeiGKciO0IN3p5KphWAF20loKevp3+ZcCSvnE7spjXj5DthDl8w==
PBKDF2: nLxipoVrQtTaZtcKeqyTIn0pAoM4Ud7nwUFyEi76oz+fTPTzqnMyOYrkYHIOlgej
BCRYPT: $2a$12$8x10XqHEDD35MpWqWdhoxuCMvdp9Yqgng6Bs6PMC1xKRDL0/VWZXC
SCRYPT: $s2$16384$8$4$pUlMeU/uKKMgE/S2HUcftqTqeSL1eN/f3pAaK6KnJlI=$zoWiLsN585N6+5O9emqstLvZb5BdCqIsM/5+0a4Uemg=
ARGON2: Hy6pyB7cq80DMEX1VuSCZ/mtzUCKQyvzuKc/ZgPez98/DPnR1Qx4B95sRs3Vmbya

Verifiy if its working

MD5: True
SHA1: True
SHA256: True
SHA512: True
PBKDF2: True
BCRYPT: True
SCRYPT: True
ARGON2: True

Benchmarking algorithms
Md5: 2157286 hashes/seconds
Sha1: 2170096 hashes/seconds
Sha256: 2438797,5 hashes/seconds
Sha512: 1516621,5 hashes/seconds
Pbkdf2: 203,5 hashes/seconds
BCrypt: 4 hashes/seconds
Scrypt: 9,5 hashes/seconds
Argon2: 1 hashes/seconds
```

