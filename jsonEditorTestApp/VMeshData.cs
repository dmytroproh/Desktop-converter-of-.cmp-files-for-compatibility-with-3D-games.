using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace jsonEditorTestApp
{

    class VMeshData
    {
        public const uint D3DFVF_DIFFUSE = 0x40;
        public const uint D3DFVF_NORMAL = 0x10;
        public const uint D3DFVF_RESERVED0 = 1;
        public const uint D3DFVF_RESERVED1 = 0x20;
        public const uint D3DFVF_SPECULAR = 0x80;
        public const uint D3DFVF_TEX0 = 0;
        public const uint D3DFVF_TEX1 = 0x100;
        public const uint D3DFVF_TEX2 = 0x200;
        public const uint D3DFVF_TEX3 = 0x300;
        public const uint D3DFVF_TEX4 = 0x400;
        public const uint D3DFVF_TEX5 = 0x500;
        public const uint D3DFVF_TEX6 = 0x600;
        public const uint D3DFVF_TEX7 = 0x700;
        public const uint D3DFVF_TEX8 = 0x800;
        public const uint D3DFVF_TEXCOUNT_MASK = 0xf00;
        public const uint D3DFVF_XYZ = 2;
        public const uint D3DFVF_XYZB1 = 6;
        public const uint D3DFVF_XYZB2 = 8;
        public const uint D3DFVF_XYZB3 = 10;
        public const uint D3DFVF_XYZB4 = 12;
        public const uint D3DFVF_XYZB5 = 14;
        public const uint D3DFVF_XYZRHW = 4;
        public ushort FlexibleVertexFormat;
        public List<TMeshHeader> Meshes = new List<TMeshHeader>();
        public uint MeshType;
        public ushort NumMeshes;
        public ushort NumRefVertices;
        public ushort NumVertices;
        public uint SurfaceType;
        public List<TTriangle> Triangles = new List<TTriangle>();
        public List<TVertex> Vertices = new List<TVertex>();

        public VMeshData(byte[] data)
        {
            int pos = 0;

            this.MeshType = Utilities.GetDWord(data, ref pos);
            this.SurfaceType = Utilities.GetDWord(data, ref pos);
            this.NumMeshes = Utilities.GetWord(data, ref pos);
            this.NumRefVertices = Utilities.GetWord(data, ref pos);
            this.FlexibleVertexFormat = Utilities.GetWord(data, ref pos);
            this.NumVertices = Utilities.GetWord(data, ref pos);
            switch (this.FlexibleVertexFormat)
            {
                case 0x102:
                case 0x112:
                case 2:
                case 0x12:
                case 0x142:
                case 0x152:
                case 530:
                case 0x252:
                    {
                        int num2 = 0;
                        for (int i = 0; i < this.NumMeshes; i++)
                        {
                            TMeshHeader item = new TMeshHeader
                            {
                                MaterialId = Utilities.GetDWord(data, ref pos),
                                StartVertex = Utilities.GetWord(data, ref pos),
                                EndVertex = Utilities.GetWord(data, ref pos),
                                NumRefVertices = Utilities.GetWord(data, ref pos),
                                Padding = Utilities.GetWord(data, ref pos),
                                TriangleStart = num2
                            };
                            num2 += item.NumRefVertices;
                            this.Meshes.Add(item);
                        }
                        int num4 = this.NumRefVertices / 3;
                        int StasrtAdress = pos;
                       
                       
                        for (int j = 0; j < num4; j++)
                        {
                            TTriangle triangle = new TTriangle
                            {
                                Vertex1 = Utilities.GetWord(data, ref pos),
                                Vertex2 = Utilities.GetWord(data, ref pos),
                                Vertex3 = Utilities.GetWord(data, ref pos)
                            };
                            this.Triangles.Add(triangle);
                            
                        }
                        try
                        {
                            int SuperBuferPos = pos;
                            for (int i = 0; i < pos; i++)
                            {
                                Result.SuperBuffer[i] = data[i];
                            }
                            for (int k = 0; k < this.NumVertices; k++)
                            {
                                for (int i = 0; i < 12; i++)
                                {
                                    Result.SuperBuffer[SuperBuferPos + i] = data[pos + i];
                                }
                                SuperBuferPos += 12;
                                TVertex vertex = new TVertex
                                {
                                    FVF = this.FlexibleVertexFormat,
                                    X = Utilities.GetFloat(data, ref pos),
                                    Y = Utilities.GetFloat(data, ref pos),
                                    Z = Utilities.GetFloat(data, ref pos)

                                };
                                if ((this.FlexibleVertexFormat & 0x10) == 0x10)
                                {
                                    vertex.NormalX = Utilities.GetFloat(data, ref pos);
                                    vertex.NormalY = Utilities.GetFloat(data, ref pos);
                                    vertex.NormalZ = Utilities.GetFloat(data, ref pos);
                                }
                                if ((this.FlexibleVertexFormat & 0x40) == 0x40)
                                {
                                    vertex.Diffuse = Utilities.GetDWord(data, ref pos);
                                }

                                if (DiffuseManger.diffuseDictionary.ContainsKey(k))
                                {
                                    byte[] temp = DiffuseManger.diffuseDictionary[k];
                                    for (int i = 0; i < 4; i++)
                                    {
                                        Result.SuperBuffer[SuperBuferPos + i] = temp[i];
                                    }
                                }
                                SuperBuferPos += 4;
                                if ((this.FlexibleVertexFormat & 0x100) == 0x100)
                                {
                                    for(int i = 0; i < 8; i++)
                                    {
                                       Result.SuperBuffer[SuperBuferPos + i] = data[pos + i];
                                    }
                                    SuperBuferPos += 8;
                                    vertex.S = Utilities.GetFloat(data, ref pos);
                                    vertex.T = Utilities.GetFloat(data, ref pos);

                                }
                                if ((this.FlexibleVertexFormat & 0x200) == 0x200)
                                {
                                    vertex.S = Utilities.GetFloat(data, ref pos);
                                    vertex.T = Utilities.GetFloat(data, ref pos);
                                    vertex.U = Utilities.GetFloat(data, ref pos);
                                    vertex.V = Utilities.GetFloat(data, ref pos);
                                }
 
                                this.Vertices.Add(vertex);
                                DiffuseManger.Capacity = SuperBuferPos;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Header has more vertices than data", "Error");
                        }
                        return;
                    }
            }
            throw new Exception($"FVF 0x{this.FlexibleVertexFormat:X} not supported.");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TMeshHeader
        {
            public uint MaterialId;
            public int StartVertex;
            public int EndVertex;
            public int NumRefVertices;
            public int Padding;
            public int TriangleStart;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TTriangle
        {
            public int Vertex1;
            public int Vertex2;
            public int Vertex3;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TVertex
        {
            public uint FVF;
            public float X;
            public float Y;
            public float Z;
            public float NormalX;
            public float NormalY;
            public float NormalZ;
            public uint Diffuse;
            public float S;
            public float T;
            public float U;
            public float V;
        }
    }
}
