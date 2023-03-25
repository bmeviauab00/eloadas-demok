namespace ThreadDemos;

#region Demo1: Szál indítása
class Program
{
    static void Main(string[] args)
    {
        Thread t1 = new Thread(new ThreadStart(WriteY));
        Thread t2 = new Thread(new ParameterizedThreadStart(WriteAny));
        //Thread t = new Thread(WriteAny);
        t1.Start();
        t2.Start("Z");                          // Run WriteY on the new thread
        while (true) Console.Write("x");   // Write 'x' forever
    }
    static void WriteY()
    {
        while (true) Console.Write("y");   // Write 'y' forever
    }

    static void WriteAny(object param)
    {
        while (true) Console.Write(param);   // Write 'y' forever
    }
}
#endregion

#region Demo1': Adat átadása szálnak objektum metódusreferenciával)
//class ThreadClass
//{
//    string text;

//    public ThreadClass(string text)
//    {
//        this.text = text;
//    }

//    public void WriteAny()
//    {
//        while (true) Console.Write(text);
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        ThreadClass ts = new ThreadClass("Z");
//        Thread t = new Thread(ts.WriteAny);
//        t.Start();
//        while (true) Console.Write("X");
//    }
//}
#endregion

#region Demo2: Előtér és háttérszálak
//class Program
//{
//    static void Main(string[] args)
//    {
//        Thread t = new Thread(ThreadFunc);
//        t.Start();
//        t.IsBackground = true;
//        Console.WriteLine("Én vagyok a főszál és végeztem...\n");
//    }

//    static void ThreadFunc()
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("Én vagyok a háttérszál: " + i.ToString());
//        }
//    }
//}
#endregion

#region Demo3: Aktuális szál elérése, Thread.Name, Thread.Sleep
//class Program
//{
//    static void Main()
//    {
//        Thread.CurrentThread.Name = "Main";
//        Thread worker = new Thread(SayHello);
//        worker.Name = "Worker";
//        worker.Start();
//        SayHello();
//    }
//    static void SayHello()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Console.WriteLine("Hello {0} from thread {1}", i, Thread.CurrentThread.Name);
//            Thread.Sleep(1000);
//        }
//    }
//}
#endregion

#region Teszt: Kivételkezelés
//class Program
//{
//    static void Main(string[] args)
//    {
//        Thread t = new Thread(WriteY);
//        t.Start();
//        Console.ReadKey();
//    }
//    static void WriteY()
//    {
//        throw null;
//    }
//}
#endregion

#region Demo4: lock
//class ThreadSafeClass
//{
//    static bool done;
//    static object syncObject = new object();
//    static void Main()
//    {
//        new Thread(Run).Start();
//        new Thread(Run).Start();
//        Console.ReadKey();
//    }
//    static void Run()
//    {
//        lock (syncObject)
//        {
//            if (!done) { Console.WriteLine("Done"); done = true; }
//        }
//    }
//}
#endregion

#region Demo5: Nemstatikus és statikus lock
//class ThreadSafeClass
//{
//    static void Main()
//    {
//        //new Thread(Run).Start();
//        //new Thread(Run).Start();
//    }
//    long var = 0;
//    object syncObject = new object();
//    void Increment()
//    {
//        lock (syncObject) { var++; }
//    }
//    static long staticVar = 0;
//    static object classSyncObject = new object();
//    static void IncrementStatic()
//    {
//        lock (classSyncObject) { staticVar++; }
//    }
//}
#endregion

#region Szál kiléptetése flaggel
//class ThreadClass
//{
//    static bool exit = false;
//    static void Main()
//    {
//        Thread thread = new Thread(Run);
//        thread.Start();
//        Thread.Sleep(2000);
//        Console.WriteLine("Signaling to worker thread.");
//        exit = true;
//        Console.WriteLine("Waiting for worker thread to exit.");
//        thread.Join();
//        Console.WriteLine("Worker thread definitely has exited.");
//        Console.ReadKey();
//    }
//    static void Run()
//    {
//        int counter = 0;
//        while (!exit)
//        {
//            Thread.Sleep(300);
//            Console.WriteLine(counter++.ToString());
//        }
//        Console.WriteLine("Exiting from worker thread.");
//    }
//}
#endregion

#region AutoResetEvent
//class SimpleEventDemo
//{
//    static EventWaitHandle wh = new AutoResetEvent(false);
//    static void Main()
//    {
//        new Thread(Run).Start();
//        Thread.Sleep(1000); // Várjunk egy kicsit
//        wh.Set(); // Ébresztő
//    }
//    static void Run()
//    {
//        Console.WriteLine("Várunk értesítésre ...");
//        wh.WaitOne(); // Várakozás
//        Console.WriteLine("Az értesítés megérkezett.");
//    }
//}
#endregion

#region Jóváhagyás példa
//class AcknowledgedWaitHandle
//{
//    static EventWaitHandle ready = new AutoResetEvent(false);
//    static EventWaitHandle go = new AutoResetEvent(false);
//    static volatile string task;
//    static void Main()
//    {
//        new Thread(Work).Start();
//        // Ötször jelzünk a munkaszálnak: ennyi "feladatot" fogunk kiosztani
//        for (int i = 1; i <= 5; i++)
//        {
//            ready.WaitOne(); // Először várunk, amíg a szál "előkészül"
//            task = "a".PadRight(i, 'h'); // Feladat szálhoz rendelése
//            go.Set(); // Jelzünk a szálnak, hogy elindulhat a feladat feldolgozásával!
//        }
//        // Jelezzük a szálnak, hogy lépjen ki.
//        ready.WaitOne(); task = null; go.Set();
//        Console.ReadLine();
//    }
//    static void Work()
//    {
//        while (true)
//        {
//            ready.Set(); // Jelezzük, hogy kész vagyunk
//            go.WaitOne(); // Várunk a feladatra
//            if (task == null) return; // Szépen kilépünk
//            Console.WriteLine(task);
//        }
//    }
//}
#endregion

#region Termelő/fogyasztó sor példa
//class ProducerConsumerQueue : IDisposable
//{
//    AutoResetEvent taskWaitHandle = new AutoResetEvent(false);
//    Thread worker;
//    object syncObject = new object();
//    Queue<string> tasks = new Queue<string>();
//    public ProducerConsumerQueue()
//    {
//        worker = new Thread(Work);
//        worker.Start();
//    }
//    public void EnqueueTask(string task)
//    {
//        // A Queue<string> tasks nem szálbiztos!, nekünk kell zárolni
//        lock (syncObject) tasks.Enqueue(task);
//        taskWaitHandle.Set();
//    }
//    public void Dispose()
//    {
//        EnqueueTask(null); // Így jelzünk a fogyasztónak, hogy lépjen ki.
//        worker.Join(); // Megvárjuk, amíg a fogyasztó szál befejezi futását
//        taskWaitHandle.Close(); // OS erőforrások felszabadítása (ez Dispose-t hív)
//    }
//    void Work()
//    {
//        while (true)
//        {
//            string task = null;
//            lock (syncObject)
//            {
//                if (tasks.Count > 0)
//                {
//                    task = tasks.Dequeue();
//                    if (task == null) return;
//                }
//            }
//            // Ez a nem működő megoldás (kommentezzük ki)
//            // Ezt tudatosan nem a lock blokkban dolgozzuk fel: maximális párhuzamosításra törekszünk
//            Console.WriteLine("Performing task: " + task);
//            Thread.Sleep(1000); // A munka szimulálása
//            taskWaitHandle.WaitOne(); // Momentán nincs több feladat a sorban, jelzésre várunk.

//            // Ez a működő megoldás (szedjük ki a kommentet)
//            //if (task != null) // A task pont akkor null, ha nem volt több feladat a sorban
//            //{
//            //    // Ezt tudatosan nem a lock blokkban dolgozzuk fel: maximális párhuzamosításra törekszünk
//            //    Console.WriteLine("Performing task: " + task);
//            //    Thread.Sleep(1000); // A munka szimulálása
//            //}
//            //else
//            //    taskWaitHandle.WaitOne(); // Momentán nincs több feladat a sorban, jelzésre várunk.
//        }
//    }
//}

//class Test
//{
//    // Itt kezdjük a megértést.
//    static void Main()
//    {
//        using (ProducerConsumerQueue q = new ProducerConsumerQueue())
//        {
//            q.EnqueueTask("Start");
//            for (int i = 0; i < 5; i++) q.EnqueueTask("Task " + i);
//            q.EnqueueTask("Stop");
//        }
//        // A using blokkból kilépés során meghívódik a sorra a Dispose, ami egy null
//        // feladatot helyez el a sorban, majd megvárja, amíg a fogyasztó végez.
//    }
//}
#endregion

#region Termelő/fogyasztó sor példa gyors kiléptetéssel
//// A kiléptetést nem egy speciális taskkal, hanem egy AutoResetEventtel jelezzük
//class ProducerConsumerQueue : IDisposable
//{
//    EventWaitHandle taskWaitHandle = new AutoResetEvent(false);
//    EventWaitHandle exitWaitHandle = new AutoResetEvent(false);
//    WaitHandle[] waitHandles;
//    Thread worker;
//    object syncObject = new object();
//    Queue<string> tasks = new Queue<string>();
//    volatile bool exit = false; // Flag a kiléptetés jelzésére
//    public ProducerConsumerQueue()
//    {
//        waitHandles = new WaitHandle[] { exitWaitHandle, taskWaitHandle };
//        worker = new Thread(Work);
//        worker.Start();
//    }
//    public void EnqueueTask(string task)
//    {
//        // A Queue<string> tasks nem szálbiztos!, nekünk kell zárolni
//        lock (syncObject) tasks.Enqueue(task);
//        taskWaitHandle.Set();
//    }
//    public void Dispose()
//    {
//        Console.WriteLine("Dispose called, signaling thread to exit.");
//        exit = true; // Ezzel jelezzük, hogy lépjen ki
//        exitWaitHandle.Set(); // Ha blokkolva van a fogyasztó, fel kell ébreszteni
//        worker.Join(); // Megvárjuk, amíg a fogyasztó szál befejezi futását
//        taskWaitHandle.Close(); // OS erőforrások felszabadítása (ez Dispose-t hív)
//        exitWaitHandle.Close(); // OS erőforrások felszabadítása (ez Dispose-t hív)
//    }
//    void Work()
//    {
//        while (true)
//        {
//            string task = null;
//            lock (syncObject)
//            {
//                if (exit)      // Minden feldolgozás előtt vizsgáljuk meg.
//                {
//                    Console.WriteLine("Worker thread exits.");
//                    return;
//                }

//                if (tasks.Count > 0)
//                    task = tasks.Dequeue();
//            }

//            // Ha volt feladat a sorban
//            if (task != null)
//            {
//                Console.WriteLine("Performing task: " + task);
//                Thread.Sleep(1000); // A munka szimulálása
//            }
//            else
//            {
//                // Momentán nincs több feladat a sorban, jelzésre várunk.
//                int index = WaitHandle.WaitAny(waitHandles, 60000, false);
//                if (index == 0) // A 0. indexen az exitWaitHandle, kiléptetéskor igaz
//                    return;
//                else if (index == WaitHandle.WaitTimeout)
//                {
//                    Console.WriteLine("Timeout!");
//                    // További kezelés ide ...
//                }
//                // Feladat a sorban
//            }
//        }
//    }
//}

//class Test
//{
//    static void Main()
//    {
//        using (ProducerConsumerQueue q = new ProducerConsumerQueue())
//        {
//            q.EnqueueTask("Start");
//            for (int i = 0; i < 10; i++) q.EnqueueTask("Task " + i);
//            q.EnqueueTask("Stop");
//            Thread.Sleep(3000); // Betettünk 10 feladatot, várunk 3 másodpercet
//        }
//        // A usingból kilépés során meghívódik a sorra a Dispose,
//        // ami
//    }
//}
#endregion

#region Termelő/fogyasztó sor példa gyors kiléptetéssel és EGY AutoResetEventel
// A kiléptetést nem egy speciális taskkal, hanem egy AutoResetEventtel jelezzük
//class ProducerConsumerQueue : IDisposable
//{
//    EventWaitHandle anyEventWaitHandle = new AutoResetEvent(false);
//    Thread worker;
//    object syncObject = new object();
//    Queue<string> tasks = new Queue<string>();
//    volatile bool exit = false; // Flag a kiléptetés jelzésére
//    public ProducerConsumerQueue()
//    {
//        worker = new Thread(Work);
//        worker.Start();
//    }
//    public void EnqueueTask(string task)
//    {
//        // A Queue<string> tasks nem szálbiztos!, nekünk kell zárolni
//        lock (syncObject) tasks.Enqueue(task);
//        anyEventWaitHandle.Set();
//    }
//    public void Dispose()
//    {
//        Console.WriteLine("Dispose called, signaling thread to exit.");
//        exit = true; // Ezzel jelezzük, hogy lépjen ki
//        anyEventWaitHandle.Set(); // Ha blokkolva van a fogyasztó, fel kell ébreszteni
//        worker.Join(); // Megvárjuk, amíg a fogyasztó szál befejezi futását
//        anyEventWaitHandle.Close(); // OS erőforrások felszabadítása (ez Dispose-t hív)
//    }
//    void Work()
//    {
//        while (true)
//        {
//            string task = null;
//            lock (syncObject)
//            {
//                if (exit)      // Minden feldolgozás előtt vizsgáljuk meg.
//                {
//                    Console.WriteLine("Worker thread exits.");
//                    return;
//                }

//                if (tasks.Count > 0)
//                    task = tasks.Dequeue();
//            }

//            // Ha volt feladat a sorban
//            if (task != null)
//            {
//                Console.WriteLine("Performing task: " + task);
//                Thread.Sleep(1000); // A munka szimulálása
//            }
//            else
//                // Momentán nincs több feladat a sorban, jelzésre várunk (kilépés vagy feladat)
//                anyEventWaitHandle.WaitOne();
//        }
//    }
//}

//class Test
//{
//    static void Main()
//    {
//        using (ProducerConsumerQueue q = new ProducerConsumerQueue())
//        {
//            q.EnqueueTask("Start");
//            for (int i = 0; i < 10; i++) q.EnqueueTask("Task " + i);
//            q.EnqueueTask("Stop");
//            Thread.Sleep(3000); // Betettünk 10 feladatot, várunk 3 másodpercet
//        }
//        // A usingból kilépés során meghívódik a sorra a Dispose,
//    }
//}
#endregion

#region Szál kiléptetése bool flaggel - nehezen megoldható, így nem is működik
//class ThreadClass
//{
//    static OneItemQueue queue = new OneItemQueue();
//    static bool exit = false;
//    static void Main()
//    {
//        Thread thread = new Thread(Run);
//        thread.Start();
//        Thread.Sleep(2000);
//        Console.WriteLine("Signaling to worker thread.");
//        exit = true;
//        Console.WriteLine("Waiting for worker thread to exit.");
//        thread.Join();
//        Console.WriteLine("Worker thread definitely has exited.");
//    }
//    static void Run()
//    {
//        string task;
//        while (!exit)
//        {
//            task = queue.GetTask();
//        }
//        Console.WriteLine("Exiting from worker thread.");
//    }
//}

//class OneItemQueue
//{
//    AutoResetEvent autoResetEvent = new AutoResetEvent(false);
//    string task;

//    public void PutTask(string task)
//    {
//        this.task = task;
//    }

//    public string GetTask()
//    {
//        autoResetEvent.WaitOne();
//        return task;
//    }
//}
#endregion

#region Szál kiléptetése Thread.Interrupt hívással
//class ThreadClass
//{
//    static OneItemQueue queue = new OneItemQueue();
//    static void Main()
//    {
//        Thread thread = new Thread(Run);
//        thread.Start();
//        Thread.Sleep(2000);
//        Console.WriteLine("Signaling to worker thread.");
//        thread.Interrupt();
//        Console.WriteLine("Waiting for worker thread to exit.");
//        thread.Join();
//        Console.WriteLine("Worker thread definitely has exited.");
//    }
//    static void Run()
//    {
//        try
//        {
//            string task;
//            while (true)
//            {
//                task = queue.GetTask();
//            }
//        }
//        catch (ThreadInterruptedException)
//        { }
//        Console.WriteLine("Exiting from worker thread.");
//    }
//}

//class OneItemQueue
//{
//    AutoResetEvent autoResetEvent = new AutoResetEvent(false);
//    string task;

//    public void PutTask(string task)
//    {
//        this.task = task;
//    }

//    public string GetTask()
//    {
//        autoResetEvent.WaitOne();
//        return task;
//    }
//}

#endregion

#region ThreadPool
//class Test
//{
//    static ManualResetEvent doneEvent = new ManualResetEvent(false);

//    public static void Main()
//    {
//        ThreadPool.QueueUserWorkItem(Run);
//        Console.WriteLine("Waiting for threads to complete...");
//        doneEvent.WaitOne();
//        Console.WriteLine("Worker has ended!");
//        Console.ReadLine();
//    }
//    public static void Run(object instance)
//    {
//        Console.WriteLine("Started...");
//        Thread.Sleep(1000);
//        Console.WriteLine("Ended");
//        doneEvent.Set();
//    }
//}
#endregion

#region Deadlock
//class DeadlockClass
//{
//    static object syncObjectA = new object();
//    static object syncObjectB = new object();

//    static void Main()
//    {
//        new Thread(RunA).Start();
//        new Thread(RunB).Start();
//    }

//    static void RunA()
//    {
//        Console.WriteLine("RunA: indulok...");
//        lock (syncObjectA)
//        {
//            Thread.Sleep(1000);
//            lock (syncObjectB)
//            {
//                Console.WriteLine("RunA: hahó!");
//            }
//        }
//    }

//    static void RunB()
//    {
//        Console.WriteLine("RunB: indulok...");
//        lock (syncObjectB)
//        {
//            Thread.Sleep(1000);
//            lock (syncObjectA)
//            {
//                Console.WriteLine("RunB: hahó!");
//            }
//        }
//    }
// }
#endregion
