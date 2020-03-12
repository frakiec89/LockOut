using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LockOut
{
    public  abstract class BaseSerializable 
    {
        public T Load<T>( string  filePath) where T : class //   получаем список  юзеров из файла 
        {
            BinaryFormatter formatter = new BinaryFormatter(); // формтарор

            using (var fille = new FileStream(filePath, FileMode.OpenOrCreate)) // поток данных  из  файла   
            {

                try
                {
                    var us = formatter.Deserialize(fille); // забираем объект  из  файла
                    if (us == null) // если файл  пустой
                    {
                        return default(T); // создаем пустой  лист
                    }
                    else
                    {
                       
                        return us as T; // преобразуем объект  в  список листов 
                    }
                }
                catch
                {
                    return default(T); // создаем пустой  лист
                }
            }

        }


        public void Save<T>(string filePath  ,  T t  )  where T: class  // сохраняем список  юзеров  в  файл
        {
            BinaryFormatter formatter = new BinaryFormatter(); // формтарор
            using (var fille = new FileStream(filePath, FileMode.OpenOrCreate)) // поток данных  в  файл  
            {
                formatter.Serialize(fille, t); // сириализация 
            }

        }

    }
}
