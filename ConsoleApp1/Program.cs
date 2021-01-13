using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            #region 对象转Json字符串

            var student = new Student
            {
                Name = "赵钰",
                Age = 23,
                Sex = 1,
                Address = new Address
                {
                    City = "武汉市",
                    Road = "江汉路"
                },

            };

            //利用WriteObject方法序列化Json
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Student));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, student);
            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (int)stream.Length);
            var strJson = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(strJson);

            #endregion

            #region Json字符串转对象

            stream = new MemoryStream(Encoding.UTF8.GetBytes(strJson));
            student = (Student)serializer.ReadObject(stream);
            Console.WriteLine($"Name:{student.Name}");
            Console.WriteLine($"Sex:{student.Sex}");
            Console.WriteLine($"Age:{student.Age}");
            Console.WriteLine($"Address:{student.Address.City}{student.Address.Road}");
            Console.WriteLine($"Info:{student.Name } {student.Sex} {student.Age} {student.Address.City}{student.Address.Road}");

            #endregion

            Console.ReadKey();
        }
    }

    [DataContract]
    class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Sex { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public Address Address { get; set; }

        public Info Info { get; set; }
    }

    [DataContract]
    class Address
    {
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Road { get; set; }
    }

    [DataContract]
    class Info
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public int Sex { get; set; }

        [DataMember]
        public Address Address { get; set; }
    }
}
