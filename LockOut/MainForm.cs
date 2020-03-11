using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockOut
{
    public partial class MainForm : Form
    {
        int  lockMin = 1; // блокировка минут

        int countLock = 3; // колл-во  попыток

        /// <summary>
        /// пользователи 
        /// </summary>
        private UserController UserControl;
        /// <summary>
        /// локауты
        /// </summary>
        private LockOutsController LockOutsController;

        public MainForm()
        {
            InitializeComponent();
            lbStatus.Text = ""; // выводим  стус при загрузке
            tbLog.Focus(); // ставим фокус  в   поле ввода лгина 
            btIn.Text = "Вход";
        }

        private void btIn_Click(object sender, EventArgs e) // кнопка вход
        {
            UserControl = new UserController();// вытавикваем пользователей из файла
            LockOutsController = new LockOutsController(); // вытаскиваем  локауты  из файла

            User us = UserControl.Users.SingleOrDefault(u => u.Log == tbLog.Text && u.Pass == tbPass.Text); //  ищем пользователя  с  логином и паролем
           
            DateTime time ; // поле время

            int lockaut = IsLock(countLock, lockMin, tbLog.Text ,out time); // проверяем  колл-во  попыток  и вытаскиваем время последней блокировки

            var timeRez = time.Subtract(DateTime.Now); // получаем разницу между блокировкой и текущим времянем
           

            if  ( lockaut<0) // если  заблокирован
            {
                lbStatus.Text = "блок " + (lockMin-1+ timeRez.Minutes) + " мин. " +(60+ timeRez.Seconds)  + " сек." ; // выводим статус  и врямя до  конца блокировки

                return; // завершаем метод
            }

            if ( us!=null) // если логин , и пароль  верный  то  пользователь найден  
            {
                lbStatus.Text = "Добро пожаловать  " + us.Name; // выводим   приведствие   и  имя пользователя 
                LockOutsController.Add(us); // добавляем   успешный вход  в  локаут
            }
            else // иначе 
            {
                LockOutsController.Add( tbLog.Text , tbPass.Text ); // добавляем неуданый вход  в  локаут  и  не верный логин   и пароль 
              
                lbStatus.Text = "неверный  пароль, осталось  попыток: " +  lockaut  ; // выводим  статус  и колл-во  попыток
            }

        }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="countLock"> кол-во попыток</param>
      /// <param name="lockMin"> блокировка минут </param>
      /// <param name="text"> логин</param>
      /// <param name="time"> время полседнего неудачного  входа</param>
      /// <returns></returns>
        private int  IsLock(int  countLock, int  lockMin, string text , out DateTime time) // возвращает коллво оставшихся попыток   
        {
            // выбираем все  входы для этого  логина в пределах 3 минут
            List<LockOutcs>  dataList = LockOutsController.LockOutcs.Where(t => t.Date >= DateTime.Now.AddMinutes(-lockMin) && t.Login==text).OrderBy(t=>t.Date).ToList(); 

            // новый лист  с   неудачными попытками 
            List<LockOutcs> falseList = new List<LockOutcs>();

            foreach( var list in  dataList)// перебираем все попытки   у пользователя и ищем последние неудачные
            {
                if( list.Status == true) // если статус  попытки  истина   обнуляем список
                {
                    falseList = new List<LockOutcs>();
                }
                else // если попытка неудачная добавляем в лист  
                {
                    falseList.Add(list);
                }
            }

            if (falseList.Count != 0) // смотрим  длинну  листа 
            {
                time = falseList.Where(s => s.Status == false).Last().Date; // есди лист  не пустой  ещем дату послденй  неудачной попытки  и  возвращаем эту дату  
            }
            else
            {
                time =DateTime.Now; // если неудаяных поыпток нет    возращаем текущию  дату 
            }
                return countLock - falseList.Count; // возвращаем  число оставшихся попыток 
            
        }
    }
}
