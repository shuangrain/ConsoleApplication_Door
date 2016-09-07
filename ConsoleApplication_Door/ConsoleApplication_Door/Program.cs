using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication_Door
{
    class Program
    {
        static void Main(string[] args)
        {
            DoorController dc = new DoorController();
            dc.AddDoor(new HorizontalDoor());
            dc.AddDoor(new VerticalDoor());
            dc.AddDoor(new AlarmDoor());
            dc.AddDoor(new AutoAlarmDoor());

            dc.OpenDoor();

            Console.ReadLine();
        }
    }

    abstract class Door
    {
        public virtual void Open()
        {
            Console.WriteLine("Open Door");
        }
        public virtual void Close()
        {
            Console.WriteLine("Close Door");
        }
    }

    class HorizontalDoor : Door { }

    class VerticalDoor : Door
    {
        public override void Open()
        {
            Console.WriteLine("Open vertically");
        }
        public override void Close()
        {
            Console.WriteLine("Close vertically");
        }
    }

    interface IAlarm
    {
        void Alert();
    }

    class Alarm : IAlarm
    {
        public void Alert()
        {
            Console.WriteLine("Ring ~~");
        }
    }

    class AlarmDoor : Door
    {
        private IAlarm _alarm;

        public AlarmDoor()
        {
            _alarm = new Alarm();
        }

        public void Alert()
        {
            _alarm.Alert();
        }
    }

    class AutoAlarmDoor : AlarmDoor
    {
        public override void Open()
        {
            base.Open();
            Alert();
        }
    }

    class DoorController
    {
        protected List<Door> _dootList = new List<Door>();

        public void AddDoor(Door Door)
        {
            _dootList.Add(Door);
        }

        public void OpenDoor()
        {
            foreach (var item in _dootList)
            {
                item.Open();
            }
        }
    }
}
