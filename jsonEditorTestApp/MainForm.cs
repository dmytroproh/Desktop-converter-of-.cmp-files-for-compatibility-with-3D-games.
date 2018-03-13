using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsonEditorTestApp
{
  
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

      

        private void SelectLVButton_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show(this, "Cannot export data from non-leaf nodes or multiple nodes", "Error");
            }
            else
            {
                //this.LVFileDialog.Filter = "All Types (*.*)|*.*";
                if (this.LVFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        byte[] tag = new byte[DiffuseManger.Capacity];
                        for (int i = 0; i < DiffuseManger.Capacity; i++)
                        {
                            tag[i] = Result.SuperBuffer[i];
                        }
                        

                        tag[12] = 66;
                        tag[13] = 1;

                        File.WriteAllBytes(this.LVFileDialog.FileName, tag);
                        DiffuseManger.diffuseDictionary.Clear();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(this, "Error " + exception.Message, "Error");
                    }
                }
            }
        }

        private void SelectFVbutton_Click(object sender, EventArgs e)
        {
            //FvFileDialog.Filter = "Dynamically Linked Library|*.dll";
            //FvFileDialog.Title = "Select MOMO_FW.dll";
            //DialogResult result = FvFileDialog.ShowDialog(); 
            //if (result == DialogResult.OK) 
            //{

            //}
            this.FvFileDialog.Filter = "All Types (*.*)|*.*";
            if (this.FvFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    byte[] buffer = File.ReadAllBytes(this.FvFileDialog.FileName);      
                    ViewVMeshData(buffer);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "Error " + exception.Message, "Error");
                }
            }

        }
        public void ViewVMeshData(byte[] buffer)
        {
            if (false)
            {
                MessageBox.Show(this, "Cannot export data from non-leaf nodes or multiple nodes", "Error");
            }
            else
            {
                try
                {
                    byte[] tag = buffer;
                    VMeshData data = new VMeshData(tag);
                    StringBuilder builder = new StringBuilder(tag.Length);
                    builder.AppendLine("---- HEADER ----");
                    builder.AppendLine();
                    builder.AppendFormat("Mesh Type                 = {0}\n", data.MeshType);
                    builder.AppendFormat("Surface Type              = {0}\n", data.SurfaceType);
                    builder.AppendFormat("Number of Meshes          = {0}\n", data.NumMeshes);
                    builder.AppendFormat("Total referenced vertices = {0}\n", data.NumRefVertices);
                    builder.AppendFormat("Flexible Vertex Format    = 0x{0:X}\n", data.FlexibleVertexFormat);
                    builder.AppendFormat("Total number of vertices  = {0}\n", data.NumVertices);
                    builder.AppendLine();
                    builder.AppendLine("---- MESHES ----");
                    builder.AppendLine();
                    builder.AppendLine("Mesh Number  MaterialID  Start Vertex  End Vertex  QtyRefVertex  Padding");
                    for (int i = 0; i < data.Meshes.Count; i++)
                    {
                        builder.AppendFormat("{0,11}  0x{1:X8}  {2,12}  {3,10}  {4,12}  0x{5:X2}\n", new object[] { i, data.Meshes[i].MaterialId, data.Meshes[i].StartVertex, data.Meshes[i].EndVertex, data.Meshes[i].NumRefVertices, data.Meshes[i].Padding });
                    }
                    builder.AppendLine();
                    builder.AppendLine("---- Triangles ----");
                    builder.AppendLine();
                    builder.AppendLine("Triangle  Vertex 1  Vertex 2  Vertex 3");
                    for (int j = 0; j < data.Triangles.Count; j++)
                    {
                        builder.AppendFormat("{0,8}  {1,8}  {2,8}  {3,8}\n", new object[] { j, data.Triangles[j].Vertex1, data.Triangles[j].Vertex2, data.Triangles[j].Vertex3 });
                    }
                    builder.AppendLine();
                    builder.AppendLine("---- Vertices ----");
                    builder.AppendLine();
                    builder.Append("Vertex    ----X----,   ----Y----,   ----Z----");
                    if ((data.FlexibleVertexFormat & 0x10) != 0)
                    {
                        builder.Append(",    Normal X,    Normal Y,    Normal Z");
                    }
                    if ((data.FlexibleVertexFormat & 0x40) != 0)
                    {
                        builder.Append(", -Diffuse-");
                    }
                    if ((data.FlexibleVertexFormat & 0x100) != 0)
                    {
                        builder.Append(",   ----U----,   ----V----");
                    }
                    if ((data.FlexibleVertexFormat & 0x200) != 0)
                    {
                        builder.Append(",  ----U1----,  ----V1----,  ----U2----,  ----V2----");
                    }
                    builder.AppendLine();
                    for (int k = 0; k < data.Vertices.Count; k++)
                    {
                        builder.AppendFormat("{0,6} {1,12:F6},{2,12:F6},{3,12:F6}", new object[] { k, data.Vertices[k].X, data.Vertices[k].Y, data.Vertices[k].Z });
                        if ((data.FlexibleVertexFormat & 0x10) != 0)
                        {
                            builder.AppendFormat(",{0,12:F6},{1,12:F6},{2,12:F6}", data.Vertices[k].NormalX, data.Vertices[k].NormalY, data.Vertices[k].NormalZ);
                        }
                        if ((data.FlexibleVertexFormat & 0x40) != 0)
                        {
                            builder.AppendFormat(", 0x{0:X8}", data.Vertices[k].Diffuse);
                        }
                        if ((data.FlexibleVertexFormat & 0x100) != 0)
                        {
                            builder.AppendFormat(",{0,12:F6},{1,12:F6}", data.Vertices[k].S, data.Vertices[k].T);
                        }
                        if ((data.FlexibleVertexFormat & 0x200) != 0)
                        {
                            builder.AppendFormat(",{0,12:F6},{1,12:F6},{2,12:F6}, {3,12:F6}", new object[] { data.Vertices[k].S, data.Vertices[k].T, data.Vertices[k].U, data.Vertices[k].V });
                        }
                        builder.AppendLine();
                    }
                    string name = "Vmeshdata";
                    int count = name.LastIndexOf('.');
                    if (count != -1)
                    {
                        count = name.LastIndexOf('.', count - 1, count);
                    }
                    if (count != -1)
                    {
                        count = name.LastIndexOf('.', count - 1, count);
                    }
                    MessageBox.Show("Conversion of the file was successful!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "Error " + exception.Message, "Error");
                }
            }
        }

        private void SetDPButton_Click(object sender, EventArgs e)
        {
            try
            {
                int key = 0;
                try
                {
                     key = Convert.ToInt32(this.tbVertexNumber.Text);
                }
                catch (Exception ex)
                {

                }
                uint num = uint.Parse(this.tbParameter.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
             
               

            byte[] value = BitConverter.GetBytes(num);
                
                if (this.checkBox1.Checked)
                {
                    for (int i = 0; i < 999999; i++)
                    {
                        if (DiffuseManger.diffuseDictionary.ContainsKey(i))
                        {
                            DiffuseManger.diffuseDictionary.Remove(i);
                        }
                        DiffuseManger.diffuseDictionary.Add(i, value);
                    }
                }
                else
                {
                    if (DiffuseManger.diffuseDictionary.ContainsKey(key))
                    {
                        DiffuseManger.diffuseDictionary.Remove(key);
                    }
                    DiffuseManger.diffuseDictionary.Add(key, value);
                }
             }
            catch(Exception exception)
            {
                MessageBox.Show(this, "Error " + exception.Message, "Error");
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "All Types (*.*)|*.*";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    StreamReader fs = new StreamReader(this.openFileDialog1.FileName);
                    string s = "";
                    int position = 0;
                    while (s != null)
                    {
                        s = fs.ReadLine();
                        if (s != null)
                        {
                            int key = position;
                            uint num = uint.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);

                            byte[] value = BitConverter.GetBytes(num);

                            DiffuseManger.diffuseDictionary.Add(key, value);
                            position += 1;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "Error " + exception.Message, "Error");
                }
            }
        }
    }

    public static class DiffuseManger {

       public static Dictionary<int, byte[]> diffuseDictionary = new Dictionary<int, byte[]>();

        public static int Capacity = 0; 

    } 

    public static class Result
    {
        public static byte[] SuperBuffer = new byte[1000000];

    }
}

