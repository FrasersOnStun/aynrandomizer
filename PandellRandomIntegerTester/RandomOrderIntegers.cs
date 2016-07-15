using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace AynRandomizer
{
    class RandomOrderList
    {
        /*****************************************************************************************************
         * Ask:
         * Please write a program that generates a list of 10,000 numbers in random order each time it is run. 
         * Each number in the list must be unique and be between 1 and 10,000 (inclusive).
         * 
         * Requirements:
         * Complete: Numbers 1-10000 inclusive each represented
         * Unique: No number appears more than once;
         * 
         * Assumptions:
         * Number is defined as a whole number or integer 
         * Range and list size are arbitrary to loosely define scope - generalization will not be unwelcome
         * 
         * Notes
         * - Knuth Shuffle is Best Practice, 
         * - Random.next(k,max) would be more common and faster implementation but 10 000! >> 2^64
         * - Random.next(k,max) might be equally random if reseeded every 20 iterations 
         * - calls to GetBytes buffered to settle random vs Cryptographic solution
         ****************************************************************************************************/
        public List<int> RandomOrderedInts(int min, int max)
        {
            int Offset = 0;
            List<int> num = new List<int>();
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[1024]; //increasing buffer size to 8192 had no effect on speed
            int j;
            for (int i = min; i <= max; i++) { num.Add(i); };
            int l = 0;
            //Knuth Fisher Yates Shuffle 
            for (int k = 0; k < (max-min); k++)
            {
                if (randomBytes.Length<=Offset){
                    r.GetBytes(randomBytes);
                    Offset = 0;
                }
                j = (int)(BitConverter.ToInt32(randomBytes,Offset)) % max;
                Offset +=4;
                j = (j<0) ? j*-1:j;
                l = num[k];
                num[k] = num[j];
                num[j] = l;
            }
            return num;
        }
    }
}
