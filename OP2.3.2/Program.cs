using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace OP2._3._2
{
    class Program
    {
        static  void Main(string[] args)
        {
            String pathx, pathy;
            pathx = @"C:\Users\anton\OneDrive\Desktop\New Text Document (9).json";
            pathy = @"C:\Users\anton\OneDrive\Desktop\New Text Document (10).json";
            String savepath = @"C:\Users\anton\OneDrive\Desktop\Dictionary.json";
            Present(pathx, pathy,savepath);
            
            Console.ReadKey();
        }
        static async void Present(String pathx, String pathy, String path)
        {
            List<String> kx = await KeyList(pathx);
            List<Int32> vx = await ValueList(pathx);
            List<String> ky = await KeyList(pathy);
            List<Int32> vy = await ValueList(pathy);
            Dictionary<String, Int32> result = new Dictionary<string, int>();
            foreach (string i in kx)
            {
                if (ky.Contains(i))
                {
                    if (vx[kx.IndexOf(i)] == vy[ky.IndexOf(i)])
                    {
                        result.Add(i, vx[kx.IndexOf(i)]);
                    }
                }
            }
            Save(result, path);

            foreach (KeyValuePair<String, Int32> i in result)
            {
                Console.WriteLine(i.Key + ":" + i.Value + " is present in both x and y");
            }
        }
        static async void Save(Dictionary<String, Int32> d,String path)
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<Dictionary<string, int>>(fs, d);
            }
        }
        static async Task<List<String>> KeyList(String path)
        {
            List<String> keys = new List<string>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Dictionary<String, Int32> x = await JsonSerializer.DeserializeAsync<Dictionary<string, int>>(fs);
                foreach (KeyValuePair<String, Int32> i in x)
                {
                    keys.Add(i.Key);
                }
                return keys;
            }
        }
        static async Task<List<Int32>> ValueList(String path)
        {
            List<Int32> values = new List<Int32>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Dictionary<String, Int32> x = await JsonSerializer.DeserializeAsync<Dictionary<string, int>>(fs);
                foreach (KeyValuePair<String, Int32> i in x)
                {
                    values.Add(i.Value);
                }
                return values;
            }
        }
    }
}
