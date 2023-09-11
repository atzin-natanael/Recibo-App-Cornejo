using FirebirdSql.Data.FirebirdClient;
using iTextSharp.text.pdf;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
//using iTextSharp.text;
using Document = iTextSharp.text.Document;
using System.Diagnostics;
using iTextSharp.text;

namespace ReciboApp
{
    public partial class Form1 : Form
    {
        List<Articulo> Articulos = new();
        FAST_MODE Control;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Data_Datos.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro que deseas agregar otra orden de compra?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            Articulos.Clear();
            string Folio_Mod = Txt_Folio.Text;
            do
            {
                string ceros = "0";
                Folio_Mod = ceros + Folio_Mod;
            } while (Folio_Mod.Length < 9);

            FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                // Crear un nuevo hilo y asignarle un método que se ejecutará en paralelo
                // Iniciar la ejecución del hilo

                con.Open();
                string query0 = "SELECT * FROM DOCTOS_CM WHERE TIPO_DOCTO = 'O' AND ESTATUS = 'P' ORDER BY FECHA DESC";
                FbCommand command = new FbCommand(query0, con);
                bool Find = false;
                // Objeto para leer los datos obtenidos
                FbDataReader reader0 = command.ExecuteReader();
                while (reader0.Read())
                {
                    string Folio = reader0.GetString(4);
                    GlobalSettings.Instance.FolioId = reader0.GetString(0);
                    if (Folio_Mod == Folio)
                    {
                        Find = true;
                        break;
                    }
                }
                reader0.Close();
                if (Find == false)
                {
                    MessageBox.Show("FOLIO NO ENCONTRADO");
                    return;
                }
                string query1 = "SELECT * FROM DOCTOS_CM_DET  WHERE DOCTO_CM_ID =" + GlobalSettings.Instance.FolioId + ";";
                FbCommand command1 = new FbCommand(query1, con);
                FbDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    Articulo variables = new Articulo
                    {
                        Codigo = reader1.GetString(2),
                        Descripcion = "0",
                        Precio = reader1.GetDecimal(9),
                        Medida = reader1.GetString(7),
                        Contenido = reader1.GetInt32(8),
                        Piezas = reader1.GetDecimal(4),
                        Recibidas = reader1.GetDecimal(5),
                        Escaneadas = 0
                    };
                    Articulos.Add(variables);

                }
                reader1.Close();

                string query = "SELECT * FROM CLAVES_ARTICULOS ORDER BY CLAVE_ARTICULO_ID";
                FbCommand commando = new FbCommand(query, con);

                // Objeto para leer los datos obtenidos
                FbDataReader reader = commando.ExecuteReader();
                while (reader.Read())
                {
                    // Acceder a los valores de cada columna por su índice o nombre
                    int temp = reader.GetInt32(2);
                    string col2 = reader.GetString(1);
                    for (int i = 0; i < Articulos.Count; ++i)
                    {
                        if (Articulos[i].Codigo == col2)
                        {
                            GlobalSettings.Instance.OficialCodigo.Add(temp);
                            Articulos[i].Clave = temp.ToString();
                            break;
                        }

                    }
                }
                reader.Close();
                //string query2 = "SELECT * FROM CLAVES_ARTICULOS ORDER BY ROL_CLAVE_ART_ID ASC";
                //FbCommand command2 = new FbCommand(query2, con);
                //FbDataReader reader2 = command2.ExecuteReader();

                //// Iterar sobre los registros y mostrar los valores
                //while (reader2.Read())
                //{
                //    int columnaclave = reader2.GetInt32(2);
                //    int rol = reader2.GetInt32(3);
                //    string codigotemp = reader2.GetString(1);
                //    for (int i = 0; i < Articulos.Count; ++i)
                //    {
                //        if (columnaclave == GlobalSettings.Instance.OficialCodigo[i] && rol == 17)
                //        {
                //            Codigo_nuevo = codigotemp;
                //            Articulos[i].Codigo = Codigo_nuevo;
                //            break;
                //        }

                //    }

                //}

                //reader2.Close();
                string query3 = "SELECT * FROM ARTICULOS ORDER BY ARTICULO_ID";
                FbCommand command3 = new FbCommand(query3, con);
                FbDataReader reader3 = command3.ExecuteReader();

                // Iterar sobre los registros y mostrar los valores
                while (reader3.Read())
                {
                    int columna11 = reader3.GetInt32(0);
                    string descripcion = reader3.GetString(1);
                    for (int i = 0; i < Articulos.Count; ++i)
                    {
                        if (columna11 == GlobalSettings.Instance.OficialCodigo[i])
                        {
                            for (int j = 0; j < Articulos.Count; ++j)
                            {
                                if (GlobalSettings.Instance.OficialCodigo[i].ToString() == Articulos[j].Clave)
                                    Articulos[j].Descripcion = descripcion;
                            }
                            break;
                        }

                    }

                }

                reader3.Close();

                DataGridViewRowCollection rows = Data_Datos.Rows;
                for (int i = 0; i < Articulos.Count; ++i)
                {
                    rows.Add(Articulos[i].Codigo, Articulos[i].Descripcion, Articulos[i].Medida, "$ " + Articulos[i].Precio, Articulos[i].Contenido, Articulos[i].Piezas, Articulos[i].Recibidas, Articulos[i].Contenido * Articulos[i].Piezas, Articulos[i].Escaneadas);

                }
                for (int i = 0; i < Data_Datos.Columns.Count; i++)
                {
                    if (i != 8)
                    {
                        Data_Datos.Columns[i].ReadOnly = true;
                    }
                }
                //Articulos.Clear();
                GlobalSettings.Instance.OficialCodigo.Clear();
                Btn_PDF.Enabled = true;
                Txt_Folio.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void Txt_Folio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Btn_Buscar.Focus();
            }
        }

        private void Data_Datos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GlobalSettings.Instance.CambioColor == true)
            {
                DataGridViewRow row = Data_Datos.Rows[e.RowIndex];
                for (int columnIndex = 0; columnIndex < row.Cells.Count; columnIndex++)
                {
                    DataGridViewCell cell = row.Cells[columnIndex];
                    // Cambiar el color de fondo de la celda
                    cell.Style.BackColor = Color.Yellow;
                    // Cambiar el color del texto de la celda
                    cell.Style.ForeColor = Color.Blue;
                }
                GlobalSettings.Instance.CambioColor = false;
            }
            if (GlobalSettings.Instance.Incompleto == true)
            {
                DataGridViewRow row = Data_Datos.Rows[e.RowIndex];
                for (int columnIndex = 0; columnIndex < row.Cells.Count; columnIndex++)
                {
                    DataGridViewCell cell = row.Cells[columnIndex];
                    // Cambiar el color de fondo de la celda
                    cell.Style.BackColor = Color.LightBlue;
                    // Cambiar el color del texto de la celda
                    cell.Style.ForeColor = Color.Black;
                }
                GlobalSettings.Instance.Incompleto = false;
            }
            if (e.ColumnIndex == 6) // Cambia "tuColumnaIndex" al índice de la columna deseada
            {
                // Cambiar el color del texto según una condición (puede ser cualquier condición que desees)
                if (e.Value.ToString() == "0") // Cambia "ValorEspecifico" al valor que deseas resaltar
                {
                    e.CellStyle.ForeColor = Color.Red; // Cambia el color del texto al deseado
                    e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                    //MessageBox.Show(e.Value.ToString());
                    //MessageBox.Show(Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                else if (e.Value.ToString() != Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString())
                {
                    e.CellStyle.ForeColor = Color.DarkOrange; // Cambia el color del texto al deseado
                    e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                    //DataGridViewRow row = Data_Datos.Rows[e.RowIndex];
                    //DataGridViewCell cell = row.Cells[Proceso_temp];
                    //cell.Style.Font = new Font(cell.Style.Font, FontStyle.Bold);
                }
                else
                {
                    DataGridViewRow row = Data_Datos.Rows[e.RowIndex];
                    for (int columnIndex = 0; columnIndex < row.Cells.Count; columnIndex++)
                    {
                        DataGridViewCell cell = row.Cells[columnIndex];
                        // Cambiar el color de fondo de la celda
                        cell.Style.BackColor = Color.LightGreen;
                        // Cambiar el color del texto de la celda
                        cell.Style.ForeColor = Color.Blue;
                    }
                }

            }
            if (e.ColumnIndex == 5)
            {
                e.CellStyle.ForeColor = Color.SteelBlue; // Cambia el color del texto al deseado
                e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
            }
            if (e.ColumnIndex == 7)
            {
                e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }
        private void Txt_Escanear_KeyDown(object sender, KeyEventArgs e)
        {
            if (Txt_Escanear.Text.Length > 6 && radioButton1.Checked && e.KeyCode == Keys.Enter)
            {
                FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
                try
                {
                    // Crear un nuevo hilo y asignarle un método que se ejecutará en paralelo
                    // Iniciar la ejecución del hilo

                    con.Open();
                    string query = "SELECT * FROM CLAVES_ARTICULOS";
                    FbCommand commando1 = new FbCommand(query, con);
                    bool Find = false;
                    // Objeto para leer los datos obtenidos
                    FbDataReader reader1 = commando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        GlobalSettings.Instance.IdCodigo = reader1.GetString(2);
                        GlobalSettings.Instance.Rol = reader1.GetString(3);
                        GlobalSettings.Instance.Codigo = reader1.GetString(1);
                        if (Txt_Escanear.Text == GlobalSettings.Instance.Codigo)
                        {
                            Find = true;
                            break;
                        }
                    }
                    reader1.Close();
                    if (Find == false)
                    {
                        MessageBox.Show("CÓDIGO NO ENCONTRADO");
                        return;
                    }
                    //MessageBox.Show(GlobalSettings.Instance.FolioId);
                    string query4 = "SELECT * FROM CLAVES_ARTICULOS WHERE ARTICULO_ID =" + GlobalSettings.Instance.IdCodigo + " " + "AND ROL_CLAVE_ART_ID = 17";
                    FbCommand commando4 = new FbCommand(query4, con);
                    FbDataReader reader4 = commando4.ExecuteReader();
                    while (reader4.Read())
                    {
                        GlobalSettings.Instance.Codigo = reader4.GetString(1);
                        //MessageBox.Show(GlobalSettings.Instance.Codigo);
                        Txt_Escanear.Text = GlobalSettings.Instance.Codigo;
                        break;

                    }
                    reader4.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else if (Txt_Escanear.Text.Length > 6 && radioButton2.Checked && e.KeyCode == Keys.Enter)
            {
                FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
                try
                {
                    // Crear un nuevo hilo y asignarle un método que se ejecutará en paralelo
                    // Iniciar la ejecución del hilo

                    con.Open();
                    string query = "SELECT * FROM CLAVES_ARTICULOS";
                    FbCommand commando1 = new FbCommand(query, con);
                    bool Find = false;
                    // Objeto para leer los datos obtenidos
                    FbDataReader reader1 = commando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        GlobalSettings.Instance.IdCodigo = reader1.GetString(2);
                        GlobalSettings.Instance.Rol = reader1.GetString(3);
                        GlobalSettings.Instance.Codigo = reader1.GetString(1);
                        if (Txt_Escanear.Text == GlobalSettings.Instance.Codigo)
                        {
                            Find = true;
                            break;
                        }
                    }
                    reader1.Close();
                    if (Find == false)
                    {
                        MessageBox.Show("CÓDIGO NO ENCONTRADO");
                        return;
                    }
                    //MessageBox.Show(GlobalSettings.Instance.FolioId);
                    string query4 = "SELECT * FROM CLAVES_ARTICULOS WHERE ARTICULO_ID =" + GlobalSettings.Instance.IdCodigo + " " + "AND ROL_CLAVE_ART_ID = 709616";
                    FbCommand commando4 = new FbCommand(query4, con);
                    FbDataReader reader4 = commando4.ExecuteReader();
                    bool caja = false;
                    while (reader4.Read())
                    {
                        caja = true;
                        GlobalSettings.Instance.Codigo = reader4.GetString(1);
                        GlobalSettings.Instance.MasterMulti = true;
                        break;

                    }
                    if (caja == false)
                    {
                        MessageBox.Show("CÓDIGO NO ENCONTRADO :(");
                        return;
                    }
                    reader4.Close();
                    if (GlobalSettings.Instance.MasterMulti == true)
                    {
                        string query5 = "SELECT * FROM CLAVES_ARTICULOS WHERE ARTICULO_ID =" + GlobalSettings.Instance.IdCodigo + " " + "AND ROL_CLAVE_ART_ID = 17";
                        FbCommand commando5 = new FbCommand(query5, con);
                        FbDataReader reader5 = commando5.ExecuteReader();
                        while (reader5.Read())
                        {
                            GlobalSettings.Instance.Codigo = reader5.GetString(1);
                            //MessageBox.Show(GlobalSettings.Instance.Codigo);
                            Txt_Escanear.Text = GlobalSettings.Instance.Codigo;
                            break;

                        }
                        reader5.Close();
                    }
                    else
                    {
                        MessageBox.Show("CODIGO MALO");
                    }

                    Txt_Escanear.Text = string.Empty;
                    Txt_Escanear.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            bool encontrado = false;
            if (e.KeyCode == Keys.Enter && Txt_Escanear.Text != string.Empty)
            {
                for (int i = 0; i < Data_Datos.RowCount; ++i)
                {
                    // Obtener el valor de la columna en la fila actual
                    DataGridViewRow fila = Data_Datos.Rows[i];
                    string valorColumna = fila.Cells["Código"].Value.ToString();
                    string valorDescripcion = fila.Cells["Descripción"].Value.ToString();
                    string valorContenido = fila.Cells["Contenido"].Value.ToString();
                    string valorMedida = fila.Cells["Medida"].Value.ToString();
                    string valorSolicitado = fila.Cells["Unidades"].Value.ToString();
                    string valorRecibido = fila.Cells["Recibidas"].Value.ToString();
                    string valorEscaneado = fila.Cells["Capturado"].Value.ToString();
                    // Comparar el valor con el valor buscado
                    if (valorColumna == Txt_Escanear.Text)
                    {
                        if (radioButton1.Checked)
                        {
                            GlobalSettings.Instance.Proceso_temp = i;
                            FAST_MODE Control = new FAST_MODE();
                            Control.EnviarVariableEvent += new FAST_MODE.EnviarVariableDelegate(ejecutar);
                            Control.UsarDatos(valorColumna, valorDescripcion, valorContenido, valorMedida, valorSolicitado, valorRecibido, valorEscaneado);
                            Control.Show();
                            encontrado = true;
                            break;
                        }
                        object valor = Data_Datos.Rows[i].Cells[8].Value;
                        object valormedida = Data_Datos.Rows[i].Cells[4].Value;
                        decimal valor_trans = (decimal)valor;
                        decimal valor_transmedida = (int)valormedida;
                        decimal suma;
                        if (GlobalSettings.Instance.MasterMulti == true)
                            suma = valor_trans + (1 * valor_transmedida);
                        else
                            suma = valor_trans + 1;
                        //MessageBox.Show(valor_trans.ToString());
                        encontrado = true;
                        if ((decimal)Data_Datos.Rows[i].Cells[5].Value < (decimal)Data_Datos.Rows[i].Cells[6].Value + 1)
                        {
                            DialogResult result = MessageBox.Show("Te estás pasando la cantidad solicitada \n ¿Deseas continuar?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Cancel)
                            {
                                return;
                            }
                            GlobalSettings.Instance.CambioColor = true;
                        }
                        else
                        {
                            GlobalSettings.Instance.Incompleto = true;
                        }
                        Data_Datos.Rows[i].Cells[8].Value = suma;
                        //Data_Datos.Rows[i].Cells[8].Value = (decimal)Data_Datos.Rows[i].Cells[8].Value + suma;
                        Data_Datos.Rows[i].Cells[6].Value = (decimal)Data_Datos.Rows[i].Cells[6].Value + 1;
                        suma = 0;
                        Txt_Escanear.Text = "";
                        break;
                    }

                }
                if (encontrado == false)
                {
                    MessageBox.Show("CÓDIGO NO ENCONTRADO");
                }
                Txt_Escanear.Text = string.Empty;
            }
        }
        public void ejecutar(decimal dato, decimal unidad)
        {
            if ((decimal)Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[5].Value < (decimal)Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[6].Value + unidad)
            {
                DialogResult result = MessageBox.Show("Te estás pasando la cantidad solicitada \n ¿Deseas continuar?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                GlobalSettings.Instance.CambioColor = true;
            }
            else
            {
                GlobalSettings.Instance.Incompleto = true;
            }
            decimal valor = decimal.Parse(Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[8].Value.ToString());
            decimal valor2 = decimal.Parse(Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[6].Value.ToString());
            bool mod = false;
            int datomod = 0;
            int datomod2 = 0;
            string dato_sindecimal = dato.ToString();
            if (dato_sindecimal[dato_sindecimal.Length - 1] == '0' && dato_sindecimal[dato_sindecimal.Length - 2] == '.')
            {
                datomod = (int)Math.Floor(dato);
                datomod2 = (int)Math.Floor(valor2 + unidad);
                mod = true;
            }

            if (mod == true)
            {
                Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[8].Value = valor + datomod;
                Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[6].Value = decimal.Parse(datomod2.ToString());
            }
            else
            {
                Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[8].Value = valor + dato;
                Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[6].Value = valor2 + unidad;
            }
            if ((decimal)Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[5].Value == (decimal)Data_Datos.Rows[GlobalSettings.Instance.Proceso_temp].Cells[6].Value)
            {
                //GlobalSettings.Instance.Incompleto = false;
                //GlobalSettings.Instance.CambioColor = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_PDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document(PageSize.LETTER.Rotate());
            MessageBox.Show("Asignale un Nombre al Archivo PDF");
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "";
            saveFileDialog1.InitialDirectory = desktopFolder;
            saveFileDialog1.Filter = "Archivos de PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
            saveFileDialog1.FileName = "REPORTE ";
            DialogResult result = saveFileDialog1.ShowDialog();
            // Verificar si se ha seleccionado un archivo y se ha hecho clic en el botón "Guardar"
            if (result == DialogResult.OK)
            {
                doc.SetMargins(0, 0, 2, 2);
                string filePath = saveFileDialog1.FileName;
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Crear una tabla para los datos correctos
                PdfPTable table = new PdfPTable(Data_Datos.Columns.Count);
                PdfPCell cell = new PdfPCell(new Phrase("ARTÍCULOS CORRECTOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD)));
                cell.Colspan = 9;
                cell.HorizontalAlignment = 1;
                cell.PaddingBottom = 10f;
                cell.PaddingTop = 10f;
                table.AddCell(cell);
                float[] columnWidths = new float[] { 16f, 60f, 20f, 20f, 21f, 20f, 20f, 18f, 21f }; // Asumiendo que la segunda columna tendrá un ancho personalizado
                table.SetWidths(columnWidths);
                // Crear una tabla para los datos faltantes
                PdfPTable table2 = new PdfPTable(Data_Datos.Columns.Count);
                PdfPCell cell2 = new PdfPCell(new Phrase("ARTÍCULOS INCOMPLETOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD)));
                cell2.Colspan = 9;
                cell2.HorizontalAlignment = 1;
                cell2.PaddingBottom = 10f;
                cell2.PaddingTop = 10f;
                table2.AddCell(cell2);

                table2.SetWidths(columnWidths);
                // Crear una tabla para los datos sobrantes
                PdfPTable table3 = new PdfPTable(Data_Datos.Columns.Count);
                PdfPCell cell3 = new PdfPCell(new Phrase("ARTÍCULOS SOBRANTES", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD)));
                cell3.Colspan = 9;
                cell3.HorizontalAlignment = 1;
                cell3.PaddingBottom = 10f;
                cell3.PaddingTop = 10f;
                table3.AddCell(cell3);

                table3.SetWidths(columnWidths);

                // Agregar encabezados de columna
                for (int i = 0; i < Data_Datos.Columns.Count; i++)
                {
                    table.AddCell(Data_Datos.Columns[i].HeaderText);
                    table2.AddCell(Data_Datos.Columns[i].HeaderText);
                    table3.AddCell(Data_Datos.Columns[i].HeaderText);
                }
                bool tabla1 = false;
                bool tabla2 = false;
                bool tabla3 = false;
                // Agregar datos del DataGridView al PDF
                for (int i = 0; i < Data_Datos.Rows.Count; i++)
                {
                    double.TryParse(Data_Datos[5, i].Value.ToString(), out double valorColumna5);
                    double.TryParse(Data_Datos[6, i].Value.ToString(), out double valorColumna6);
                    for (int j = 0; j < Data_Datos.Columns.Count; j++)
                    {
                        if (Data_Datos[5, i].Value.ToString() == Data_Datos[6, i].Value.ToString())
                        {
                            table.AddCell(Data_Datos[j, i].Value.ToString());
                            tabla1 = true;
                        }
                        else if (valorColumna6 < valorColumna5)
                        {
                            table2.AddCell(Data_Datos[j, i].Value.ToString());
                            tabla2 = true;
                        }
                        else if (valorColumna6 > valorColumna5)
                        {
                            table3.AddCell(Data_Datos[j, i].Value.ToString());
                            tabla3 = true;
                        }
                    }
                }
                iTextSharp.text.Font customFont = FontFactory.GetFont("Arial", 10);
                Paragraph emptyParagraph = new Paragraph();
                emptyParagraph.SpacingBefore = 20f;
                Paragraph firmaParagraph = new Paragraph("________________________         ________________________          ________________________");
                firmaParagraph.Alignment = Element.ALIGN_CENTER; // Alineación al centro

                Paragraph firmaParagraph2 = new Paragraph("ENCARGADO DE RECIBO                        ENCARGADO DE COMPRAS                    ENCARGADO DE TESORERÍA", customFont); // Línea de firma
                firmaParagraph2.Alignment = Element.ALIGN_CENTER; // Alineación al centro

                // Agregar la tabla al documento PDF
                if (tabla1 == true)
                {
                    doc.Add(table);
                    doc.Add(emptyParagraph);

                }
                if (tabla2 == true)
                {
                    doc.Add(table2);
                    doc.Add(emptyParagraph);

                }
                if (tabla3 == true)
                    doc.Add(table3);
                //doc.Add(cell4);
                doc.Add(emptyParagraph);
                doc.Add(firmaParagraph);
                doc.Add(firmaParagraph2);
                // Cerrar el documento
                doc.Close();
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }

        private void Data_Datos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Data_Datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString() && Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0")
            {
                Data_Datos.Rows[e.RowIndex].Cells[6].Value = Data_Datos.Rows[e.RowIndex].Cells[5].Value;
            }
            else if (Data_Datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString() && Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString() != "0")
            {
                decimal valor5 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString());
                for (int i = 0; i < Articulos.Count; ++i)
                {
                    if (Data_Datos.Rows[e.RowIndex].Cells[0].Value == Articulos[i].Codigo)
                    {

                        GlobalSettings.Instance.temporal = Articulos[i].Recibidas;
                        break;
                    }

                }
                Data_Datos.Rows[e.RowIndex].Cells[6].Value = valor5 + GlobalSettings.Instance.temporal;
                GlobalSettings.Instance.CambioColor = true;
            }
            else if (Data_Datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString() && Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString() != "0")
            {
                if (Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString() == Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString())
                {
                    decimal valor = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[8].Value.ToString());
                    decimal valor6 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString());
                    for (int i = 0; i < Articulos.Count; ++i)
                    {
                        if (Data_Datos.Rows[e.RowIndex].Cells[0].Value == Articulos[i].Codigo)
                        {

                            GlobalSettings.Instance.temporal = Articulos[i].Recibidas;
                            break;
                        }

                    }
                    Data_Datos.Rows[e.RowIndex].Cells[6].Value = GlobalSettings.Instance.temporal + valor;
                    valor6 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString());
                    decimal valor5 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString());
                    if (valor6 > valor5)
                        GlobalSettings.Instance.CambioColor = true;
                    else
                        GlobalSettings.Instance.Incompleto = true;
                }
                else
                {
                    decimal valor = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[8].Value.ToString());
                    decimal valor2 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    decimal valor6 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString());
                    decimal objetivo = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString());
                    for (int i = 0; i < Articulos.Count; ++i)
                    {
                        if (Data_Datos.Rows[e.RowIndex].Cells[0].Value == Articulos[i].Codigo)
                        {

                            GlobalSettings.Instance.temporal = Articulos[i].Recibidas;
                            break;
                        }

                    }
                    // MessageBox.Show(Articulos[1].Recibidas.ToString());
                    //MessageBox.Show(valor2.ToString());
                    Data_Datos.Rows[e.RowIndex].Cells[6].Value = (valor / valor2) + GlobalSettings.Instance.temporal;

                    decimal valor5 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString());
                    valor6 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString());
                    if (valor6 > valor5)
                        GlobalSettings.Instance.CambioColor = true;
                    else
                        GlobalSettings.Instance.Incompleto = true;
                }
            }
            else if (Data_Datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString() && Data_Datos.Rows[e.RowIndex].Cells[6].Value.ToString() == "0")
            {
                if (Data_Datos.Rows[e.RowIndex].Cells[5].Value.ToString() == Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString())
                {
                    decimal valor = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[8].Value.ToString());
                    Data_Datos.Rows[e.RowIndex].Cells[6].Value = valor;
                    decimal objetivo = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString());
                    if (valor > objetivo)
                        GlobalSettings.Instance.CambioColor = true;
                    else
                    {
                        if (valor != 0)
                            GlobalSettings.Instance.Incompleto = true;
                    }
                }
                else
                {
                    decimal valor = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[8].Value.ToString());
                    decimal valor2 = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    decimal objetivo = decimal.Parse(Data_Datos.Rows[e.RowIndex].Cells[7].Value.ToString());
                    Data_Datos.Rows[e.RowIndex].Cells[6].Value = valor / valor2;
                    if (valor > objetivo)
                        GlobalSettings.Instance.CambioColor = true;
                    else
                    {
                        if (valor != 0)
                            GlobalSettings.Instance.Incompleto = true;
                    }
                }
            }

        }

        private void Data_Datos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl editingControl)
            {
                // Adjunta un manejador de eventos KeyPress al control de edición
                editingControl.KeyPress -= EditingControl_KeyPress; // Asegúrate de eliminar cualquier manejador previo
                editingControl.KeyPress += EditingControl_KeyPress;
            }
        }
        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número, Backspace o Enter
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter && e.KeyChar != '.')
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Evita que se ingrese el carácter no válido
            }
        }
    }

}