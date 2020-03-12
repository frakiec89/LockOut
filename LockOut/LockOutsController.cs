using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LockOut 
{
    /// <summary>
    /// работа со  входами
    /// </summary>
    public class LockOutsController : BaseSerializable
    {
        /// <summary>
        /// список  входов
        /// </summary>
        public  List<LockOutcs> LockOutcs { get; set; }

        /// <summary>
        /// получаем  список  входов
        /// </summary>
        public LockOutsController ()
        {
            LockOutcs = Load();// грузим из файла
        }

        /// <summary>
        /// сохрание  в файл 
        /// </summary>
        public void Save()
        {
            base.Save("Lock.bin", LockOutcs);
          
        }

        /// <summary>
        /// добавление  входа  удачного  если пользователь  найден
        /// </summary>
        /// <param name="user"></param>
        public void Add(User user) // принемает  пользователя
        {
            LockOutcs.Add(new LockOutcs { Date = DateTime.Now, User = user, Status = true , Login=user.Log  }); // добавляет  вход  в  лист
            Save(); // сохраняеи  в  файл
        }

        /// <summary>
        /// добавляем для неудачнонго входа
        /// </summary>
        /// <param name="log"></param>
        /// <param name="pass"></param>
        public void Add( string log , string pass) // вводимый логин  и  пароль 
        {
            LockOutcs.Add(new LockOutcs { Date = DateTime.Now, Status = false , Login = log , Pass = pass , User = null }); 
            Save(); // сохраняеи в  файл
        }

        private List<LockOutcs> Load() // получаем список из  файла 
        {
            if (base.Load<List<LockOutcs>>("Lock.bin")==  null)
                return new List<LockOutcs>();

            return base.Load<List<LockOutcs>>("Lock.bin");

        }
    }
}
